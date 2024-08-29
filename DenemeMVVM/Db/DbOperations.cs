using DenemeMVVM.Models;
using MySqlConnector;
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
        private string connectionString = "SERVER=94.73.149.214;DATABASE=u1915012_serhat1;UID=u1915012_serhat;PASSWORD=au0_CmA.J-aN1_78";
        public void addOrder(int orderId, string itemName, int quantity)
        {

            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO _order (OrderId, Name, Quantity) VALUES ( " + orderId + ",\"" + itemName + "\"," + quantity + ")", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void removeOrder(int orderId, string itemName, int quantity) 
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM _order Where OrderId =" + orderId + " AND Name = \"" + itemName + "\" AND Quantity = " + quantity + " LIMIT 1", con);
            cmd.ExecuteNonQuery();
            con.Close();
            //using (var connection = new SQLiteConnection(connectionString))
            //{
            //    connection.Open();
            //    string sql = "DELETE FROM Orders Where OrderId =" + orderId + " AND Name = \"" + itemName + "\" AND Quantity = "+ quantity;
            //    SQLiteCommand command = new SQLiteCommand(sql, connection);
            //    command.ExecuteNonQuery();
            //}

        }

        public ObservableCollection<Order> getOrders() 
        {
            ObservableCollection<Order> orders = new ObservableCollection<Order>();
            
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                string sql = "SELECT o.OrderId, o.Name, o.Quantity, m.Price FROM `_order` o INNER JOIN menuitem m ON o.Name = m.Name";
                using (var cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MenuItems item = new MenuItems(reader.GetString(1), reader.GetInt32(3));
                            Order order = new Order(reader.GetInt32(0), item, reader.GetInt32(2));
                            orders.Add(order);
                        }
                    }
                }
                con.Close();
            }

            return orders;
        }
    
    }
}
