using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleInjector;
using WritingExporter.Common;
using WritingExporter.Common.Events;
using WritingExporter.Common.Logging;
using WritingExporter.Common.WDC;
using WritingExporter.Common.Configuration;

namespace WritingExporter.WinForms.WdcTester
{
    static class Program
    {
        private static ILogger _log;

        public static Container ServiceContainer;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceContainer = new Container();

            // Setup logging
            ILoggerSource logSource = new TraceLoggerSource();
            _log = logSource.GetLogger(typeof(Program));
            _log.Info("Starting");
            ServiceContainer.RegisterInstance<ILoggerSource>(logSource);

            // Setup some other stuff
            ServiceContainer.Register<EventHub, EventHub>();
            ServiceContainer.Register<IConfigProvider, ConfigProvider>();
            ServiceContainer.Register<WdcClient, WdcClient>();
            ServiceContainer.Register<WdcReader, WdcReader>();

            ServiceContainer.Verify();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(ServiceContainer.GetInstance<Forms.MainForm>());
        }
    }
}
