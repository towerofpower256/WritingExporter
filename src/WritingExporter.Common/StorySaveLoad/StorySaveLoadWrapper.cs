using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Models;

namespace WritingExporter.Common.StorySaveLoad
{
    [Serializable]
    public class StorySaveLoadWrapper
    {
        public WdcStory Story { get; set; }

        public List<WdcChapter> Chapters { get; set; } = new List<WdcChapter>();
    }
}
