using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppDataBase.MVVM.Models;
using WpfAppDataBase.Services;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class AllListsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Hela Listan";

        [ObservableProperty]
        private ObservableCollection<Customer>? customers;

        [ObservableProperty]
        private ObservableCollection<Case>? cases;

        [ObservableProperty]
        private ObservableCollection<Address>? addresses;

        public AllListsViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Addresses = new ObservableCollection<Address>(await AddressService.GetAllAddressesAsync());
            Customers = new ObservableCollection<Customer>(await CustomerService.GetAllCustomersAsync());
            Cases = new ObservableCollection<Case>(await CaseService.GetAllCasesAsync());
        }

        [ObservableProperty]
        public Case selectedCase = null!;

        [ObservableProperty]
        public Customer selectedCustomer = null!;

        [ObservableProperty]
        public Address selectedAddress = null!;

        [RelayCommand]
        public async Task RemoveAddress()
        {
            MessageBox.Show($"Är du säker att du vill ta bort: {SelectedAddress.StreetName}?");
            //await AddressService.RemoveAddressAsync(selectedAddress);
        }

        [RelayCommand]
        public async Task RemoveCustomer(Customer selectedCustomer)
        {
            MessageBox.Show($"Är du säker att du vill ta bort: {SelectedCustomer.FirstName} {SelectedCustomer.LastName}?");
            // await CustomerService.RemoveCustomerAsync(selectedCustomer);
        }

        [RelayCommand]
        public async Task RemoveCAse(string selectedCase)
        {
            MessageBox.Show($"Är du säker att du vill ta bort {SelectedCase.CaseNumber}");
            await CaseService.RemoveCaseAsync(selectedCase);
        }
    }
}

