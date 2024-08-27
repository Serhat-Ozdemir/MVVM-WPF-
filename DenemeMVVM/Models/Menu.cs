using DenemeMVVM.Db;
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
        InitializeComponents setMenu = new InitializeComponents();
        public Menu()
        {
            menu = setMenu.setMenu();
        }
    }
}
