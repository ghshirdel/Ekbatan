using Ekbatan.DomainClasses.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekbatan.Services.Repositories
{
   public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int customer_Id);
        void Insert_Customer(Customer customer);
        void Update_Customer(Customer customer);
        void Delete_Customer(Customer customer);
        void DeleteCustomerById(int customer_Id);
        void Save();
    }
}
