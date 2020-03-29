﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.StorySync
{
    /// <summary>
    /// The sync status of a story. Used by the sync worker to keep track of the status of a story's sync status and progress.
    /// </summary>
    [Serializable]
    public class StorySyncWorkerStoryStatus
    {
        public string StoryID { get; set; }
        public StorySyncWorkerStoryState State { get; set; } = StorySyncWorkerStoryState.Idle;
        public string ErrorMessage { get; set; } // If there was an error, store it here
        public DateTime StateLastSet { get; set; } = DateTime.Now; // When the state was last set. For use with "wait after a story enters X state"
        public DateTime LastItu { get; set; } = DateTime.Now; // The last time that "interactives temporarily unavailable" was encountered for this story
        public int ProgressValue { get; set; } = 0;
        public int ProgressMax { get; set; } = 0;
    }

    public enum StorySyncWorkerStoryState
    {
        Idle,
        Error,
        Working,
        Paused,
        WaitingItu
    }
}
