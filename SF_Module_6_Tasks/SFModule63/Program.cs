using System;

namespace SF_Module_6_start
{
    struct Data
    {
        public string Name;
        public int Lenght;
        public int Version;
        public int[] Array;
    }
    class Obj
    {
        public string Name;
        public bool isAlive;
        public int Weight;
    }
    class Program
    {

        static void Main(string[] args)
        {

            Data data = new() { Name = "Запись", Lenght = 10, Version = 1, Array = new int[] { 15, 30 } };
            Obj obj = new() { Name = "Стол", isAlive = false , Weight = 15 };

            var dataCopy = data;
            var objCopy = obj;

            data.Name = "Значение";
            data.Lenght = 35;
            data.Version = 2;
            data.Array[0] = 0;

            obj.Name = "Кот";
            obj.isAlive = true;
            obj.Weight = 3;

            objCopy = new Obj { Name = obj.Name, isAlive = obj.isAlive, Weight = obj.Weight};

            obj.Name = "Стол";
            obj.isAlive = false;
            obj.Weight = 15;

            Console.ReadKey();
        }
    }
}