using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_Module7tasks
{
    //internal class NeoCar
    //{
    //    public static int MinPrice = 100_000;
    //    public static int MaxPrice;

    //    static NeoCar()
    //    {
    //        Console.WriteLine("Вызван статический конструктор класса Car");
    //        MaxPrice = 1_000_000;
    //    }

    //    public int Price;
    //}

    //Задание 7.6.2
    //Создайте класс-обобщение Car для автомобиля.Универсальным параметром будет тип двигателя в автомобиле (электрический и бензиновый). 
    //Для типов двигателей также создайте классы — ElectricEngine и GasEngine.
    //В классе Car создайте поле Engine в качестве типа которому укажите универсальный параметр.

    //Задание 7.6.7
    //Добавьте к схеме классов автомобиля следующие классы частей автомобиля: Battery, Differential, Wheel.
    //Также добавьте в класс Car виртуальный обобщённый метод без реализации — ChangePart, который будет принимать один параметр — newPart универсального типа.
    //static class NeoCar
    internal class NeoCar<T>
    {
        public static int MinPrice = 100_000;
        public static int MaxPrice;
        public T Engine;

        static NeoCar()
        {
            Console.WriteLine("Вызван статический конструктор класса Car");
            MaxPrice = 1_000_000;
        }
        public virtual void ChangePart<T2>(T2 newPart)
        {

        }
        
    }
    internal class Battery
    {

    }
    internal class Differential
    {

    }
    internal class Wheel
    {

    }
    internal class ElectricEngine
    {

    }
    internal class GasEngine
    {

    }
}
