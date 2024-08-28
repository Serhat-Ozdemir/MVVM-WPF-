using DenemeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace DenemeMVVM.Db
{
    public class DbOperations
    {
        private string connectionString = "Data Source=MVVMdatabase.db;Version=3;";
        public void addOrder(int orderId, string itemName, int quantity)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Orders (OrderId, Name, Quantity) VALUES ( " + orderId + ",\"" + itemName + "\"," + quantity + ")";
                SQLiteCommand command = new SQLiteCommand(sql, connection);                
                command.ExecuteNonQuery();
            }
        }

        public void removeOrder(int orderId, string itemName, int quantity) 
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Orders Where OrderId =" + orderId + " AND Name = \"" + itemName + "\" AND Quantity = "+ quantity;
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }

        }

        public ObservableCollection<Order> getOrders() 
        {
            ObservableCollection<Order> orders = new ObservableCollection<Order>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT OrderId, Name, Quantity FROM Orders";
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
    
    }
}
