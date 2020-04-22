using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Configuration;

namespace WritingExporter.Common.Wdc
{
    public class WdcReaderFactory
    {
        ConfigService _config;

        public WdcReaderFactory(ConfigService config)
        {
            _config = config;
        }

        public WdcReader GetReader()
        {
            var options = _config.GetSection<WdcReaderConfigSection>().ReaderOptions;

            var reader = new WdcReader(options);

            return reader;
        }
    }
}
