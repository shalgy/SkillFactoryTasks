using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SF_Module7tasks
{
    class BaseClass
    {
        protected string? Name;
        public virtual int Counter
        {
            get;
            set;
        }

        public BaseClass()
        {
            Name = "BaseClass";

        }

        public BaseClass(string name)
        {
            Name = name;

        }

        public virtual void Display()
        {
            Console.WriteLine("Метод класса BaseClass");
        }
        public virtual void Method()
        {
        }

    }
    class InheritedClass : BaseClass
    {
        public override sealed void Method()
        {
        }
    }

    class DerivedClass : BaseClass
    {
        public string Description;
        public override int Counter
        {
            get 
            { 
                return Counter; 
            }                
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Значение не должно быть меньше 0");
                }
                else
                {
                    Counter = value;
                }
            }
        }
        public DerivedClass() : base()
        {
        }
        public DerivedClass(string name, string description) : base(name)
        {
            Description = description;
        }
        public DerivedClass (string name, string description, int counter) : base(name)
        {
            Description = description;
            Counter = counter;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Метод класса DerivedClass");
        }
    }
}
