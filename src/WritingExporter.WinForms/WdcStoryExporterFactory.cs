using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using WritingExporter.Common.Export;
using WritingExporter.Common.Logging;

namespace WritingExporter.WinForms
{
    public class WdcStoryExporterFactory
    {
        Container _container;

        public WdcStoryExporterFactory(Container container)
        {
            _container = container;
        }

        public IWdcStoryExporter GetExporter()
        {
            return _container.GetInstance<IWdcStoryExporter>();
        }
    }
}
