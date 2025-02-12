using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static SFLesonsAndTasksPart8FilleSystem.DirectoryExtension;

namespace SFLesonsAndTasksPart8FilleSystem
{
    internal static class FileScaner
    {
        internal static void MakeDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives) 
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    WriteDriveInfo(drive);
                    DirectoryInfo root = drive.RootDirectory;
                    DirectoryInfo[] folders = root.GetDirectories();

                    WriteFolderInfo(folders);

                    Console.WriteLine();
                    Console.WriteLine();
                }
                
            }
        }

        public static void WriteDriveInfo(DriveInfo drive)
        {
            Console.WriteLine($"Название: {drive.Name}");
            Console.WriteLine($"Тип: {drive.DriveType}");
            if (drive.IsReady)
            {
                Console.WriteLine($"Объем: {drive.TotalSize}");
                Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                Console.WriteLine($"Метка: {drive.VolumeLabel}");
            }
        }

        public static void WriteFolderInfo(DirectoryInfo[] folders)
        {
            Console.WriteLine();
            Console.WriteLine($"Папки: ");
            Console.WriteLine();

            foreach (var folder  in folders)
            {
                try
                {
                    Console.WriteLine(folder.Name + $" - {DirectoryExtension.DirSize(folder)}байт");
                }
                catch (Exception e)
                {
                    Console.WriteLine(folder.Name + $" - Не удалось рассчитать размер: {e.Message}");
                }

            }
        }

        public static void WriteFileInfo(DirectoryInfo rootFolder)
        {
            Console.WriteLine();
            Console.WriteLine($"Файлы: ");
            Console.WriteLine();

            foreach (var file in rootFolder.GetFiles())
            {
                Console.WriteLine(file.Name + $" - {file.Length} байт");

            }
        }
    }

}
