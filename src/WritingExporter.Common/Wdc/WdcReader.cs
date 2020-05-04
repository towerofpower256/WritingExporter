using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using WritingExporter.Common.Logging;
using WritingExporter.Common.Models;
using WritingExporter.Common.Exceptions;

namespace WritingExporter.Common.Wdc
{
    public class WdcReader
    {
        WdcReaderOptions _options;
        ILogger _log;

        public WdcReader(WdcReaderOptions options)
        {
            _options = options;
            _log = new TraceLogger(typeof(WdcReader).ToString());
        }

        public void SetLogger(ILogger log)
        {
            _log = log;
        }


        public WdcStory GetInteractiveStory(string payload, string interactiveID, string interactiveUrl)
        {
            _log.DebugFormat("Getting interactive story: {0}", interactiveID);

            var story = new WdcStory();

            // Get interactive story title
            story.Id = interactiveID;
            story.Url = interactiveUrl;
            story.Name = GetInteractiveStoryTitle(payload);
            story.ShortDescription = GetInteractiveStoryShortDescription(payload);
            story.Description = GetInteractiveStoryDescription(payload);
            story.LastUpdatedInfo = DateTime.Now;

            return story;
        }

        // Get the interactive story's title
        // This method grabs it from within the <title> element, not sure if it gets truncated or not.
        public string GetInteractiveStoryTitle(string htmlPayload)
        {
            Regex interactiveTitleRegex = new Regex(_options.InteractiveTitleRegex, RegexOptions.IgnoreCase);
            Match interactiveTitleMatch = interactiveTitleRegex.Match(htmlPayload);
            if (!interactiveTitleMatch.Success)
                throw new WdcReaderHtmlParseException($"Couldn't find the title for interactive story");
            return HttpUtility.HtmlDecode(WdcUtil.CleanHtmlSymbols(interactiveTitleMatch.Value));
        }

        // Get the interactive's tagline or short description
        // Previously this has been difficult to pin-point
        // However I found this on 11/01/2019, they've got it in a META tag at the top of the HTML
        // E.g. <META NAME="description" content="How will young James fare alone with his mature, womanly neighbors? ">
        public string GetInteractiveStoryShortDescription(string htmlPayload)
        {
            Regex interactiveShortDescRegex = new Regex(_options.InteractiveShortDescriptionRegex, RegexOptions.IgnoreCase);
            Match interactiveShortDescMatch = interactiveShortDescRegex.Match(htmlPayload);
            if (!interactiveShortDescMatch.Success)
                _log.Warn($"Couldn't find the short description for interactive story"); // Just a warning, don't throw an exception over it
            return HttpUtility.HtmlDecode(WdcUtil.CleanHtmlSymbols(interactiveShortDescMatch.Value));
        }

