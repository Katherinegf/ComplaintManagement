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
using WpfAppDataBase.MVVM.Models.Entities;
using WpfAppDataBase.Services;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class AddCaseViewModel : ObservableObject
    {
        public AddCaseViewModel()
        {
            LoadCasesAsync(GetAddresses()).ConfigureAwait(false);
        }

        [ObservableProperty]
        private string pageTitle = "Skapa ärende.";

        [ObservableProperty]
        private string casenumber = string.Empty;

        [ObservableProperty]
        private string customername = string.Empty;

        [ObservableProperty]
        private string customeremail = string.Empty;

        [ObservableProperty]
        private string customerphonenumber = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private ObservableCollection<Address>? addresses;

        [ObservableProperty]
        public Address selectedAddress = null!;

     

        public ObservableCollection<Address>? GetAddresses()
        {
            return addresses;
        }

        public async Task LoadCasesAsync(ObservableCollection<Address>? addresses)
        {
            Addresses = new ObservableCollection<Address>(await AddressService.GetAllAddressesAsync());
        }


        [RelayCommand]
        public async Task SaveCaseAsync()
        {
            await CaseService.SaveCaseAsync(new Case
            {
                CaseNumber = Casenumber,
                EntryDate = DateTime.Now,
                CustomerName = Customername,
                CustomerEmail = Customeremail,
                CustomerPhoneNumber = Customerphonenumber,
                Description = Description,
                Status = "Ej Påbörjad"
            });

            Casenumber = string.Empty;
            Customername = string.Empty;
            Customeremail = string.Empty;
            Customerphonenumber = string.Empty;
            Description = string.Empty;

            MessageBox.Show($"Ärende {Casenumber} är skapad.");
        }
    }
}
