﻿using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WritingExporter.Common.Configuration;
using WritingExporter.Common.Data;
using WritingExporter.Common.Data.Repositories;
using WritingExporter.Common.Events.WritingExporter.Common.Events;
using WritingExporter.Common.Logging;
using WritingExporter.Common.Wdc;

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

            // Validate
            _container.Verify();

            return this;
        }

        public AppContext Start()
        {
            _log.Debug("Starting app context");
            // Start the GUI
            Application.Run(_container.GetInstance<Forms.MainForm>());

            // Shutdown
            _log.Info("Shutting down app context");

            return this;
        }

        private void SetupLogging()
        {
            // Setup logging
            // TODO change to something more legit like Serilog
            Trace.AutoFlush = true;
            Trace.Listeners.Add(new ConsoleTraceListener());

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
            _container.Register<WdcStoryChapterRepository, WdcStoryChapterRepository>();
            _container.Register<WdcStoryAuthorRepository, WdcStoryAuthorRepository>();
            _container.Register<WdcStorySyncStatusRepository, WdcStorySyncStatusRepository>();
        }

        private void RegisterWdc()
        {
            _log.Debug("Registering WDC services");
            _container.Register<WdcReaderFactory, WdcReaderFactory>(Lifestyle.Singleton);
            _container.Register<WdcClient, WdcClient>();
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
