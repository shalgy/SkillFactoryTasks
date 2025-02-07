﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SFLesonsAndTasksPart8FilleSystem
{
    internal class Folder
    {
        public Folder(string name)
        {
            Name = name;
        }

        string Name { get; set; }
        List<string> Files { get; set; } = new List<string>();

        public void AddFile(string name)
        {
            if (!Files.Contains(name))
            {
                Files.Add(name);
            }
                
        }
    }
}
