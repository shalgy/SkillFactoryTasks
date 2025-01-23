using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_Module7tasks
{
    internal class A
    {
        internal virtual void Display()
        {
            Console.WriteLine("A");
        }
    }
    internal class B:A
    {
        internal new void Display()
        {
            Console.WriteLine("B");
        }
    }
    internal class C : A
    {
        internal override void Display()
        {
            Console.WriteLine("C");
        }
    }
    internal class D : B
    {
        internal new void Display()
        {
            Console.WriteLine("D");
        }
    }
    internal class E : C
    {
        internal new void Display()
        {
            Console.WriteLine("E");
        }
    }
}
