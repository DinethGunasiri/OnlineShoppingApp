using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Data.IRepositories
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItems> GeItems();
        OrderItems GetItemById(int id);
        OrderItems InsertItems(OrderItems items);
        OrderItems UpdateItems(OrderItems items);
        void RemoveItems(int id);
        void Save();
    }
}
