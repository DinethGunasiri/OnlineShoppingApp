using OnlineShopping.data.IRepositories;
using OnlineShopping.data.Repository;
using OnlineShopping.Data.IRepositories;
using OnlineShopping.Data.Repository;

namespace OnlineShopping.data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingContext context;
        private ICustomerRepository _customer;
        private IProductRepository _product;
        private IOrderRepository _order;
        private IOrderItemRepository _items;

        public UnitOfWork(ShoppingContext context)
        {
            this.context = context;
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (this._customer == null)
                {
                    this._customer = new CustomerRepository(context);
                }
                return this._customer;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (this._product == null)
                {
                    this._product = new ProductRepository(context);
                }
                return this._product;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (this._order == null)
                {
                    this._order = new OrderRepository(context);
                }
                return this._order;
            }
        }

        public IOrderItemRepository Items
        {
            get
            {
                if (this._items == null)
                {
                    this._items = new OrderItemsRepository(context);
                }
                return this._items;
            }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
