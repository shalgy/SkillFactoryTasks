//Время последнего запуска программы: 8 февраля 2025 г. 0:19:37
//Время последнего запуска программы: 7 февраля 2025 г. 17:29:49
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SFLesonsAndTasksPart8FilleSystem
{
    internal class SFLessons83
    {
        public static class FileWriter
        {
            public static void TestWriter()
            {
                string filePath = @"D:\Students.txt"; // Укажем путь 
                if (!File.Exists(filePath)) // Проверим, существует ли файл по данному пути
                {
                    //   Если не существует - создаём и записываем в строку
                    using (StreamWriter sw = File.CreateText(filePath))  // Конструкция Using (будет рассмотрена в последующих юнитах)
                    {
                        sw.WriteLine("Олег");
                        sw.WriteLine("Дмитрий");
                        sw.WriteLine("Иван");
                    }
                }
                // Откроем файл и прочитаем его содержимое
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            //_______________________________________________________________________________________________________
            //Задание 8.3.1
            //Напишите программу, которая выводит свой собственный исходный код в консоль.
            public static void SelfCodeKeeper()
            {
                string? filePath = GetThisFilePath();

                if (filePath is not null && File.Exists(filePath)) // Проверим, существует ли файл по данному пути
                {
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        string str = "";
                        while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
                        {
                            Console.WriteLine(str);
                        }
                    }
                }
                else 
                {
                    Console.WriteLine("Что-то не понятно, заданого файла: \" {0} \" - не существует", filePath);
                }
            }
            //Метод возвращает путь к файлу из которого вызван метод
            private static string GetThisFilePath([CallerFilePath] string? path = null)
            {
                return path;
            }
            //_____________________________________________________________________________________________________
            //
            public static void WorkWithFile()
            {
                string tempFile = Path.GetTempFileName(); // используем генерацию имени файла.
                var fileInfo = new FileInfo(tempFile); // Создаем объект класса FileInfo.

                //Создаем файл и записываем в него.
                using (StreamWriter sw = fileInfo.CreateText())
                {
                    sw.WriteLine("Игорь");
                    sw.WriteLine("Андрей");
                    sw.WriteLine("Сергей");
                }

                //Открываем файл и читаем из него.
                using (StreamReader sr = fileInfo.OpenText())
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(str);
                    }
                }

                try
                {
                    string tempFile2 = Path.GetTempFileName();
                    var fileInfo2 = new FileInfo(tempFile2);

                    // Убедимся, что файл назначения точно отсутствует
                    fileInfo2.Delete();

                    // Копируем информацию
                    fileInfo.CopyTo(tempFile2);
                    Console.WriteLine($"{tempFile} скопирован в файл {tempFile2}.");
                    //Удаляем ранее созданный файл.
                    fileInfo.Delete();
                    Console.WriteLine($"{tempFile} удален.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e}");
                }
            }
            //_____________________________________________________________________________________________________________________________________
            //Задание 8.3.2
            //Сделайте так, чтобы ваша программа из задания 8.3.1 при каждом запуске добавляла в свой исходный код комментарий о времени последнего запуска.
            public static void SelfCodeLaastRunTimeWriter()
            {
                string? filePath = GetThisFilePath(); //Получаем расположение файла с кодом, для этого используем метод

                if (filePath is not null && File.Exists(filePath)) // Проверим, существует ли файл с кодом программы по данному пути
                {
                    string tempFile = Path.GetTempFileName(); // используем генерацию имени временного файла.
                    var fileToWrite = new FileInfo(tempFile); // Создаем объект класса FileInfo.
                    string curDate = @"//Время последнего запуска программы: " + $"{DateTime.Now:F}"; //Вычисляем текущую дату и время, форматируем его в строку
                    using (StreamWriter swriter = fileToWrite.CreateText()) // Открываем временный файл для записи
                    {
                        using (StreamReader sreader = File.OpenText(filePath)) // Открываем файл с кодом программы для чтения
                        {
                            swriter.WriteLine(curDate); // Записываем во временный файл отформатированную строку с текущей датой и временем
                            swriter.Write(sreader.ReadToEnd()); // Считываем содержимое файла с кодом и записываем его во временный файл
                        }
                    }
                    
                    using StreamReader sreader2 = File.OpenText(tempFile);
                    {
                        string str = "";
                        Console.WriteLine("Вывод содержимого временного файла: \n" + tempFile + "\n");
                        while ((str = sreader2.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
                        {
                            Console.WriteLine(str);
                        }
                    }

                    try
                    {
                        var fileInfo = new FileInfo(filePath); //Получаем файл с кодом программы
                        // Убедимся, что файл назначения с кодом программы точно отсутствует
                        fileInfo.Delete();

                        // Копируем временный файл в файл с кодом программы
                        fileToWrite.CopyTo(filePath);
                        Console.WriteLine($"{tempFile} скопирован в файл {filePath}.");
                        //Удаляем ранее созданный временный файл.
                        fileToWrite.Delete();
                        Console.WriteLine($"{tempFile} удален.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка: {e}");
                    }

                }
                else
                {
                    Console.WriteLine("Что-то не понятно, заданого файла: \" {0} \" - не существует", filePath);
                }
            }


            //_____________________________________________________________________________________________________________________________________
            //Задание 8.3.2
            //Сделайте так, чтобы ваша программа из задания 8.3.1 при каждом запуске добавляла в свой исходный код комментарий о времени последнего запуска.
            public static void SelfCodeLaastRunTimeWriter2()
            {
                
                var fileInfo = new FileInfo(GetThisFilePath());

                using (StreamWriter sw = fileInfo.AppendText())
                {
                    sw.WriteLine($"// Время запуска: {DateTime.Now}");
                }

                using (StreamReader sr = fileInfo.OpenText())
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null)
                        Console.WriteLine(str);

                }


            }



        }

    }
}

// Время запуска: 10.02.2025 8:42:40
// Время запуска: 10.02.2025 8:43:11
