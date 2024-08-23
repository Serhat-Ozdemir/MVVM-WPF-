using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.Models
{
    public class Cook : Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public Cook(int ID, string Job, string Name, int Salary) :base(ID, Job)
        {
            this.Name = Name;
            this.Salary = Salary;
        }
    }
}
