using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_Module_6_start
{
    internal class Recte
    {
        public int a;
        public int b;

        public Recte()
        {
            a = 6;
            b = 4;
        }

        public Recte(int oneside)
        {
            a = oneside;
            b = oneside;
        }

        public Recte(int aside, int bside)
        {
            a = aside;
            b = bside;
        }

        public int Square() { return a * b; }
    }
}
