using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WritingExporter.Common.Models
{
    [Serializable]
    public class WdcChapter
    {
        private static XmlSerializer _chapterChoiceSerializer;
        private static XmlSerializerNamespaces _chapterChoiceSerializerNs;

        public static WdcChapterChoiceCollection ChoiceValueToChoiceList(string v)
        {
            using (var reader = new StringReader(v))
            {
                return (WdcChapterChoiceCollection)_chapterChoiceSerializer.Deserialize(reader);
            }
        }

        public static string ChoiceListToChoiceValue(WdcChapterChoiceCollection choiceList)
        {
            using (var writer = new StringWriter())
            {
                _chapterChoiceSerializer.Serialize(writer, choiceList, _chapterChoiceSerializerNs);
                return writer.ToString();
            }
        }

        static WdcChapter()
        {
            _chapterChoiceSerializer = new XmlSerializer(typeof(WdcChapterChoiceCollection));
            _chapterChoiceSerializerNs = new XmlSerializerNamespaces();
            _chapterChoiceSerializerNs.Add(string.Empty, string.Empty);
        }

        public string SysId { get; set; } = SysUtil.GenerateGuidString();

        public string StoryId { get; set; }

        public string Path { get; set; }

        public string Title { get; set; }

        public string SourceChoiceTitle { get; set; } // Yes, we will to save this, because sometimes it's different from the title

        public string AuthorName { get; set; } // The author, not sure if it changes with edits

        public string AuthorUsername { get; set; } // The author, not sure if it changes with edits

        public string Content { get; set; } // The content / writing of the chapter, the flesh of it

        public bool IsEnd { get; set; } = false; // Is this chapter a dead end in the story tree

        public DateTime LastSynced { get; set; }

        public DateTime LastUpdated { get; set; }

        public DateTime FirstSeen { get; set; }

        public WdcChapterChoiceCollection Choices = new WdcChapterChoiceCollection();

        public string ChoicesString
        {
            get { return ChoiceListToChoiceValue(this.Choices); }
            set { this.Choices = ChoiceValueToChoiceList(value); }
        }
    }
}
