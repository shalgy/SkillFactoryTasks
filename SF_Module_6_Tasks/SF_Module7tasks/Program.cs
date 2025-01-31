using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SF_Module7tasks
{
    //class SmartHelper
    //{
    //    private string name;

    //    public SmartHelper(string name)
    //    {
    //        this.name = name;
    //    }

    //    public void Greetings(string name)
    //    {
    //        Console.WriteLine("Привет, {0}, я интеллектуальный помощник {1}", name, this.name);
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //SmartHelper helper = new SmartHelper("Олег");
    //        //helper.Greetings("Грег");

    //        Console.ReadKey();
    //    }

    //}
    class Creature { }

    class Animal : Creature { }

    class Human : Creature { }

    class HomoSapiens : Human { }
    class Helper 
    {
        public static void Swap(ref int num1, ref int num2)
        {
            int value;
            value = num1;
            num1 = num2;
            num2 = value;
        }
    }

    static class StringExtensions
    {
        public static char GetLastChar(this string source)
        {
            return source[source.Length - 1];
        }
    }

    static class IntExtensions
    {
        public static int GetNegative(this int source)
        {
            return source < 0 ? source : source * -1;
        }
        public static int GetPositive(this int source)
        {
            return source > 0 ? source : source * -1;
        }
        //public static int GetNegative(this int source)
        //{
        //    return source > 0 ? - source : source;
        //}
        //public static int GetPositive(this int source)
        //{
        //    return source < 0 ? - source : source;
        //}
    }
    class Program
    {
        public static void Swap<T>(ref T x, ref T y)
        {
            T t = x;
            x = y;
            y = t;
        }

        static void Main(string[] args)
        {
            Obj obj = new Obj();
            obj.Display<int>(345);

            Order<HomeDelivery> order1; // Все работает
            Order<int> order2;		// Ошибка при компиляции

            
            int num1 = 4;
            int num2 = 10;
            Swap<int>(ref num1, ref num2);

            Console.WriteLine("{0} {1}", num1, num2);

            Console.ReadKey();
            //bool exit = false;
            //do
            //{
            //    Console.WriteLine("Введите целочисленное значение и нажмите Ввод, для выхода из программы наберите exit и нажмите Ввод");
            //    var result = Console.ReadLine();
            //    if (result != "exit")
            //    {
            //        if (int.TryParse(result, out int intnum))
            //        {
            //            Console.WriteLine("Результат конвертирования в отрицательное значение: {0}", intnum.GetNegative());
            //            Console.WriteLine("Результат конвертирования в положительное значение: {0}", intnum.GetPositive());
            //        }
            //    }
            //    else { exit = true; }
            //} while (exit == false);

            //int num1 = 7;
            //int num2 = -13;
            //int num3 = 0;

            //Console.WriteLine(num1.GetNegative()); //-7
            //Console.WriteLine(num1.GetPositive()); //7
            //Console.WriteLine(num2.GetNegative()); //-13
            //Console.WriteLine(num2.GetPositive()); //13
            //Console.WriteLine(num3.GetNegative()); //0
            //Console.WriteLine(num3.GetPositive()); //0

            //int num1 = 3;
            //int num2 = 58;

            //Helper.Swap(ref num1, ref num2);

            //Console.WriteLine(num1); //58
            //Console.WriteLine(num2); //3

            //NeoCar car = new NeoCar();
            //Console.WriteLine(NeoCar.MinPrice);
            //Console.WriteLine(NeoCar.MaxPrice);

            //string str = "Hello";
            //Console.WriteLine(str.GetLastChar());

            //Console.WriteLine("Строка".GetLastChar());
            //Console.ReadKey();

            //HomoSapiens hs = new HomoSapiens();
            //Human human = hs;
            //Creature creature = (Creature)human;
            //Creature secondCreature = new Animal();
            //object obj = new Animal();

            //if (obj is Animal)
            //{
            //    Console.WriteLine("Объект класса Animal");
            //}
            //D d = new D();
            //E e = new E();

            //d.Display();
            //((A)e).Display();
            //((B)d).Display();
            //((A)d).Display();
            //Obj obj = new() { Value = 20};
            //Obj A = obj + 10;
            //Obj B = A - 15;
            //Obj C = A + B;
            //Obj D = C - (A + B);
            //Console.WriteLine("Значение A.Value = {0}", A.Value);
            //Console.WriteLine("Значение B.Value = {0}", B.Value);
            //Console.WriteLine("Значение C.Value = {0}", C.Value);
            //Console.WriteLine("Значение D.Value = {0}", D.Value);

            //var array = new Book[]
            //  {
            //    new Book
            //    {
            //      Name = "Мастер и Маргарита",
            //      Author = "М.А. Булгаков"
            //    },
            //    new Book
            //    {
            //      Name = "Отцы и дети",
            //      Author = "И.С. Тургенев"
            //    },
            //  };
            //BookCollection collection = new BookCollection(array);

            //Book book = collection[1];
            //Console.WriteLine("Название книги: {0}\nАвтор книги: {1}", book.Name, book.Author);
            //int[] arr = new int[10] { 15, 4, 6, -7, 9, 88, 41, 17, 254, -65};
            //IndexingClass IC = new IndexingClass() { int[] = arr };

        }
    }
    
}