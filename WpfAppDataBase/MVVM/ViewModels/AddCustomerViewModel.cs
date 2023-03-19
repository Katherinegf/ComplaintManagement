using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using WpfAppDataBase.MVVM.Models;
using WpfAppDataBase.Services;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class AddCustomerViewModel :ObservableObject
    {
        public AddCustomerViewModel()
        {
        }

        [ObservableProperty]
        private string pageTitle = "Lägg till en kund.";

        [ObservableProperty]
        private string firstname = string.Empty;

        [ObservableProperty]
        private string lastname = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phonenumber = string.Empty;

        [RelayCommand]
        public async Task SaveAsync()
        {
            await CustomerService.SaveCustomerAsync(new Customer
            {
                FirstName = Firstname,
                LastName = Lastname,
                Email = Email,
                PhoneNumber = Phonenumber
            });

            Firstname = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Phonenumber = string.Empty;

            MessageBox.Show($"Kunden {Firstname} är tillagd.");
        }

       
    }
}


