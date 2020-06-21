using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.Customer;
using Ekbatan.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ekbatan.Services.Services
{
    public class CustomerREpository : ICustomerRepository
    {
        private EkbatanDbContext _db;
        public CustomerREpository(EkbatanDbContext db)
        {
            _db = db;
        }


        public List<Customer> GetAllCustomers()
        {
            return _db.Customers.ToList();
        }

        public Customer GetCustomerById(int customer_Id)
        {
            return _db.Customers.Find(customer_Id);

        }

        public void Insert_Customer(Customer customer)
        {
            _db.Customers.Add(customer);
        }

        public void Update_Customer(Customer customer)
        {
            _db.Entry(customer).State =EntityState.Modified;
        }
        public void Delete_Customer(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Deleted;
        }

        public void DeleteCustomerById(int customer_Id)
        {
            var cu = GetCustomerById(customer_Id);
            Delete_Customer(cu);
        }
      
        public void Save()
        {

            _db.SaveChanges();
        }
    }
}
