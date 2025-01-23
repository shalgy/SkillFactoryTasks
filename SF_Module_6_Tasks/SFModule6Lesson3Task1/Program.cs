using System;

namespace SF_Module_6_start
    //Напишите такой код, который бы при типе компании, равному типу "Банк", и городе "Санкт-Петербург" выводил в консоль сообщение 
    //"У банка ??? есть отделение в Санкт-Петербурге", где вместо "???" выводилось бы название компании.
    //Если у компании нет названия, вместо него должно быть "Неизвестная компания".
{
    class Company
    {
        public string Type;
        public string Name;
    }

    class Department
    {
        public Company Company;
        public City City;
    }

    class City
    {
        public string Name;
    }

    class Bus
        //Для класса Bus реализуйте метод PrintStatus, который будет сообщать о количестве пассажиров в автобусе, если они есть.Или сообщать, что автобус пуст.
    {
        public int? Load;

        public void PrintStatus()
        {
            if (Load.HasValue && Load > 0) { Console.WriteLine("В автобусе {0} пассажиров", Load.Value); }
            else { Console.WriteLine("Автобус пуст"); }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var department = GetCurrentDepartment();
        }

        static Department GetCurrentDepartment()
        {

            var department = new Department() { City = new City(), Company = new Company() };

            if (department?.Company?.Type == "Банк" && department?.City?.Name == "Санкт-Петербург")
            {
                Console.WriteLine("У банка {0} есть отделение в Санкт-Петербурге", department?.Company?.Name ?? "Неизвестная компания");
            }
            return department;
        }
    }
}