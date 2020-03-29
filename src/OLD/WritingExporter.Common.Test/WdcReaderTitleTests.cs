using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingExporter.Common.Models;
using WritingExporter.Common.Exceptions;
using WritingExporter.Common.Wdc;

namespace WritingExporter.Common.Test
{
    [TestClass]
    public class WdcReaderTitleTests
    {
        public WdcReaderTitleTests()
        {
            TestUtil.SetupLogging();
        }

        [TestMethod]
        public void StoryChapterTest()
        {
            var reader = new WdcReader();

            // First page of Maddison's Freshman 15
            var expectedStoryTitle = "Madison's Freshman 15";
            var expectedChapter = "Madison's first night at college";

            var testTitle = "Madison&#39;s Freshman 15: Madison&#39;s first night at college - Writing.Com";

            var result = reader.ReadPageTitle(testTitle);

            Assert.AreEqual(expectedStoryTitle, result.StoryName);
            Assert.AreEqual(expectedChapter, result.PageName);
        }

        [TestMethod]
        public void StoryHomepageTest()
        {
            var reader = new WdcReader();

            // First page of Maddison's Freshman 15
            var expectedStoryTitle = "Madison's Freshman 15";
            var expectedChapter = string.Empty;

            var testTitle = "Madison&#39;s Freshman 15 - Writing.Com";

            var result = reader.ReadPageTitle(testTitle);

            Assert.AreEqual(expectedStoryTitle, result.StoryName);
            Assert.AreEqual(expectedChapter, result.PageName);
        }
    }
}
