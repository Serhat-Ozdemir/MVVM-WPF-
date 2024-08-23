using DenemeMVVM.Commands;
using DenemeMVVM.Models;
using DenemeMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DenemeMVVM.ViewModels
{
    public class SelectTableViewModel : ViewModelBase
    {
        public ICommand NavigateTableViewCommand { get; }
        public ICommand LogOutCommand { get; }
        public SelectTableViewModel(Restaurant restaurant, NavigationStore navigationStore)
        {
            NavigateTableViewCommand = new NavigateTableViewCommand(restaurant, navigationStore);
            LogOutCommand = new LogOutCommand(restaurant, navigationStore);
        }
    }
}
