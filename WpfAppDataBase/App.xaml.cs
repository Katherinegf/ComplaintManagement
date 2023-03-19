using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppDataBase.Context;
using WpfAppDataBase.MVVM.Models;
using WpfAppDataBase.MVVM.Models.Entities;
using WpfAppDataBase.Services;
using Microsoft.EntityFrameworkCore;


namespace WpfAppDataBase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async void Test()
        {
            var context = new DataContext();
            Console.WriteLine("Cases in db: " + context.Cases.Count());
            var @case = context.Cases.Include("Customer").Include("Address").First();

            Console.WriteLine("Case information: ");
            Console.WriteLine("Id: " + @case.CaseNumber);
            Console.WriteLine("Customer Id: " + @case.Customer.Id);
            Console.WriteLine("Address Id: " + @case.Address.Id);
            var @caseFromService = await CaseService.GetCaseByCustomerIdAsync(@case.Customer.Id.ToString());

            if (caseFromService != null && caseFromService.CaseNumber == @case.CaseNumber)
                Console.WriteLine("Found case via Customer ID");
            else
                Console.WriteLine("Could not find case via Customer ID");

            var @customerFromService = await CustomerService.GetCustomerAsync("test");

            if (customerFromService != null && customerFromService.Id == @case.Customer.Id)
                Console.WriteLine("Found customer via Customer Service");
            else
                Console.WriteLine("Could not find customer via Customer Service");

            // delete all addresses that do not belong to case
            foreach(Address a in (await AddressService.GetAllAddressesAsync()))
            {
                Console.WriteLine(a.StreetName);
                var addressFromService = await AddressService.GetAddressAsync(a.Id);
                if (addressFromService.Id == a.Id)
                    Console.WriteLine("Matched address from service");
            }

            // test to create address via service 
            Address address = new Address
            {
                City = "Staden 2",
                PostalCode = "99999",
                StreetName = "Vagen 4"
            };

            //await AddressService.UpdateAddressAsync(5, address);

            var address1 = await AddressService.GetAddressAsync(1);

            if ((await AddressService.GetAddressAsync(1)) == null)
            {

            }

            CommentEntity commentEntity = new CommentEntity
            {
                Case = @case,
                Created = DateTime.UtcNow,
                Customer = @case.Customer,
                Description = "This is a comment",
                EntryTime = DateTime.UtcNow
            };

            context.Comments.Add(commentEntity);
            context.SaveChanges();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Test();
            //AddressEntity address = new AddressEntity
            //{
            //    Id = 0,
            //    StreetName = "Test",
            //    City= "Test",
            //    PostalCode = "Test"
            //};

            //context.Add(address);

            //CustomerEntity customer = new CustomerEntity
            //{
            //    Id = new Guid(),
            //    Addresses = new List<AddressEntity> { address },
            //    Email = "test",
            //    FirstName= "Test",
            //    LastName= "Test",
            //    PhoneNumber = "Test"
            //};

            //context.Add(customer);

            //CaseEntity @case = new CaseEntity()
            //{
            //    CaseNumber = "C0",
            //    OrderDate= DateTime.Now,
            //    CustomerEmail = "test",
            //    CustomerName= "test",
            //    CustomerPhoneNumber= "test",
            //    Description= "test",
            //    Address= address,
            //    EntryDate= DateTime.Now,
            //    Status= "test",
            //    Customer = customer
            //};
            //context.Cases.Add(@case);
            //context.SaveChanges();

            //Console.WriteLine("Cases in db: " + context.Cases.Count());


            MainWindow = new MainWindow()
            {
                DataContext = new MainWindow()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
