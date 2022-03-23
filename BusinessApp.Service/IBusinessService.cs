using BusinessApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Service
{
    public interface IBusinessService
    {
        int CreateCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        int ArchiveCustomer(Customer customer);
        int ArchiveCustomer(int customerId);
        int DeleteCustomer(Customer customer);
        int DeleteCustomer(int customerId);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(Customer customer);
        Customer GetCustomer(int customerId);
    }
}
