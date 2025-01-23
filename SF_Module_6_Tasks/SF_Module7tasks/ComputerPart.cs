using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_Module7tasks
{
    internal abstract class ComputerPart
    {
        public abstract void Work();
    }
    internal abstract class Processor : ComputerPart
    {
        public override void Work()
        {

        }
    }
    internal abstract class MotherBoard : ComputerPart
    {
        public override void Work()
        {

        }
    }
    internal abstract class GrapnicCard : ComputerPart
    {
        public override void Work()
        {

        }
    }
}
