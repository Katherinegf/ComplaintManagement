using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDataBase.Context;
using WpfAppDataBase.MVVM.Models;
using WpfAppDataBase.MVVM.Models.Entities;

namespace WpfAppDataBase.Services
{
    public static class CustomerService
    {
        private static DataContext _context = new DataContext();

        public static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        public static async Task SaveCustomerAsync(Customer customer)
        {
            var customerEntity = new CustomerEntity
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber= customer.PhoneNumber,
            };
            _context.Add(customerEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var _customers = new List<Customer>();

            foreach (var _customer in await _context.Customers.ToListAsync())
                _customers.Add(new Customer
                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber,
                });
            return _customers;
        }

        public static async Task<Customer> GetCustomerAsync(string email)
        {
            var _customer = await _context.Customers.FirstOrDefaultAsync(x => x.Email == email);
            if (_customer != null)
                return new Customer
                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber,
                };
            else
                return null!;
        }
        public static async Task UpdateCustomerAsync(Guid id, Customer customer)
        {
            var _customerEntity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if(_customerEntity !=null)
            {
                if(!string.IsNullOrEmpty(customer.FirstName))
                    _customerEntity.FirstName = customer.FirstName;

                if(!string.IsNullOrEmpty(customer.LastName))
                    _customerEntity.LastName = customer.LastName;

                if(!string.IsNullOrEmpty(customer.Email))
                    _customerEntity.Email = customer.Email;

                if(!string.IsNullOrEmpty(customer.PhoneNumber))
                    _customerEntity.PhoneNumber = customer.PhoneNumber;

                _context.Update(_customerEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task RemoveCustomerAsync(string email)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(e => e.Email == email);
            if(customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public static ObservableCollection<Customer> Customers()
        {
            return customers;
        }

        public static Customer ConvertEntityToModel(CustomerEntity customer)
        {
            return new Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };
        }
    }
}
