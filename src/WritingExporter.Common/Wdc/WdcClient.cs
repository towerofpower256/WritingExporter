using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WritingExporter.Common.Configuration;
using WritingExporter.Common.Events;
using WritingExporter.Common.Events.WritingExporter.Common.Events;
using WritingExporter.Common.Exceptions;
using WritingExporter.Common.Logging;

namespace WritingExporter.Common.Wdc
{
    public class WdcClient : IEventSubscriber<ConfigSectionChangedEventArgs>
    {
        internal const string LOGIN_FIELD_NAME_USERNAME = "login_username";
        internal const string LOGIN_FIELD_NAME_PASSWORD = "login_password";
        private const string URL_ROOT = "https://www.writing.com/";
        private const string LOGIN_URL_SEGMENT = "main/login.php";



        private ILogger _log;
        private EventHub _eventHub;
        private HttpClientHandler httpClientHandler;
        private HttpClient httpClient;
        private CookieContainer httpCookies;
        private WdcClientConfigSection _config;
        private ConfigService _configService;
        bool _configHasChanged = false;

        public WdcClient(ILoggerSource loggerSource, ConfigService config, EventHub eventHub)
        {
            _log = loggerSource.GetLogger(typeof(WdcClient));
            _log.Debug("Starting");

            _configService = config;
            _eventHub = eventHub;

            UpdateSettings();

            httpCookies = new CookieContainer();
            httpClientHandler = new HttpClientHandler();
            httpClientHandler.CookieContainer = httpCookies;
            httpClient = new HttpClient(httpClientHandler, true);

            // Register for events
            _eventHub.Subscribe<ConfigSectionChangedEventArgs>(this);
        }

        public void Reset()
        {
            _log.Debug("Resetting");
            ClearCookies();
        }

        private void UpdateSettings()
        {
            _log.Debug("Updating settings");
            // Grab a new settings object from the config provider
            _config = _configService.GetSection<WdcClientConfigSection>();
        }


        private void ClearCookies()
        {
            _log.Debug("Clearing cookies");
            var newCookieContainer = new CookieContainer();

            httpCookies = newCookieContainer;
            httpClientHandler.CookieContainer = newCookieContainer;
        }

        private void CheckConfigUpdated()
        {
            if (_configHasChanged)
            {
                UpdateSettings();
            }
        }

        public Task HandleEventAsync(ConfigSectionChangedEventArgs @event)
        {
            if (@event.IsSectionType(typeof(WdcClientConfigSection)))
            {
                _configHasChanged = true; // Mark that the config has changed. Will be reloaded on next usage.
            }

            return Task.CompletedTask;
        }

        public async Task LoginAsync(CancellationToken ct)
        {
            CheckConfigUpdated();

            var username = _config.WritingUsername;
            var password = _config.WritingPassword;

            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("username", "The Writing.com username cannot be empty");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("username", "The Writing.com password cannot be empty");

            await LoginAsync(username, password, ct);
        }

        public async Task LoginAsync(string username, string password, CancellationToken ct)
        {
            _log.Debug("Logging into writing.com");

            CheckConfigUpdated();

            // Endcode login info, ready to be included in the POST data.
            Dictionary<string, string> contentDict = new Dictionary<string, string>();
            contentDict.Add(LOGIN_FIELD_NAME_USERNAME, username);
            contentDict.Add(LOGIN_FIELD_NAME_PASSWORD, password);
            // Not sure if this is needed in the POST data, but it iss by some browsers.
            contentDict.Add("submit", "submit");
            contentDict.Add("send_to", "/");
            FormUrlEncodedContent formEncContent = new FormUrlEncodedContent(contentDict);

            // Send the post request
            Uri loginUrl = GetPathToLogin();
            HttpResponseMessage response = await httpClient.PostAsync(loginUrl, formEncContent, ct);
            response.EnsureSuccessStatusCode();
            // Don't need to handle cookies here, the httpClient has been given its own cookie store.

            // Check for a failed login
            string contentString = await response.Content.ReadAsStringAsync();
            if (IsLoginFailedPage(contentString))
                throw new WdcLoginFailedException("Writing.com login failed");

        }

        public async Task<WdcResponse> GetInteractiveHomepage(string interactiveID, CancellationToken ct)
        {
            CheckConfigUpdated();

            Uri interactiveUri = GetPathToInteractive(interactiveID);
            _log.DebugFormat("Getting interactive story: {0}", interactiveUri);
            var r = new WdcResponse();
            r.Address = interactiveUri.ToString();
            r.WebResponse = await GetWdcPage(interactiveUri, ct);
            return r;
        }

        public async Task<WdcResponse> GetInteractiveChapter(string interactiveID, string chapterID, CancellationToken ct)
        {
            CheckConfigUpdated();

            Uri chapterUri = GetPathToInteractiveChapter(interactiveID, chapterID);
            _log.DebugFormat("Getting interactive story chapter: {0}", chapterUri);
            var r = new WdcResponse();
            r.Address = chapterUri.ToString();
            r.WebResponse = await GetWdcPage(chapterUri, ct);
            return r;
        }

        public async Task<WdcResponse> GetInteractiveOutline(string interactiveID, CancellationToken ct)
        {
            CheckConfigUpdated();

            Uri outlineUri = GetPathToInteractiveOutline(interactiveID);
            _log.DebugFormat("Getting interactive story outline: {0}", outlineUri);
            var r = new WdcResponse();
            r.Address = outlineUri.ToString();
            r.WebResponse = await GetWdcPage(outlineUri, ct);
            return r;
        }

