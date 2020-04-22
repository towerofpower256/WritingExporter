using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingExporter.Common
{
    public static class SysUtil
    {
        public const string GUID_FORMAT = "N";

        public static string GenerateGuidString()
        {
            return Guid.NewGuid().ToString(GUID_FORMAT);
        }

        public static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }
    }
}
