using AutoMapper;
using OnlineShoppind.Business.DTOs;
using OnlineShopping.data.UnitOfWork;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShoppind.Business.OrderItemServises
{
    public class ItemServices : IItemServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ItemDTO GetItemById(int id)
        {
            var item = _unitOfWork.Items.GetItemById(id);
            // var itemDetails = _mapper.Map<ItemDTO>(item);

            ItemDTO itemDto = new ItemDTO
            {
                ItemId = item.ItemId,
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                PurchasePrice = item.PurchasePrice,
                Quantity = item.Quantity
            };

            return itemDto;
        }

        public IEnumerable<ItemDTO> GetItems()
        {
            var items = _unitOfWork.Items.GeItems().ToList();
            List<ItemDTO> itemList = new List<ItemDTO>();

            foreach(var item in items)
            {
                ItemDTO itemDetails = new ItemDTO
                {
                    ItemId = item.ItemId,
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    PurchasePrice = item.PurchasePrice,
                    Quantity = item.Quantity
                };
                itemList.Add(itemDetails);
            }
            return itemList;
        }

        public ItemDTO InsertItem(ItemDTO item)
        {
            var items = _mapper.Map<OrderItems>(item);
            _unitOfWork.Items.InsertItems(items);

            _unitOfWork.SaveChanges();

            return item;
        }

        public ItemDTO UpdateItem(int id, ItemDTO item)
        {
            var items = _unitOfWork.Items.GetItemById(id);

            items.OrderId = item.OrderId;
            item.ProductId = item.ProductId;
            item.PurchasePrice = item.PurchasePrice;
            item.Quantity = item.Quantity;

            _unitOfWork.Items.UpdateItems(items);
            _unitOfWork.SaveChanges();

            return item;
        }

        public void RemoveItem(int id)
        {
            _unitOfWork.Items.RemoveItems(id);
            _unitOfWork.SaveChanges();

        }
    }
}
