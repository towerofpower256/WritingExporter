using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Configuration;
using WritingExporter.Common.Data;
using WritingExporter.Common.Data.Repositories;
using WritingExporter.Common.Events;
using WritingExporter.Common.Events.WritingExporter.Common.Events;
using WritingExporter.Common.Export;
using WritingExporter.Common.Logging;
using WritingExporter.Common.Wdc;
using WritingExporter.Common.WdcSync;

namespace WritingExporter.WinForms
{
    public class AppContext
    {
        private Container _container;
        private ILogger _log;

        public AppContext()
        {
            _container = new Container();
        }

        public AppContext Setup()
        {
            // Logging
            SetupLogging();

            _log.Debug("Starting setup of app context");

            // Setup GUI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Register stuff
            RegisterSystem();
            RegisterData();
            RegisterWdc();
            RegisterWinForms();

#if DEBUG
            // Validate
            _container.Verify();
#endif

            return this;
        }

        public AppContext Start()
        {
            _log.Debug("Starting app context");

            // Attach exception listener
            var exceptionListener = new ExceptionAlertListener();
            _container.GetInstance<EventHub>().Subscribe<ExceptionAlertEvent>(exceptionListener);

            // Load settings
            _container.GetInstance<ConfigService>().LoadSettings();

            // Start the sync worker
            var syncWorker = _container.GetInstance<WdcSyncWorker>();
            syncWorker.Start(); // TODO re-enable worker
            
            // Start the GUI
            Application.Run(_container.GetInstance<Forms.MainForm>());

            // Shutdown
            _log.Info("Shutting down app context");
            syncWorker.Stop();

            return this;
        }

        private void SetupLogging()
        {
            // Setup logging
            // TODO change to something more legit like Serilog
            Trace.AutoFlush = true;

            ILoggerSource logSource = new TraceLoggerSource();
            _container.RegisterInstance<ILoggerSource>(logSource);

            _log = logSource.GetLogger(typeof(AppContext));
        }

        private void RegisterSystem()
        {
            _log.Debug("Registering system services");
            //_container.Register<IFileDumper, FileDumper>(Lifestyle.Singleton);
            //_container.Register<IConfigProvider, ConfigProvider>(Lifestyle.Singleton);
            //_container.Register<IStoryFileStore, XmlStoryFileStore>(Lifestyle.Singleton);

            _container.Register<ConfigService, ConfigService>(Lifestyle.Singleton);
            _container.Register<EventHub, EventHub>(Lifestyle.Singleton);
        }

        private void RegisterData()
        {
            _log.Debug("Registering data services");
            _container.Register<IDbConnectionFactory, DbConnectionFactory>(Lifestyle.Singleton);
            _container.Register<WdcStoryRepository, WdcStoryRepository>();
            _container.Register<WdcChapterRepository, WdcChapterRepository>();
        }

        private void RegisterWdc()
        {
            _log.Debug("Registering WDC services");
            _container.Register<WdcReaderFactory, WdcReaderFactory>(Lifestyle.Singleton);
            _container.Register<WdcClient, WdcClient>(Lifestyle.Singleton);
            _container.Register<IWdcStoryExporter, WdcStoryExporterHtmlCollection>();


            var syncWorkerRegistration = Lifestyle.Transient.CreateRegistration(typeof(WdcSyncWorker), _container);
            syncWorkerRegistration.SuppressDiagnosticWarning(
                SimpleInjector.Diagnostics.DiagnosticType.DisposableTransientComponent, "Dispose is called in application code");
            _container.AddRegistration<WdcSyncWorker>(syncWorkerRegistration);
        }

        private void RegisterWinForms()
        {
            _log.Debug("Registering all forms");

            foreach (var t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsSubclassOf(typeof(Form)))
                {
                    _container.Register(t, t);

                    // Prevent IDisposable warnings for forms
                    _container.GetRegistration(t).Registration
                        .SuppressDiagnosticWarning(SimpleInjector.Diagnostics.DiagnosticType.DisposableTransientComponent, "Ignore warnings for winforms");
                }
            }
        }
    }
}
