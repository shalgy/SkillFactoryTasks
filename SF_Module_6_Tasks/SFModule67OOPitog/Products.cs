using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using static SFModule67OOPitog.Methods;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SFModule67OOPitog
{
    public enum FrutColor
    {
        Красный = 1,
        Зеленый,
        Желтый
    }
    public enum FructType
    {
        Яблоко = 1,
        Банан,
        Груша
    }
    public enum VegetableType
    {
        Картошка = 1,
        Морковь
    }
    public enum ShapeOfTuber
    {
        Круглый = 1,
        Овальный,
        Вытянутый
    }
    public enum AmountOfStarch
    {
        Низкое = 1,
        Среднее,
        Высокое
    }
    public abstract class Product
    {
        public string? Variety { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }

        public abstract void ShowInfo();
    }
    public abstract class Fruct : Product
    {
        public FrutColor FructColor { get; set; }
        public FructType FructType { get; set; }

        public abstract override void ShowInfo();
    }

    public abstract class Vegetable : Product
    {
        public VegetableType VegetableType { get; set; }

        public abstract override void ShowInfo();
    }

    public class Potato : Vegetable
    {
        public ShapeOfTuber Tuber { get; set; }
        public AmountOfStarch Starch { get; set; }

        public override void ShowInfo()
        {
            WriteInColor("Овощ: " + VegetableType + ", сорт: " + "\"" + Variety + "\"" + ", форма клубня: " + Tuber + ", содержание крахмала: " + Starch
                + ", фасовка: " + Weight+ "кг., цена: " + string.Format("{0:0.00}", Cost) + "р.", true, 6);
        }
    }

    public class Carrot : Vegetable
    {
        public bool Fresh { get; set; }
        public bool Sweet { get; set; }

        public override void ShowInfo()
        {
            WriteInColor("Овощ: " + VegetableType + ", сорт: " + "\"" + Variety + "\"" + ", Свежесть: " + (Fresh ? "Молодая" : "Прошлый сезон")
            + ", сладкая: " + (Sweet ? "ДА" : "НЕТ") + ", фасовка: " + Weight + "кг., цена: " + string.Format("{0:0.00}", Cost) + "р.", true, 6);
        }
    }

    public class Apple : Fruct
    {     
        public bool Sweet { get; set; }

        public override void ShowInfo()
        {
            WriteInColor("Фрукт: " + FructType + ", сорт: " + "\"" + Variety + "\"" + ", цвет: " + FructColor + ", сладкая: " + (Sweet ? "ДА" : "НЕТ")
                + ", фасовка: " + Weight + "кг., цена: " + string.Format("{0:0.00}", Cost) + "р.", true, 6);
        }
    }

    public class Pear : Fruct
    {      
        public bool Juicy { get; set; }

        public override void ShowInfo()
        {
            WriteInColor("Фрукт: " + FructType + ", сорт: " + "\"" + Variety + "\"" + ", цвет: " + FructColor + ", сочная: " + (Juicy ? "ДА" : "НЕТ")
                + ", фасовка: " + Weight + "кг., цена: " + string.Format("{0:0.00}", Cost) + "р.", true, 6);
        }
    }

    public class Banana : Fruct
    {
        public bool Size { get; set; }
        public bool Ripe { get; set; }

        public override void ShowInfo()
        {
            WriteInColor("Фрукт: " + FructType + ", сорт: " + "\"" + Variety + "\"" + ", цвет: " + FructColor + ", крупные: " + (Size ? "ДА" : "НЕТ")
                + ", спелые: " + (Size ? "ДА" : "НЕТ") + ", фасовка: " + Weight + "кг., цена: " + string.Format("{0:0.00}", Cost) + "р.", true, 6);
        }
    }
}
