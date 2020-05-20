using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WritingExporter.Common.Models;
using WritingExporter.Common.Data.Repositories;
using WritingExporter.Common.Logging;
using System.Xml.Serialization;
using System.Data;

namespace WritingExporter.Common.StorySaveLoad
{
    public class StorySaveLoadService
    {
        ILogger _log;
        WdcStoryRepository _storyRepo;
        WdcChapterRepository _chapterRepo;
        XmlSerializer _serializer;

        public StorySaveLoadService(ILoggerSource loggerSource, WdcStoryRepository storyRepo, WdcChapterRepository chapterRepo)
        {
            _log = loggerSource.GetLogger(typeof(StorySaveLoadService));
            _storyRepo = storyRepo;
            _chapterRepo = chapterRepo;

            _serializer = new XmlSerializer(typeof(StorySaveLoadWrapper));
        }

        /// <summary>
        /// Save a story to a file.
        /// </summary>
        /// <param name="storySysId">The story's sys_id</param>
        /// <param name="storyFilePath">The location to save the story</param>
        public void SaveStoryToFile(string storySysId, string storyFilePath)
        {
            _log.Debug($"Saving story {storySysId} to {storyFilePath}");

            var data = new StorySaveLoadWrapper();

            var story = _storyRepo.GetByID(storySysId);
            // TODO handle invalid story
            data.Story = story;

            data.Chapters = _chapterRepo.GetStoryChapters(storySysId).ToList();

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            using (var f = File.Open(storyFilePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                _serializer.Serialize(f, data, ns);
            }
        }

        /// <summary>
        /// Reads a saved story rfom a file, and loads it into data storage.
        /// </summary>
        /// <param name="storyFilePath"></param>
        /// <returns></returns>
        public SaveLoadStoryLoadResult LoadStoryFromFile(string storyFilePath, bool abortIfStoryExists = true)
        {
            _log.Debug($"Loading story from {storyFilePath}");

            // TODO mark the story's state as being imported somehow, to prevent collisions with the sync worker and whatnot

            var result = new SaveLoadStoryLoadResult();

            StorySaveLoadWrapper data;
            using (var f = File.Open(storyFilePath, FileMode.Open, FileAccess.Read))
            {
                data = (StorySaveLoadWrapper)_serializer.Deserialize(f);
            }

            var newStory = data.Story;
            var existingStory = _storyRepo.GetByStoryID(newStory.Id);
            if (existingStory != null) {
                // Replace the existing story record with the file's details
                newStory.SysId = existingStory.SysId;
                _storyRepo.Save(newStory);
            }
            else
            {
                // Insert the new story
                _storyRepo.Add(newStory);
            }

            var storySysId = newStory.SysId;
            result.StorySysId = storySysId;
            result.StoryId = newStory.Id;
            result.StoryName = newStory.Name;


            // For each chapter, see if it already exists.
            // If it does, merge the changes
            var storyOutline = _chapterRepo.GetStoryOutline(storySysId);
            foreach (var newChapter in data.Chapters)
            {
                // TODO would be better to grab the chapters in a batch, instead of hitting the DB one by one

                var existingChapter = storyOutline.FirstOrDefault(c => c.Path == newChapter.Path);
                if (existingChapter != null)
                {
                    // Replace the existing chapter
                    newChapter.SysId = existingChapter.SysId;
                    _chapterRepo.Save(newChapter);
                    result.ChaptersInserted++;
                }
                else
                {
                    // Insert the new chapter
                    _chapterRepo.Add(newChapter);
                    result.ChaptersUpdated++;
                }
            }

            return result;
        }

        public StorySaveLoadWrapper OpenStoryFromFile(string storyFilePath)
        {
            _log.Debug($"Opening story from {storyFilePath}");

            StorySaveLoadWrapper data;
            using (var f = File.Open(storyFilePath, FileMode.Open, FileAccess.Read))
            {
                data = (StorySaveLoadWrapper)_serializer.Deserialize(f);
            }

            return data;
        }

        public string GetDefaultFileExtension()
        {
            return ".xml";
        }
    }

    public class SaveLoadStoryLoadResult
    {
        public string StoryId { get; set; }

        public string StorySysId { get; set; }

        public string StoryName { get; set; }

        public int ChaptersUpdated { get; set; } = 0;

        public int ChaptersInserted { get; set; } = 0;
    }
}
