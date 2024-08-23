using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DenemeMVVM.Models
{
    public class Menu
    {
        public  List<MenuItems> menu {  get; set; }
        public Menu()
        {
            menu = new List<MenuItems>();

            menu.Add(new MenuItems("asd", 13));
            menu.Add(new MenuItems("qaz", 2));
            menu.Add(new MenuItems("asdq", 7));
            menu.Add(new MenuItems("asdqwed", 25));
        }
    }
}
