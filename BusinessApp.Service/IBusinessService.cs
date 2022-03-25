using BusinessApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Service
{
    public interface IBusinessService
    {
        #region Customer
        int CreateCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        int ArchiveCustomer(int customerId);
        IEnumerable<Customer> GetCustomers(Customer filter, bool matchAny = false, bool matchExact = false);
        Customer GetCustomer(int customerId);
        #endregion

        #region Product
        int CreateProduct(Product product);
        int UpdateProduct(Product product);
        int ArchiveProduct(Product product);
        IEnumerable<Product> GetProducts(Product filter, bool matchAny = false, bool matchExact = false);
        Product GetProduct(int productId);
        #endregion

        #region Price
        int CreatePrice(Price price);
        int CreatePrice(int productId, int price, DateTime? startDate = null);
        Price GetPrice(int productId, DateTime? requestDate = null);
        Price GetPrice(int productId);
        IEnumerable<Price> GetPriceHistory(DateTime from);
        #endregion

        #region CustomerOrder
        int CreateCustomerOrder(CustomerOrder order);
        int GetCustomerOrder(int orderId);
        IEnumerable<CustomerOrder> GetCustomerOrders(int customerId, DateTime? orderDate = null);
        #endregion

        #region OrderItem
        int CreateOrderItem(OrderItem item);
        #endregion


    }
}
