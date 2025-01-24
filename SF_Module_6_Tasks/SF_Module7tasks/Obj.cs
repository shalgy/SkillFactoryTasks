using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SF_Module7tasks
{
    public class Obj
    {
        public static int MaxValue;
        public static string Parent;
        public static int DaysInWeek;
        
        public string Name;
        public string Description;
        public int Value;
        //private string name;
        //private string owner;
        //private int length;
        //private int count;

        //public Obj(string name, string ownerName, int objLength, int count)
        //{
        //    this.name = name;
        //    owner = ownerName;
        //    length = objLength;
        //    this.count = count;
        //}

        static Obj()
        {
            MaxValue = 2000;
            Parent = "System.Object";
            DaysInWeek = 7;
        }
        public static Obj operator +(Obj obj, int value)
        {
            return new Obj
            {
                Value = obj.Value + value
            };
        }
        public static Obj operator -(Obj obj, int value)
        {
            return new Obj
            {
                Value = obj.Value - value
            };
        }
        public static Obj operator +(Obj a, Obj b)
        {
            return new Obj
            {
                Value = a.Value + b.Value
            };
        }
        public static Obj operator -(Obj a, Obj b)
        {
            return new Obj
            {
                Value = a.Value - b.Value
            };
        }
        public void Display<T>(T param)
        {
            Console.WriteLine(param.ToString());
        }
    }
    
}
