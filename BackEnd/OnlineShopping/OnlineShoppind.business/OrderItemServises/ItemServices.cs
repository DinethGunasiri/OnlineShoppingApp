using AutoMapper;
using Microsoft.Extensions.Configuration;
using OnlineShoppind.Business.DTOs;
using OnlineShoppind.Business.OrderServices;
using OnlineShopping.data.UnitOfWork;
using OnlineShopping.Data.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppind.Business.OrderItemServises
{
    public class ItemServices : IItemServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IOrderServices _orderServices;

        public ItemServices(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IOrderServices orderServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _orderServices = orderServices;
        }

        // Get product items by id
        public ItemDTO GetItemById(int id)
        {
            var item = _unitOfWork.Items.GetItemById(id);

            if (item != null)
            {
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
            else
            {
                return null;
            } 

            
        }

        // Get all product items
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

        // Insert new product item to database
        public ItemDTO InsertItem(ItemDTO item)
        {
            var items = _mapper.Map<OrderItems>(item);
            _unitOfWork.Items.InsertItems(items);

            _unitOfWork.SaveChanges();

            return item;
        }

        // Edit product item by id
        public ItemDTO UpdateItem(int id, ItemDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"{item} is null");
            }

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

        // Send email to customer
        public Task SendEmailAsync(int orderId)
        {

            OrderDTO returnOrder = _orderServices.GetOrderById(orderId);

            var apikey = _configuration["SendGridApiKey"];
            var client = new SendGridClient(apikey);
            var from = new EmailAddress("dinethlahiru@gmail.com", "Dineth");
            var to = new EmailAddress(returnOrder.CustomerId);
            var subject = "Online Shopping Order Counfirmation";
            var plainTextContent = "Plain content";
            var htmlContext = "<h2><u>Order Confirmation</u></h2></br>" +
                "<h3>Order Id : " + returnOrder.OrderId+ "</h4>" +
                "<h4>Order Date : "+ returnOrder.OrderDate + "</h4></br>" +
                "<h4>Shipping Address : </h4></br>" +
                "<h4>" + returnOrder.ShippingAddress + "</h4></br>" +
                "<h4>Total Price : " + returnOrder.TotalPrice + "/=</h4>" +
                "<h4>Payment Method: " +returnOrder.PaymentType + "</h4>";
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent,
                htmlContext
                );

            var responce = client.SendEmailAsync(msg);
            return responce;
        }

    }
}
