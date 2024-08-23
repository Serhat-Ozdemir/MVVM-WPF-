using DenemeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.ViewModels
{

    public class MenuItemsViewModel : ViewModelBase
    {
        public MenuItems _menuItem;                    
        public string Name => _menuItem.Name;
        public string Price => _menuItem.Price.ToString();

        public MenuItemsViewModel(MenuItems menuItem) 
        { 
            _menuItem = menuItem;
        }
    }
}
