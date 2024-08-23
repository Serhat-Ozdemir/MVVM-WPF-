using DenemeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeMVVM.ViewModels
{
    public class TableViewModel
    {
        public Table _table;
        public int TableId => _table.TableId;
        public ObservableCollection<Order> Orders => _table.Orders;

        public TableViewModel(Table table)
        {
            this._table = table;
        }
    }
}
