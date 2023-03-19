using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppDataBase.MVVM.Models;
using WpfAppDataBase.Services;

namespace WpfAppDataBase.MVVM.ViewModels // Jag har ej hunnit göra klart för jag har varit sjuk och är det fortfarande. Får kompletera.
{
    public partial class AddAddressViewModel : ObservableObject
    {
        public AddAddressViewModel()
        {
        }

        [ObservableProperty]
        private string pageTitle = "Skapa kontakt";

        [ObservableProperty]
        private string streetName = string.Empty;

        [ObservableProperty]
        private string city = string.Empty;

        [ObservableProperty]
        private string postalcode = string.Empty;

        [RelayCommand]
        public async Task SaveAddressAsync()
        {
            await AddressService.SaveAddressAsync(new Address
            {
                StreetName = StreetName,
                City = City,
                PostalCode = Postalcode
            });

            StreetName = string.Empty;
            City = string.Empty;
            Postalcode = string.Empty;

            MessageBox.Show($"Adress {StreetName} är skapad.");
        }

       
    }
}