        public async Task<WdcResponse> GetInteractiveRecentAdditions(string interactiveID, CancellationToken ct)
        {
            CheckConfigUpdated();

            Uri recentAdditionsUri = GetPathToInteractiveRecentAdditions(interactiveID);
            _log.DebugFormat("Getting interactive story recent additions: {0}", recentAdditionsUri);
            var r = new WdcResponse();
            r.Address = recentAdditionsUri.ToString();
            r.WebResponse = await GetWdcPage(recentAdditionsUri, ct);
            return r;
        }

        public async Task<string> GetWdcPage(Uri uri, CancellationToken ct)
        {
            CheckConfigUpdated();

            string html = await HttpGetAsyncAsString(uri, ct);

            if (IsInteractivesUnavailablePage(html))
                throw new InteractivesTemporarilyUnavailableException();

            // Detect "Login required" or "access restricted"
            if (IsLoginPage(html))
            {
                // We need to log in, and get the chapter again
                _log.Debug("Login required while trying to get page");
                await LoginAsync(ct);

                // Get it again
                html = await HttpGetAsyncAsString(uri, ct);

                // Check if it's a login again. If it is, login failed
                if (IsLoginPage(html))
                    throw new WdcLoginFailedException($"Failed to login to get page: {uri.ToString()}");
            }

            return html;
        }

        public Uri GetPathToRoot()
        {
            return new Uri(URL_ROOT);
        }

        public Uri GetPathToLogin()
        {
            return new Uri(GetPathToRoot(), LOGIN_URL_SEGMENT);
        }

        // E.g. https://www.writing.com/main/interact/item_id/209084-Looking-for-adventure
        public Uri GetPathToInteractive(string storyId)
        {
            var r = new Uri(GetPathToRoot(), $"/main/interact/item_id/{storyId}");
            return r;
        }

        // E.g. https://www.writing.com/main/interact/item_id/209084-Looking-for-adventure/action/outline
        public Uri GetPathToInteractiveOutline(string storyId)
        {
            var r = new Uri(GetPathToInteractive(storyId) + "/action/outline");
            return r;
        }

        // E.g. https://www.writing.com/main/interact/item_id/209084-Looking-for-adventure/action/recent_chapters
        public Uri GetPathToInteractiveRecentAdditions(string storyId)
        {
            var r = new Uri(GetPathToInteractive(storyId) + "/action/recent_chapters");
            return r;
        }

        // E.g. https://www.writing.com/main/interact/item_id/209084-Looking-for-adventure/map/1
        public Uri GetPathToInteractiveChapter(string storyId, string chapterId)
        {
            return new Uri(GetPathToInteractive(storyId) + $"/map/{chapterId}");
        }

        private async Task<HttpResponseMessage> HttpGetAsync(Uri urlToGet, CancellationToken ct)
        {
            //HttpResponseMessage response = await httpClient.GetAsync(urlToGet, ct);
            HttpResponseMessage response = httpClient.GetAsync(urlToGet, ct).Result;
            response.EnsureSuccessStatusCode(); // Fail if result is not 200 OK

            return response;
        }

        private async Task<string> HttpGetAsyncAsString(Uri urlToGet, CancellationToken ct)
        {
            HttpResponseMessage response = await HttpGetAsync(urlToGet, ct);
            return await response.Content.ReadAsStringAsync();
        }

        private CookieCollection GetCookies(HttpClientHandler handler, Uri url)
        {
            return handler.CookieContainer.GetCookies(url);
        }

        public bool IsLoginPage(string html)
        {
            // Regex to detect the login fields, which should only be visible if we've tried to access something that requires logging in
            Regex UsernameFieldRegex = new Regex(
                string.Format(@"<input.*{0}.*>", LOGIN_FIELD_NAME_USERNAME),
                RegexOptions.IgnoreCase
                );

            //Method: look for a username and password field
            return UsernameFieldRegex.IsMatch(html);
        }

        public bool IsLoginFailedPage(string html)
        {
            // Regex to detect the "Failed Login" page. Look for it in the page's title
            Regex FailedLoginRegex = new Regex(
                @"<title>.*(Login Error|Login failed).*<\/title>",
                RegexOptions.IgnoreCase
            );

            return FailedLoginRegex.IsMatch(html);
        }

        public bool IsInteractivesUnavailablePage(string content)
        {
            // Regex to detect the "Interactives temporarily unavailable due to resource limitations" message
            Regex InteractivesUnavailableRegex1 = new Regex(
                @"<title>.*(Interactives Temporarily Unavailable|Interactive Stories Are Temporarily Unavailable).*<\/title>",
                RegexOptions.IgnoreCase
                );

            // Regex to detect the "Interactive Stories are temporarily unavailable" message
            // Can sometimes appear different to the first message
            Regex InteractivesUnavailableRegex2 = new Regex(
                @"<b>Interactive Stories</b> are <br><i>temporarily</i> unavailable",
                RegexOptions.IgnoreCase
                );

            return InteractivesUnavailableRegex1.IsMatch(content) || InteractivesUnavailableRegex2.IsMatch(content);
        }
    }
}
