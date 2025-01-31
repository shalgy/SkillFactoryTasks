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

    //Задание 7.6.9
    //Установите ограничения на универсальные типы в классе Car.Такие, чтобы поле Engine могло принимать тип ElectricEngine и GasEngine, 
    //а параметр newPart метода ChangePart мог бы принимать только типы частей машины (Battery, Differential, Wheel).

    //Задание 7.6.10
    //Переименуйте универсальные параметры в более читаемые, например, TEngine и TPart.

    //Задание 7.6.12
    //С учётом полученных знаний по наследованию обобщений, дополните схему классов автомобиля, добавив классы для электромобиля и бензинового — ElectricCar и GasCar.
    //Подумайте, какой класс или классы можно сделать абстрактными.Сделайте абстрактными их и их члены(по возможности).
    
    internal abstract class NeoCar<TEngine> where TEngine : Engine
    {
        public static int MinPrice = 100_000;
        public static int MaxPrice;
        public TEngine Engine;

        static NeoCar()
        {
            Console.WriteLine("Вызван статический конструктор класса Car");
            MaxPrice = 1_000_000;
        }
        public abstract void ChangePart<TPart>(TPart newPart) where TPart : NeoCarPart;
                
    }
    internal class ElectricCar : NeoCar<ElectricEngine>
    {
        public override void ChangePart<TPart>(TPart newPart)
        {

        }
    }

    internal class GazCar : NeoCar<GasEngine>
    {
        public override void ChangePart<TPart>(TPart newPart)
        {

        }
    }

    internal abstract class Engine 
    { 

    }
    internal abstract class NeoCarPart
    {

    }
    internal class Battery : NeoCarPart
    {

    }
    internal class Differential : NeoCarPart
    {

    }
    internal class Wheel : NeoCarPart
    {

    }
    internal class ElectricEngine : Engine 
    {

    }
    internal class GasEngine : Engine 
    {

    }

}
