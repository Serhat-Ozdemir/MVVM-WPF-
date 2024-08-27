using DenemeMVVM.Models;
using System;
using System.Collections.Generic;
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
                            Table table = new Table(reader.GetInt32(0));

                            tables.Add(table);
                        }
                    }
                }
            }

            return tables;
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
