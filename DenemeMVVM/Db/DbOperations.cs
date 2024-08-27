using DenemeMVVM.Models;
using System;
using System.Collections.Generic;
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
    
    }
}
