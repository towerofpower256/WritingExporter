using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common.Events
{
    public class ConfigurationSectionUpdatedEvent : IEvent
    {
        /// <summary>
        /// Name of the section that was updated.
        /// </summary>
        public string SectionName { get; private set; }

        /// <summary>
        /// Quick and type-safe method of checking if the updated section is of a type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsSectionType(Type type)
        {
            return string.Equals(type.Name, SectionName);
        }

        public ConfigurationSectionUpdatedEvent(string sectionName)
        {
            this.SectionName = sectionName;
        }
    }
}