        // Get the interactive story's description
        public string GetInteractiveStoryDescription(string htmlPayload)
        {
            Regex interactiveDescRegex = new Regex(_options.InteractiveDescriptionRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match interactiveDescMatch = interactiveDescRegex.Match(htmlPayload);
            if (!interactiveDescMatch.Success)
                throw new WdcReaderHtmlParseException($"Couldn't find the description for interactive story");
            return HttpUtility.HtmlDecode(WdcUtil.CleanHtmlSymbols(interactiveDescMatch.Value));
        }

        // TODO get author, looks like it'll be a pain in the ass telling the chapter author apart from the story author
        public WdcAuthorReaderResult GetInteractiveStoryAuthor(string htmlPayload)
        {
            throw new NotImplementedException();
        }

        public WdcChapter GetInteractiveChapter(string chapterPath, string htmlPayload)
        {

            if (!WdcUtil.IsValidChapterPath(chapterPath))
                throw new ArgumentException($"Chapter '{chapterPath}' is not a valid chapter path", nameof(chapterPath));

            var chapter = new WdcChapter();
            chapter.Path = chapterPath;
            chapter.Title = GetInteractiveChapterTitle(htmlPayload);
            chapter.Content = GetInteractiveChapterContent(htmlPayload);
            if (chapterPath != "1") chapter.SourceChoiceTitle = GetInteractiveChapterSourceChoice(htmlPayload); // Only get the source choice if it's not the first chapter
            else chapter.SourceChoiceTitle = "";
            chapter.LastUpdated = DateTime.Now;
            var author = GetInteractiveChapterAuthor(htmlPayload);
            chapter.AuthorName = author.AuthorName;
            chapter.AuthorUsername = author.AuthorUsername;

            return chapter;
        }

        // Get the chapter's title
        public string GetInteractiveChapterTitle(string htmlPayload) => GetInteractiveChapterTitleM3(htmlPayload);

        // Get chapter title
        // Method 1. Get it from the "Your path to this chapter"
        // CAUTION: can sometimes get truncated, but this appears to be the the legit title from the database, it was truncated when the chapter was made
        // NOTE: Fails on the first chapter, because there's no choices made yet
        [Obsolete]
        private string GetInteractiveChapterTitleM1(string htmlPayload)
        {
            string chapterTitleRegexPattern = string.Format("(?<=\\/map\\/{0}\">).*?(?=<\\/a>)", htmlPayload);

            Regex chapterTitleRegex = new Regex(chapterTitleRegexPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match chapterTitleMatch = chapterTitleRegex.Match(htmlPayload);
            if (!chapterTitleMatch.Success)
                throw new WdcReaderHtmlParseException($"Couldn't find the chapter title for chapter");
            return HttpUtility.HtmlDecode(chapterTitleMatch.Value);
        }

        // Get chapter title
        // Method 2. Get it from between <big><big><b>...</b></big></big>
        // There are other isntances of the <big><b> tags in use, but only the chapter title gets wrapped in 2x of them
        // Isn't perfect, but until the website layout changes, it'll work
        // TODO: It doesn't work anymore :( chapter titles aren't being read.
        private string GetInteractiveChapterTitleM2(string htmlPayload)
        {
            string chapterTitleRegexPattern = @"(?<=<big><big><b>).*?(?=<\/b><\/big><\/big>)";

            Regex chapterTitleRegex = new Regex(chapterTitleRegexPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match chapterTitleMatch = chapterTitleRegex.Match(htmlPayload);
            if (!chapterTitleMatch.Success)
                throw new WdcReaderHtmlParseException($"Couldn't find the chapter title for chapter");
            return HttpUtility.HtmlDecode(chapterTitleMatch.Value);
        }

        // Get chapter title
        // Method 3. Get it from within the page title.
        // So it looks like paid users get some sort of dynamic reading pages
        // where it AJAX loads chapter pages instead of loading static pages.
        // This should solve this by getting it from the page title.
        private string GetInteractiveChapterTitleM3(string htmlPayload)
        {
            // Default regex: (?<=<title>).*?(?=<\/title>)
            string pageTitlePattern = _options.ChapterTitleRegex;

            Regex pageTitleRegex = new Regex(pageTitlePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match pageTitleMatch = pageTitleRegex.Match(htmlPayload);
            if (!pageTitleMatch.Success)
                throw new WdcReaderHtmlParseException($"Couldn't find the page title on chapter");

            // Got the page title value, try to parse it
            var titleResponse = ReadPageTitle(pageTitleMatch.Value);
            if (string.IsNullOrEmpty(titleResponse.PageName))
                throw new WdcReaderHtmlParseException($"Couldn't find the chapter title in the page title for chapter");

            return titleResponse.PageName;
        }

        // Search for the choice that lead to this chapter
        // This usually has the more fleshed out title, as the legit title can sometimes be truncated
        public string GetInteractiveChapterSourceChoice(string htmlPayload)
        {
            // Default regex: (?<=This choice: <b>).*?(?=<\/b>)
            Regex chapterSourceChoiceRegex = new Regex(_options.ChapterSourceChoiceRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match chapterSourceChoiceMatch = chapterSourceChoiceRegex.Match(htmlPayload);
            if (!chapterSourceChoiceMatch.Success) // If we can't find it, and it's not the first chapter
                throw new WdcReaderHtmlParseException($"Couldn't find the interactive chapter's source choice and this isn't the first chapter");
            return HttpUtility.HtmlDecode(chapterSourceChoiceMatch.Value);
        }

        // Get the chapter's content, it's body
        public string GetInteractiveChapterContent(string htmlPayload) => GetInteractiveChapterContentM2(htmlPayload);

        // Search for the chapter content, the actual writing
        // <div class="KonaBody">stuff goes here</div>
        private string GetInteractiveChapterContentM1(string htmlPayload)
        {

            Regex chapterContentRegex = new Regex("(?<=<div class=\"KonaBody\">).+?(?=<\\/div>)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match chapterContentMatch = chapterContentRegex.Match(htmlPayload);
            if (!chapterContentMatch.Success)
                throw new WdcReaderHtmlParseException($"Couldn't find the content for the interactive chapter");
            return HttpUtility.HtmlDecode(chapterContentMatch.Value);
        }

        // Get the chapter content
        // WDC has changed the layout, and doesn't have "KonaBody" in it anymore
        // It looks like they've just set it to <div class=""> in the HTML, and that's the only instance of an empty class
        private string GetInteractiveChapterContentM2(string htmlPayload)
        {
            // Default regex: (?<=<div class=\"\">).+?(?=<\\/div>)
            Regex chapterContentRegex = new Regex(_options.ChapterContentRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match chapterContentMatch = chapterContentRegex.Match(htmlPayload);
            if (!chapterContentMatch.Success)
                throw new WdcReaderHtmlParseException($"Couldn't find the content for the interactive chapter");
            return HttpUtility.HtmlDecode(chapterContentMatch.Value);
        }

        // Get the author
        // <a title="Username: rpcity Member Since: July 4th, 2002 Click for links!" style="font - size:1em; font - weight:bold; cursor: pointer; ">SmittySmith</a>
        public WdcAuthorReaderResult GetInteractiveChapterAuthor(string htmlPayload)
        {
            // Default regex: <a title=\" Username: .*?<\\/a>
            Regex chapterAuthorChunkRegex = new Regex(_options.ChapterAuthorChunkRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match chapterAuthorChunkMatch = chapterAuthorChunkRegex.Match(htmlPayload);
            if (!chapterAuthorChunkMatch.Success)
                throw new WdcReaderHtmlParseException($"Couldn't find the HTML chunk containing the author for the interactive chapter");
            string chapterAuthorChunk = chapterAuthorChunkMatch.Value;

            // Get the author username
            // Default regex: (?<=Username: )[a-zA-Z]+
            Regex chapterAuthorUsernameRegex = new Regex(_options.ChapterAuthorUsernameRegex);
            Match chapterAuthorUsernameMatch = chapterAuthorUsernameRegex.Match(chapterAuthorChunk);
            string chapterAuthorUsername = chapterAuthorUsernameMatch.Value;

            // Get the author display name
            // Default regex: (?<=>).+?(?=<)
            Regex chapterAuthorNameRegex = new Regex(_options.ChapterAuthorNameRegex);
            Match chapterAuthorNameMatch = chapterAuthorNameRegex.Match(chapterAuthorChunk);
            string chapterAuthorName = chapterAuthorNameMatch.Value;

            return new WdcAuthorReaderResult()
            {
                AuthorName = chapterAuthorName,
                AuthorUsername = chapterAuthorUsername
            };
        }

        // Get the available choices
        // This one is going to be complicated, because none of the divs or whatnot have ID's
        // First, get a chunk of the HTML that contains the choices, we'll break them down later
        public IEnumerable<WdcChapterChoice> GetInteractiveChapterChoices(string htmlPayload)
        {
            if (IsInteractiveChapterEnd(htmlPayload)) return null;

            var choices = new List<WdcChapterChoice>();

            // Default regex: (?<=<b>You have the following choice(s)?:<\\/b>).*?(?=<\\/div><div id=\"end_of_choices\")
            Regex chapterChoicesChunkRegex = new Regex(_options.ChapterChoicesChunkRegex,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Match chapterChoicesChunkMatch = chapterChoicesChunkRegex.Match(htmlPayload);
            if (!chapterChoicesChunkMatch.Success)
                throw new WdcReaderHtmlParseException($"Couldn't find the HTML chunk containing choices for interactive chapter");
            string chapterChoicesChunkHtml = chapterChoicesChunkMatch.Value;

            // Then try to get the individual choices
            // Default regex: "<a .*?href=\".+?\">.+?<\\/a>"
            Regex chapterChoicesRegex = new Regex(_options.ChapterChoicesRegex, RegexOptions.IgnoreCase);
            MatchCollection chapterChoicesMatches = chapterChoicesRegex.Matches(chapterChoicesChunkHtml);
            foreach (Match match in chapterChoicesMatches)
            {
                var newChoice = new WdcChapterChoice();
                string choiceUrl;

                // Get the URL
                // Default regex: (?<=href=\").+?(?=\")
                Regex choiceUrlRegex = new Regex(_options.ChapterChoiceUrlRegex);
                Match choiceUrlMatch = choiceUrlRegex.Match(match.Value);
                if (!choiceUrlMatch.Success)
                    throw new WdcReaderHtmlParseException($"Could not find the URL of choice '{match.Value}'");
                choiceUrl = choiceUrlMatch.Value;

                // Get just the numbers from the URL
                newChoice.PathLink = WdcUtil.GetFinalParmFromUrl(choiceUrl);

                // Get the choice name / description
                // Get what's in between the > and the <
                int indexOfGt = match.Value.IndexOf('>');
                int indexofLt = match.Value.LastIndexOf('<') - 1;
                newChoice.Name = HttpUtility.HtmlDecode(match.Value.Substring(indexOfGt + 1, indexofLt - indexOfGt));

                choices.Add(newChoice);
            }

            return choices.ToArray();
        }

        public IEnumerable<Uri> GetInteractiveChapterList(string interactiveID, string htmlPayload)
        {
            var chapters = new List<Uri>();

            // Find the links to the interactive's pages
            // Create the regex that will find chapter links
            // E.g. https:\/\/www\.writing\.com\/main\/interact\/item_id\/1824771-short-stories-by-the-people\/map\/(\d)+
            string chapterLinkRegexPattern = _options.WdcUrlRoot.ToString() + string.Format("main/interact/item_id/{0}/map/{1}", interactiveID, @"(\d)+");
            chapterLinkRegexPattern = WdcUtil.RegexSafeUrl(chapterLinkRegexPattern);
            Regex chapterLinkRegex = new Regex(chapterLinkRegexPattern, RegexOptions.IgnoreCase);
            MatchCollection matches = chapterLinkRegex.Matches(htmlPayload);

            foreach (Match match in matches)
            {
                chapters.Add(new Uri(match.Value));
            }

            return chapters.ToArray();
        }

        public bool IsInteractiveChapterEnd(string htmlPayload)
        {
            //Regex chapterEndRegex = new Regex("<big>THE END.<\\/big>");// Turns out this doesn't work, because they HTML tagging is sloppy and overlaps. <i><b>THE END.</i></b>

            // Default regex: >You have come to the end of the story. You can:<\\/
            Regex chapterEndRegex = new Regex(_options.ChapterEndCheckRegex);
            return chapterEndRegex.IsMatch(htmlPayload);
        }

        private const char TITLE_SEPARATOR = ':';
        public WdcTitleReaderResult ReadPageTitle(string pageTitle)
        {
            var r = new WdcTitleReaderResult();

            if (string.IsNullOrEmpty(pageTitle)) return r;

            // Start by trimming off the " - Writing.com"
            Regex titleTailPattern = new Regex(" - writing\\.com", RegexOptions.IgnoreCase);
            pageTitle = titleTailPattern.Replace(pageTitle, "");

            // Look for the ": ", and split it
            var indexOfSeparator = pageTitle.IndexOf(TITLE_SEPARATOR);
            if (indexOfSeparator < 0)
            {
                // Didn't find separator, is just a simple page name
                r.StoryName = WdcUtil.CleanHtmlSymbols(pageTitle.Trim());
            }
            else
            {
                // Found separator, there are 2 parts
                var pageTitleSplit = pageTitle.Split(TITLE_SEPARATOR);

                // THe recent chapters page uses "Recent chapters: (story title)"
                bool backwards = pageTitleSplit[0] == "Recent Chapters";

                r.StoryName = WdcUtil.CleanHtmlSymbols(
                    pageTitleSplit[backwards ? 1 : 0].Trim()
                    );
                r.PageName = WdcUtil.CleanHtmlSymbols(
                    pageTitleSplit[backwards ? 0 : 1].Trim()
                    );
            }

            return r;
        }
    }

    public class WdcTitleReaderResult
    {
        public string StoryName { get; set; } = string.Empty;
        public string PageName { get; set; } = string.Empty;
    }

    public class WdcAuthorReaderResult
    {
        public string AuthorName { get; set; }

        public string AuthorUsername { get; set; }
    }
}
