using DenemeMVVM.Db;
using DenemeMVVM.Models;
using DenemeMVVM.Stores;
using DenemeMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DenemeMVVM
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        InitializeComponents setComponents = new InitializeComponents();
        private readonly Restaurant restaurant;
        private readonly Menu menu;
        private readonly List<Table> tables;
        private readonly List<Employee> employees;

        private readonly NavigationStore _navigationStore;
        public App()
        {
            menu = new Menu();
            tables = setComponents.setTables();
            employees = setComponents.setEmployees();
            restaurant = new Restaurant(tables, menu, employees);
            _navigationStore = new NavigationStore();

        }
    
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(restaurant, _navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}
