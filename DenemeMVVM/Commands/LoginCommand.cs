using DenemeMVVM.Models;
using DenemeMVVM.Stores;
using DenemeMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DenemeMVVM.Commands
{
    internal class LoginCommand :CommandBase
    {

        private readonly NavigationStore _navigationStore;
        private readonly Restaurant _restaurant;
        public LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel, Restaurant restaurant, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _restaurant = restaurant;
            _loginViewModel = loginViewModel;

        }


        public override void Execute(object parameter)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(_loginViewModel.UserId);
            }
            catch
            {

                giveError();
                return;
            }
            
            Employee employee = findEmployee(_restaurant.Employees, id);
            if (employee != null)
            {
                if (employee.Job.Equals("Waiter"))
                    _navigationStore.CurrentViewModel = new SelectTableViewModel(_restaurant, _navigationStore);
                else if (employee.Job.Equals("Cook"))
                    _navigationStore.CurrentViewModel = new ListOrdersViewModel(_restaurant, _navigationStore);
                else
                    return;
            }
            else
            {
                giveError();
            }
            
        }

        public Employee findEmployee(List<Employee> employees, int id)
        {
            {
                foreach (Employee employee in employees)
                {
                    if (employee.Id.Equals(id))
                    {
                        if (checkPassword(employee))
                            return employee;
                        else 
                            return null;
                    }
                }
                return null;
            }
        }

        public bool checkPassword(Employee employee)
        {
            return employee.Id==Convert.ToInt32(_loginViewModel.Password);

        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_loginViewModel.UserId) || !string.IsNullOrEmpty(_loginViewModel.UserId) || base.CanExecute(parameter);
        }

        public void giveError()
        {
            MessageBoxResult result = MessageBox.Show("Invalid Information?",
                                          "Error",
                                          MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
