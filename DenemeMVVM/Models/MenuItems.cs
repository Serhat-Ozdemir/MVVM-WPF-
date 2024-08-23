using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.Models
{
    public class MenuItems
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public MenuItems(string Name, int Price) 
        { 
            this.Name = Name;
            this.Price = Price;
        }
    }
}
