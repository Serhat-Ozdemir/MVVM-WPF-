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

            menu.Add(new MenuItems("red", 13));
            menu.Add(new MenuItems("blue", 2));
            menu.Add(new MenuItems("yellow", 7));
            menu.Add(new MenuItems("green", 25));
        }
    }
}
