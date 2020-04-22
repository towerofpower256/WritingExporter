using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Configuration
{
    [Serializable]
    public class WdcClientConfigSection : BaseConfigSection
    {
        public string WritingUsername { get; set; }

        public string WritingPassword { get; set; }
    }
}
