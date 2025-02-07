using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFLesonsAndTasksPart8FilleSystem
{
    internal class Drive
    {
        enum DriveType
        {
            USB,
            HDD,
            CD
        }
        public Drive(string name, long totalSpace, long freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }

        public string Name { get; }
        public long TotalSpace { get; }
        public long FreeSpace { get; }

    }

    internal class SystemDrive : Drive
    {
        public SystemDrive(string name, long totalSpace, long freeSpace, long reservedSpace) : base(name, totalSpace, freeSpace)
        {
            long ReservedSpace = reservedSpace;

        }
        public long ReservedSpace { get; }
    }
}
