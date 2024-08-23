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
    internal class GiveOrderCommand : CommandBase
    {
        public Restaurant restaurant;
        public GetOrdersViewModel getOrdersViewModel;

        public GiveOrderCommand(GetOrdersViewModel getOrdersViewModel, Restaurant restaurant)
        {
            this.restaurant = restaurant;
            this.getOrdersViewModel = getOrdersViewModel;
        }
    
        public override void Execute(object parameter)
        {
            int quantity = 0;
            try
            {
                quantity = Convert.ToInt32(getOrdersViewModel.Quantity);
            }
            catch
            {
                giveError();
                return;
            }
            if(getOrdersViewModel.SelectedItem is null || quantity <= 0)
            {
                giveError();
                return;
            }
            MenuItems selectedProduct = new MenuItems(getOrdersViewModel.SelectedItem.Name, Convert.ToInt32(getOrdersViewModel.SelectedItem.Price));
            Order order = new Order(getOrdersViewModel.tableNum, selectedProduct, Convert.ToInt32(getOrdersViewModel.Quantity));
            restaurant.Tables[getOrdersViewModel.tableNum].Orders.Add(order);
        }

        public void giveError()
        {
            MessageBoxResult result = MessageBox.Show("Choose A Product And Type A Valid Quantity",
                                          "Error",
                                          MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
