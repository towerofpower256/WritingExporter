using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Configuration
{
    [Serializable]
    public class WdcReaderConfiguration : BaseConfigSection
    {
        public const string InteractiveTitleRegexDefault = "(?<=<title>).+?(?= - Writing\\.Com<\\/title>)";
        public const string InteractiveShortDescriptionRegexDefault = "(?<=<META NAME=\"description\" content=\").+?(?=\">)";
        public const string InteractiveDescriptionRegexDefault = "(?<=<td align=left class=\"norm\">).+?(?=<\\/td>)";
        public const string InteractiveAuthorRegexDefault = "";
        public const string ChapterTitleRegexDefault = @"(?<=<title>).*?(?=<\/title>)";
        public const string ChapterSourceChoiceRegexDefault = @"(?<=This choice: <b>).*?(?=<\/b>)";
        public const string ChapterContentRegexDefault = "(?<=<div class=\"\">).+?(?=<\\/div>)";
        public const string ChapterAuthorChunkRegexDefault = "<a title=\" Username: .*?<\\/a>";
        public const string ChapterAuthorUsernameRegexDefault = "(?<=Username: )[a-zA-Z]+";
        public const string ChapterAuthorNameRegexDefault = "(?<=>).+?(?=<)";
        public const string ChapterChoicesChunkRegexDefault = "(?<=<b>You have the following choice(s)?:<\\/b>).*?(?=<\\/div><div id=\"end_of_choices\")" ;
        public const string ChapterChoicesRegexDefault = "<a .*?href=\".+?\">.+?<\\/a>";
        public const string ChapterChoiceUrlRegexDefault = "(?<=href=\").+?(?=\")";
        public const string ChapterEndCheckRegexDefault = ">You have come to the end of the story. You can:<\\/";

        public bool InteractiveTitleRegexOverride { get; set; } = false;

        public string InteractiveTitleRegex { get; set; } = InteractiveTitleRegexDefault;

        public bool InteractiveShortDescriptionRegexOverride { get; set; } = false;

        public string InteractiveShortDescriptionRegex { get; set; } = InteractiveShortDescriptionRegexDefault;

        public bool InteractiveDescriptionRegexOverride { get; set; } = false;

        public string InteractiveDescriptionRegex { get; set; } = InteractiveDescriptionRegexDefault;

        public bool InteractiveAuthorRegexOverride { get; set; } = false;

        public string InteractiveAuthorRegex { get; set; } = InteractiveAuthorRegexDefault;

        public bool ChapterTitleRegexOverride { get; set; } = false;

        public string ChapterTitleRegex { get; set; } = ChapterTitleRegexDefault;

        public bool ChapterSourceChoiceRegexOverride { get; set; } = false;

        public string ChapterSourceChoiceRegex { get; set; } = ChapterSourceChoiceRegexDefault;

        public bool ChapterContentRegexOverride { get; set; } = false;

        public string ChapterContentRegex { get; set; } = ChapterContentRegexDefault;

        public bool ChapterAuthorChunkRegexOverride { get; set; } = false;

        public string ChapterAuthorChunkRegex { get; set; } = ChapterAuthorChunkRegexDefault;

        public bool ChapterAuthorUsernameRegexOverride { get; set; } = false;

        public string ChapterAuthorUsernameRegex { get; set; } = ChapterAuthorUsernameRegexDefault;

        public bool ChapterAuthorNameRegexOverride { get; set; } = false;

        public string ChapterAuthorNameRegex { get; set; } = ChapterAuthorNameRegexDefault;

        public bool ChapterChoicesChunkRegexOverride { get; set; } = false;

        public string ChapterChoicesChunkRegex { get; set; } = ChapterChoicesRegexDefault;

        public bool ChapterChoicesRegexOverride { get; set; } = false;

        public string ChapterChoicesRegex { get; set; } = ChapterChoicesRegexDefault;

        public bool ChapterChoicesUrlRegexOverride { get; set; } = false;

        public string ChapterChoiceUrlRegex { get; set; } = ChapterChoiceUrlRegexDefault;

        public bool ChapterEndCheckRegexOverride { get; set; } = false;

        public string ChapterEndCheckRegex { get; set; } = ChapterEndCheckRegexDefault;
    }
}
