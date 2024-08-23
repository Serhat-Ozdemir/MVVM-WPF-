using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DenemeMVVM.Models;

namespace DenemeMVVM.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        public Order _order;

        public int OrderId => _order.OrderId;
        public MenuItems MenuItem => _order.MenuItems;
        public int Quantity => _order.Quantity;

        public OrdersViewModel(Order Order)
        {
            _order = Order;
        }

    }
}
