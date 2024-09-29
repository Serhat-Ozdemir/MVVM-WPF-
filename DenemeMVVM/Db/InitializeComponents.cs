using DenemeMVVM.Models;
using MySqlConnector;
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
        private string connectionString = "SERVER=localhost;DATABASE=restaurant;UID=root;PASSWORD=Ozdemir.1";


        public List<MenuItem> setMenu()
        {
            List<MenuItem> menu = new List<MenuItem>();

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                string sql = "SELECT Name, Price FROM menuitem";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MenuItem item = new MenuItem(reader.GetString(0), reader.GetInt32(1));

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

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                string sql = "SELECT TableId FROM _table";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
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

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                string sql = "SELECT o.OrderId, o.Name, o.Quantity, m.Price FROM `_order` o INNER JOIN menuitem m ON o.Name = m.Name Where o.OrderId=" + tableID;
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MenuItem item = new MenuItem(reader.GetString(1), reader.GetInt32(3));
                            Order order = new Order(reader.GetInt32(0), item, reader.GetInt32(2));
                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }

        public List<Employee> setEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                string sql = "SELECT ID, Job, Name, Salary FROM Employee";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
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
