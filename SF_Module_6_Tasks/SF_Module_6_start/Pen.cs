//Модуль 6. Задание 6.2.2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SF_Module_6_start
{
    internal class Pen
    {
        public string color;
        public int cost;
        // Конструктор 1
        public Pen()
        {
            color = "Черный";
            cost = 100;
        }
        // Конструктор 2
        public Pen(string penColor, int penCost)
        {
            color = penColor;
            cost = penCost;
        }
    }
}
