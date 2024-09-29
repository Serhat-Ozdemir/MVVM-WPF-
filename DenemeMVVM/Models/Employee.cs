using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.Models
{
    public class Employee
    {
        public int Id { get;}
        public string Job { get; set; }
        public Employee( int ID, string Job) 
        { 
            this.Id = ID;      
            this.Job = Job;        }

    }
}
