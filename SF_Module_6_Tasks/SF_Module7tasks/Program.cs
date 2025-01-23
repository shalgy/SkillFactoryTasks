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

    class Program
    {
        static void Main(string[] args)
        {
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
            int[] arr = new int[10] { 15, 4, 6, -7, 9, 88, 41, 17, 254, -65};
            IndexingClass IC = new IndexingClass() { int[] = arr };
        }
    }
    
}