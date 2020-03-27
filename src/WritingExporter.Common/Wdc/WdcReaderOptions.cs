﻿namespace WritingExporter.Common.Wdc
{
    public class WdcReaderOptions
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
        public const string ChapterChoicesChunkRegexDefault = "(?<=<b>You have the following choice(s)?:<\\/b>).*?(?=<\\/div><div id=\"end_of_choices\")";
        public const string ChapterChoicesRegexDefault = "<a .*?href=\".+?\">.+?<\\/a>";
        public const string ChapterChoiceUrlRegexDefault = "(?<=href=\").+?(?=\")";
        public const string ChapterEndCheckRegexDefault = ">You have come to the end of the story. You can:<\\/";

        public string InteractiveTitleRegex { get; set; } = InteractiveTitleRegexDefault;

        public string InteractiveShortDescriptionRegex { get; set; } = InteractiveShortDescriptionRegexDefault;

        public string InteractiveDescriptionRegex { get; set; } = InteractiveDescriptionRegexDefault;

        public string ChapterTitleRegex { get; set; } = ChapterTitleRegexDefault;

        public string ChapterSourceChoiceRegex { get; set; } = ChapterSourceChoiceRegexDefault;

        public string ChapterContentRegex { get; set; } = ChapterContentRegexDefault;

        public string ChapterAuthorChunkRegex { get; set; } = ChapterAuthorChunkRegexDefault;

        public string ChapterAuthorUsernameRegex { get; set; } = ChapterAuthorUsernameRegexDefault;

        public string ChapterAuthorNameRegex { get; set; } = ChapterAuthorNameRegexDefault;

        public string ChapterChoicesChunkRegex { get; set; } = ChapterChoicesChunkRegexDefault;

        public string ChapterChoicesRegex { get; set; } = ChapterChoicesRegexDefault;

        public string ChapterChoiceUrlRegex { get; set; } = ChapterChoiceUrlRegexDefault;

        public string ChapterEndCheckRegex { get; set; } = ChapterEndCheckRegexDefault;
    }
}