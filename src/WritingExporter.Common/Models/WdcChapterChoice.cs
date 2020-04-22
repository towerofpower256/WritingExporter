using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Models
{
    [Serializable]
    public class WdcChapterChoice
    {
        public string SysId { get; set; } = SysUtil.GenerateGuidString();

        public string ChapterId { get; set; }

        public string PathLink { get; set; }

        public string Name { get; set; }
    }
}
