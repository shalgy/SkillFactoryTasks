using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using SFLesonsAndTasksPart8FilleSystem;
using System.Runtime.Serialization.Formatters.Binary;
using MessagePack;

namespace SFLesonsAndTasksPart8FilleSystem
{
    

    internal class SFLessons84
    {
        //Задание 8.4.1 и 8.4.2
        public static void ReadBinFromDesktop()
        {
            string fpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\BinaryFile.bin";
            string StringValue;
            string StringToAppendValue = $"Файл изменен {(DateTime.Now).ToString("dd.MM HH:mm")} на компьютере Windows 10";
            Console.WriteLine(StringToAppendValue);
            if (File.Exists(fpath))
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fpath, FileMode.Append)))
                {
                    // Записываем данные в разном формате
                    writer.Write(StringToAppendValue);
                }
                // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
                Console.WriteLine("Из файла считано:");
                using (BinaryReader reader = new BinaryReader(File.Open(fpath, FileMode.Open)))
                {
                    // Применяем специализированные методы Read для считывания соответствующего типа данных
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        Console.WriteLine(reader.ReadString());
                    }

                }
                
                
             }

        }

        //Json серилизация
        public static void WriteJsonContact()
        {
            string jsonpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\myContacts.json";
            var contact = new Сontact("Василий", 9067579400, "pupkin@mail.ru");
            Console.WriteLine("Объект создан");
            // Сериализация
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(contact, options);
            File.WriteAllText(jsonpath, jsonString);
            Console.WriteLine("Объект сериализован");

            // Десериализация
            jsonString = File.ReadAllText(jsonpath);
            var newContact = JsonSerializer.Deserialize<Сontact>(jsonString);
            Console.WriteLine("Объект десериализован");

            Console.WriteLine($"Имя: {newContact.Name} --- Телефон: {newContact.PhoneNumber} --- E-Mail: {newContact.Email}");
            Console.ReadLine();
        }

        //Бинарная серилизация
        public static void WriteBinaryContact()
        {
            string binpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + @"\myContacts.bin";
            var contact = new Сontact("Василий", 9067579400, "pupkin@mail.ru");
            Console.WriteLine("Объект создан");
            // Бинарная сериализация
            using (FileStream fs = new FileStream(binpath, FileMode.Create))
            using (BinaryWriter bwriter = new BinaryWriter(fs))
            {
                contact.Serialize(bwriter);
            }
            Console.WriteLine("Объект сериализован");

            // Десериализация
            Сontact newContact;
            using (FileStream fs = new FileStream(binpath, FileMode.Open))
            using (BinaryReader breader = new BinaryReader(fs))
            {
                newContact = Сontact.Deserialize(breader);
            }
            Console.WriteLine("Объект десериализован");

            Console.WriteLine($"Имя: {newContact.Name} --- Телефон: {newContact.PhoneNumber} --- E-Mail: {newContact.Email}");
            Console.ReadLine();
        }
    }
    [Serializable]
    public class Сontact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Сontact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        // Метод для сериализации объекта в бинарный формат
        public void Serialize(BinaryWriter bwriter)
        {
            bwriter.Write(Name);
            bwriter.Write(PhoneNumber);
            bwriter.Write(Email);
        }

        // Метод для десериализации объекта из бинарного формата
        public static Сontact Deserialize(BinaryReader breader)
        {
            string name = breader.ReadString();
            long phoneNumber = breader.ReadInt64();
            string email = breader.ReadString();

            return new Сontact(name, phoneNumber, email);
        }
    }
}
