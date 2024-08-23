using DenemeMVVM.Models;
using DenemeMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.Commands
{
    internal class CancelOrderCommand : CommandBase
    {
        public Restaurant restaurant;
        public GetOrdersViewModel getOrdersViewModel;

        public CancelOrderCommand(GetOrdersViewModel getOrdersViewModel, Restaurant restaurant)
        {
            this.restaurant = restaurant;
            this.getOrdersViewModel = getOrdersViewModel;
        }

        public override void Execute(object parameter)
        {
            getOrdersViewModel._table.Orders.Remove(getOrdersViewModel.SelectedOrder);
        }
    }
}
