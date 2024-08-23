using DenemeMVVM.Models;
using DenemeMVVM.Stores;
using DenemeMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.Commands
{
    internal class NavigateTableViewCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Restaurant _restaurant;

        public NavigateTableViewCommand(Restaurant restaurant, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _restaurant = restaurant;
        }

        public override void Execute(object parameter)
        {
            if (parameter is string content) {
                int tableNum = Convert.ToInt32(content);
                _navigationStore.CurrentViewModel = new GetOrdersViewModel(tableNum -1, _restaurant, _navigationStore);
            }
            
        }
    }
}
