using OnlineShoppind.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppind.Business.OrderItemServises
{
    public interface IItemServices
    {
        IEnumerable<ItemDTO> GetItems();
        ItemDTO GetItemById(int id);
        ItemDTO InsertItem(ItemDTO item);
        ItemDTO UpdateItem(int id, ItemDTO item);
        void RemoveItem(int id);
    }
}
