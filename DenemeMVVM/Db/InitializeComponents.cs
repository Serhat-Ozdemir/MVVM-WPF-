using DenemeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.Db
{
    public class InitializeComponents
    {
        private string connectionString = "Data Source=MVVMdatabase.db;Version=3;";


        public List<MenuItems> setMenu()
        {
            List<MenuItems> menu = new List<MenuItems>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT Name, Price FROM MenuItem";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MenuItems item = new MenuItems(reader.GetString(0), reader.GetInt32(1));

                            menu.Add(item);
                        }
                    }
                }
            }

            return menu;
        }

        public List<Table> setTables()
        {
            List<Table> tables = new List<Table>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT TableId FROM _Table";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tableID = reader.GetInt32(0);
                            Table table = new Table(tableID);
                            table.Orders = setOrderList(tableID);
                            tables.Add(table);
                        }
                    }
                }
            }

            return tables;
        }

        public ObservableCollection<Order> setOrderList(int tableID)
        {
            ObservableCollection<Order> orders = new ObservableCollection<Order>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Orders WHERE OrderID = " + Convert.ToString(tableID);
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string ordersql = "Select Name, Price From MenuItem Where Name = \"" + reader.GetString(1) + "\"";
                            using (var ordercommand = new SQLiteCommand(ordersql, connection))
                            {
                                using (SQLiteDataReader orderreader = ordercommand.ExecuteReader())
                                {

                                    while (orderreader.Read())
                                    {
                                        MenuItems item = new MenuItems(orderreader.GetString(0), orderreader.GetInt32(1));
                                        Order order = new Order(reader.GetInt32(0), item, reader.GetInt32(2));
                                        orders.Add(order);
                                    }

                                    
                                }
                            }
                        }
                    }
                }
            }

            return orders;
        }

        public List<Employee> setEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT ID, Job, Name, Salary FROM Employee";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            if (reader.GetString(1).Equals("Waiter"))
                                employees.Add(new Waiter(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
                            if (reader.GetString(1).Equals("Cook"))
                                employees.Add(new Cook(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));


                        }
                    }
                }
            }

            return employees;

        }
    }
}
