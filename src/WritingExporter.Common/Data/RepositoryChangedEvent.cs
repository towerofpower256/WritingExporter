using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingExporter.Common.Events;

namespace WritingExporter.Common.Data
{
    public class RepositoryChangedEvent : IEvent
    {
        public RepositoryChangedEventType ChangeType { get; set; }

        public IEnumerable<string> EntityIds { get; set; }

        public Type RepositoryType { get; set; }

        public RepositoryChangedEvent(RepositoryChangedEventType changeType, IEnumerable<string> entityIds, Type repositoryType)
        {
            ChangeType = changeType;
            EntityIds = entityIds;
            RepositoryType = repositoryType;
        }
    }

    public enum RepositoryChangedEventType
    {
        Add,
        Update,
        Delete
    }
}
