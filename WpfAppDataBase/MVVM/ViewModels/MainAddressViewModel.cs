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
    public partial class MainAddressViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Lägg till adress";

        [ObservableProperty]
        private ObservableCollection<Address>? addresses;

        [ObservableProperty]
        public Address selectedAddress = null!;

        public MainAddressViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Addresses = new ObservableCollection<Address>(await AddressService.GetAllAddressesAsync());
        }

        [RelayCommand]
        public async Task EditAddress()
        {
            MessageBox.Show($"Adress {SelectedAddress.StreetName} {SelectedAddress.PostalCode} {SelectedAddress.City} är uppdaterad.");
            await UpdateAddress(SelectedAddress.Id, SelectedAddress);
        }
        public async Task UpdateAddress(int id, Address address)
        {
            await AddressService.UpdateAddressAsync(id, address);
        }
    }
}
