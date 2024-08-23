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
    public class GetOrdersViewModel : ViewModelBase
    {
        public ObservableCollection<MenuItemsViewModel> _menu;
        public TableViewModel _table;

        public IEnumerable<MenuItemsViewModel> Menu => _menu;
        public IEnumerable<Order> Orders => _table.Orders;
        public ICommand GiveOrderCommand { get; }
        public ICommand CancelOrderCommand { get; }
        public ICommand SelectTableCommand { get; }

        public int tableNum;
        public GetOrdersViewModel(int tableNum, Restaurant restaurant, NavigationStore navigationStore)
        {
            this.tableNum = tableNum;

            GiveOrderCommand = new GiveOrderCommand(this, restaurant);
            CancelOrderCommand = new CancelOrderCommand(this, restaurant);
            SelectTableCommand = new SelectTableCommand(restaurant, navigationStore);

            _menu = new ObservableCollection<MenuItemsViewModel>();
            foreach (MenuItems item in restaurant.Menu.menu) 
            {
                _menu.Add(new MenuItemsViewModel(item));
            }

            _table = new TableViewModel(restaurant.Tables[tableNum]);

        }

        private MenuItemsViewModel selectedItem;
        public MenuItemsViewModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        private string quantity;
        public string Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

    }
}
