using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public ObservableCollection<Order> Orders;
        public Table(int TableId)
        { 
            this.TableId = TableId;
            this.Orders = new ObservableCollection<Order>();
        }

        public void addOrder(Order order) { 
            Orders.Add(order);
        }
    }
}
