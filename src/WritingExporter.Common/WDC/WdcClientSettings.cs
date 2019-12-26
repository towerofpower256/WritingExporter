using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.WDC
{
    public class WdcClientSettings
    {
        public string UrlRoot { get; set; }


        public WdcClientSettings()
        {
            //Set defaults
            UrlRoot = "https://www.writing.com/";

        }
    }
}
