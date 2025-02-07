using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace SFLesonsAndTasksPart8FilleSystem
{
    internal class SFLessons82
    {
        public static void GetCatalogs()
        {
            string dirName = @"C:\"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога
                int dCounter = 0;
                for (int i = 0; i < dirs.Length; i++)
                {
                    Console.WriteLine(dirs[i]);
                }
                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }
        }
        public static void CalcFSObjects()
        {
            string dirName = @"C:\";
            string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога
            int counter = 0;
            for (int i = 0; i < dirs.Length; i++)
            {
                counter++;
            }
            string[] files = Directory.GetFiles(dirName);
            for (int i = 0; i < files.Length; i++)
            {
                counter++;
            }
            Console.WriteLine("Количество элементов на диске {0} = {1}", dirName, counter);
        }
        // Задание 8.2.2
        public static void CalcByTry()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\" /* Или С:\\ для Windows */ );
                if (dirInfo.Exists)
                {
                    Console.WriteLine("Количество до: " + dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }
                DirectoryInfo dirInfo2 = new DirectoryInfo(@"C:\Тестовая папка" /* Или С:\\ для Windows */ );
                if (!dirInfo2.Exists)
                {
                    dirInfo2.Create();
                    Console.WriteLine("Количество после: " + dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void CreateFolder(string newFolder)
        {
            try
            {
                DirectoryInfo dirInfo2 = new DirectoryInfo(newFolder);
                if (!dirInfo2.Exists)
                {
                    dirInfo2.Create();
                    Console.WriteLine("Каталог " + newFolder + " создан");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //DInfo(newFolder);
        }
        public static void DInfo(string newFolder)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(newFolder);
            Console.WriteLine($"Название каталога: {dirInfo.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
            //DelDir(newFolder);
        }
        // Задание 8.2.3
        public static void DelDir(string newFolder)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(newFolder);
                dirInfo.Delete(true); // Удаление со всем содержимым
                Console.WriteLine("Каталог {0} удален", newFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MoveDir(string oldPath, string newPath)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(oldPath);

                if (!dirInfo.Exists)
                {
                    Console.WriteLine("Каталог {0} не найден - создаем", oldPath);
                    dirInfo.Create();
                }
                if (dirInfo.Exists && !Directory.Exists(newPath))
                {
                    dirInfo.MoveTo(newPath);
                }
                Console.WriteLine("Каталог {0} перемещен в {1}", oldPath, newPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void DesktopFolder()
        {
            //Задание 8.2.4
            //Метод создает каталог на рабочем столе пользователя с именеме указанным в переменной newFolder
            //после чего удаляет этот каталог в корзину
            string newFolder = "Каталог на рабочем столе";
            try 
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newFolder));
                if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newFolder)) == true)
                {
                    Console.WriteLine("Каталог - \" {0} \" успешно создан в расположении:\n" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), newFolder);
                }
                FileSystem.DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newFolder), 
                    UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newFolder)) == false)
                {
                    Console.WriteLine("Каталог - \" {0} \" успешно преренесен в Корзину из расположения:\n" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), newFolder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
