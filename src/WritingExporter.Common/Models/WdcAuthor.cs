using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Models
{
    [Serializable]
    public class WdcAuthor
    {
        public string SysId { get; set; } = SysUtil.GenerateGuidString();

        public string Name { get; set; }

        public string Username { get; set; }
    }
}
