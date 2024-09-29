using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.Models
{

    public class Order
    {
        public int OrderId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }


        public Order(int OrderId, MenuItem MenuItems, int Quantity)
        {
            this.OrderId = OrderId;
            this.MenuItem = MenuItems;
            this.Quantity = Quantity;
            Cost = MenuItems.Price * Quantity;
        }
    }
}
