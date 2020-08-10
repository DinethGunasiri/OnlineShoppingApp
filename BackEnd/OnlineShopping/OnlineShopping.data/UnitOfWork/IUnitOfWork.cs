using OnlineShopping.data.IRepositories;
using OnlineShopping.Data.IRepositories;
using System;

namespace OnlineShopping.data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get; }
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        IOrderItemRepository Items { get; }
        int SaveChanges();
    }
}
