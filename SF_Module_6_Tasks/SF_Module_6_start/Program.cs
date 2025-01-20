using System;

namespace SF_Module_6_start
{
    class Human
    {

        // Поля класса
        public string name;
        public int age;

        // Метод класса
        public void Greetings()
        {
            Console.WriteLine("Меня зовут {0}, мне {1}", name, age);
        }
        // Конструктор 1
        public Human()
        {
            name = "Неизвестно";
            age = 20;
        }
        // Конструктор 2
        public Human(string n)
        {
            name = n;
            age = 20;
        }
        // Конструктор 3
        public Human(string n, int a)
        {
            name = n;
            age = a;
        }


    }

    struct Animal
    {
        // Поля структуры
        public string type;
        public string name;
        public int age;

        // Конструктор 1
        public Animal()
        {
            type = "не установлен";
            name = "не установлено";
            age = 0;
        }

        // Конструктор 2
        public Animal(string anType, string anName, int anAge)
        {
            type = anType;
            name = anName;
            age = anAge;
        }
        // Метод структуры
        public void Info()
        {
            Console.WriteLine("Это {0} по кличке {1}, ему {2}", type, name, age);
        }
    }
    
    class Rectangle
    {
        public int a;
        public int b;

        public Rectangle()
        {
            a = 6;
            b = 4;
        }

        public Rectangle(int oneside)
        {
            a = oneside;
            b = oneside;
        }

        public Rectangle(int aside, int bside)
        {
            a = aside;
            b = bside;
        }
        public int Square() { return a * b; }
    }


    class Program
    {
        class Pen
        {
            public string color;
            public int cost;
            // Конструктор 1
            public Pen()
            {
                color = "Черный";
                cost = 100;
            }
            // Конструктор 2
            public Pen(string penColor, int penCost)
            {
                color = penColor;
                cost = penCost;
            }
        }
        static void Main(string[] args)
        {

            Rectangle rct = new() { a = 7, b = 12 };
            Console.WriteLine(rct.Square());
            //Пример использования инициализатора
            Human human = new() { name = "Вася Пупкин", age = 40 };
            human.Greetings();

            //Задание 6.2.3 Инициализатор для структуры Animal
            Animal dog = new() { type = "Собака", name = "Вольт", age = 4 };


            Console.ReadKey();
        }
    }
}