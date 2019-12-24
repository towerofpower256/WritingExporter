using System;
using System.Collections.Generic;
using System.Text;

namespace WritingExporter.Common.WDC
{
    [Serializable]
    public class WdcReaderSettings
    {
        public string InteractiveTitleRegex { get; set; }

        public string InteractiveShortDescriptionRegex { get; set; }

        public string InteractiveDescriptionRegex { get; set; }

        public string InteractiveAuthorRegex { get; set; }

        public string ChapterTitleRegex { get; set; }

        public string ChapterSourceChoiceRegex { get; set; }

        public string ChapterContentRegex { get; set; }

        public string ChapterAuthorChunkRegex { get; set; }

        public string ChapterAuthorUsernameRegex { get; set; }

        public string ChapterAuthorNameRegex { get; set; }

        public string ChapterChoicesChunkRegex { get; set; }

        public string ChapterChoicesRegex { get; set; }

        public string ChapterChoiceUrlRegex { get; set; }

        public string ChapterEndCheckRegex { get; set; }

        public WdcReaderSettings()
        {
            // Set defaults
            InteractiveTitleRegex = "(?<=<title>).+?(?= - Writing\\.Com<\\/title>)";
            InteractiveShortDescriptionRegex = "(?<=<META NAME=\"description\" content=\").+?(?=\">)";
            InteractiveDescriptionRegex = "(?<=<td align=left class=\"norm\">).+?(?=<\\/td>)";
            ChapterTitleRegex = @"(?<=<title>).*?(?=<\/title>)";
            ChapterSourceChoiceRegex = @"(?<=This choice: <b>).*?(?=<\/b>)";
            ChapterContentRegex = "(?<=<div class=\"\">).+?(?=<\\/div>)";
            ChapterAuthorChunkRegex = "<a title=\" Username: .*?<\\/a>";
            ChapterAuthorUsernameRegex = "(?<=Username: )[a-zA-Z]+";
            ChapterAuthorNameRegex = "(?<=>).+?(?=<)";
            ChapterChoicesChunkRegex = "(?<=<b>You have the following choice(s)?:<\\/b>).*?(?=<\\/div><div id=\"end_of_choices\")" ;
            ChapterChoicesRegex = "<a .*?href=\".+?\">.+?<\\/a>";
            ChapterChoiceUrlRegex = "(?<=href=\").+?(?=\")";
            ChapterEndCheckRegex = ">You have come to the end of the story. You can:<\\/";
        }
    }
}
