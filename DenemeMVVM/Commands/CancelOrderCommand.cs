using DenemeMVVM.Db;
using DenemeMVVM.Models;
using DenemeMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DenemeMVVM.Commands
{
    internal class CancelOrderCommand : CommandBase
    {
        DbOperations removeOrder = new DbOperations();
        public Restaurant restaurant;
        public GetOrdersViewModel getOrdersViewModel;

        public CancelOrderCommand(GetOrdersViewModel getOrdersViewModel, Restaurant restaurant)
        {
            this.restaurant = restaurant;
            this.getOrdersViewModel = getOrdersViewModel;
        }

        public override void Execute(object parameter)
        {
            
            Order selectedOrder = getOrdersViewModel.SelectedOrder;
            if (selectedOrder != null)
            {
                getOrdersViewModel._table.Orders.Remove(selectedOrder);
                removeOrder.removeOrder(selectedOrder.OrderId, selectedOrder.MenuItems.Name, selectedOrder.Quantity);
            }
            else
                giveError();
        }

        public void giveError()
        {
            MessageBoxResult result = MessageBox.Show("Choose Something To Delete",
                                          "Error",
                                          MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
