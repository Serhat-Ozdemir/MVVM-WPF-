using DenemeMVVM.Commands;
using DenemeMVVM.Models;
using DenemeMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DenemeMVVM.ViewModels
{
    internal class ListOrdersViewModel : ViewModelBase
    {
        public ObservableCollection<Order> _allOrders;

        public IEnumerable<Order> AllOrders => _allOrders;

        public ICommand LogOutCommand { get; }
        public ListOrdersViewModel(Restaurant restaurant, NavigationStore navigationStore)
        {
            _allOrders = new ObservableCollection<Order>();
            foreach (Table table in restaurant.Tables)
            {
                foreach (Order order in table.Orders)
                {
                    _allOrders.Add(order);
                }
                
            }
            LogOutCommand = new LogOutCommand(restaurant, navigationStore);

        }

    }
}
