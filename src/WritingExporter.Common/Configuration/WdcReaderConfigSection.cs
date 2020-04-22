using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Wdc;

namespace WritingExporter.Common.Configuration
{
    [Serializable]
    public class WdcReaderConfigSection : BaseConfigSection
    {
        public WdcReaderOptions ReaderOptions { get; set; } = new WdcReaderOptions();
    }
}
