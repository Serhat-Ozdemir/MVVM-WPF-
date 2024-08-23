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
    internal class LogOutCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Restaurant _restaurant;

        public LogOutCommand (Restaurant restaurant, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _restaurant = restaurant;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(_restaurant, _navigationStore);
        }
    }
}
