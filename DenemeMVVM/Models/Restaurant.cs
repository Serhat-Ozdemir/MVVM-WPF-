    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.Models
{

    public class Restaurant
    {
        public List<Table> Tables { get; set; }
        public Menu Menu { get; set; }
        public List<Employee> Employees {  get; set; }

        public Restaurant(List<Table> Tables, Menu Menu, List<Employee> Employees)
        {
            this.Tables = Tables;
            this.Menu = Menu;
            this.Employees = Employees;
        }


    }
}
