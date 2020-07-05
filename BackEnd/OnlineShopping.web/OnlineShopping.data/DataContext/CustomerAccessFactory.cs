using OnlineShopping.data.Functions;
using OnlineShopping.data.Interfacses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.data.DataContext
{
    public static class CustomerAccessFactory
    {
        public static ICustomer GetCustomerDataAccessObj()
        {
            return new CustomerRepository();
        }
    }
}
