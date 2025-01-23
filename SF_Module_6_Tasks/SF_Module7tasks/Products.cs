using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_Module7tasks
{
    public class Product
    {
        public double Weight;
        public double Cost;
    }
    public class Fruct : Product
    {
        public enum FructType
        {
            Apple = 0,
            Banana,
            Pear
        }
        public FructType Type;
    }
    public class Vegetable : Product 
    {
        public enum VegetableType
        {
            Apple = 0,
            Banana,
            Pear
        }
        public VegetableType Type;
    }
    public class Potato : Vegetable
    {
        public string Variety;
        public enum ShapeOfTuber
        {
            Rounded = 0,
            Oval,
            Elongated
        }
        public enum AmountOfStarch
        {
            Few = 0,
            Medium,
            Much
        }
        public ShapeOfTuber Tuber;
        public ShapeOfTuber Starch;
    }
    public class Carrot : Vegetable
    {
        public string Variety;
        public int TuberLenght;
        public bool Sweet;
    }
    public class Apple : Fruct
    {
        public string Variety;
        public enum AppleColor
        {
            Red = 0,
            Green,
            Yellow
        }
        public bool Sweet;
        public AppleColor Color;
    }
    public class Pear : Fruct
    {
        public string Variety;
        public enum PearColor
        {
            Red = 0,
            Green,
            Yellow
        }
        public PearColor Color;
        public bool Juicy;
    }
    public class Banana : Fruct
    {
        public int Lenght;
        public bool Ripe;
    }
}
