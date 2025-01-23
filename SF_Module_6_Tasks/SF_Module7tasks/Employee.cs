using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_Module7tasks
{
    internal class Employee
    {
        public string Name;
        public int Age;
        public int Salary;
    }
    class ProgectManager : Employee
    {
        public string ProjectManager;
    }
    class Developer : Employee
    {
        public string ProgrammingLanguage;
    }
}
