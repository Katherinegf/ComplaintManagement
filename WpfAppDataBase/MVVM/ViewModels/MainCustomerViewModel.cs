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
    public partial class MainCustomerViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Skapa en kontakt";

        [ObservableProperty]
        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        [ObservableProperty]
        private Customer? selectedCustomer;

        public async Task EditCustomer()
        {
            MessageBox.Show($"Kunden {SelectedCustomer?.FirstName} {SelectedCustomer?.LastName} är uppdaterad.");
            await CustomerService.UpdateCustomerAsync(SelectedCustomer.Id, SelectedCustomer);
        }
        public async Task Update(Guid id, Customer customer)
        {
            await CustomerService.UpdateCustomerAsync(id, customer);
        }

        [RelayCommand]
        public async Task Remove(string selectedCustomer)
        {
            MessageBox.Show($"Är du säker att du vill ta bort kontakten: {selectedCustomer} {selectedCustomer}?");
            await CustomerService.RemoveCustomerAsync(selectedCustomer);
        }

    }
}
