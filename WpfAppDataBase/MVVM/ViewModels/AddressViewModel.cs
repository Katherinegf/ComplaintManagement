using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class AddressViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        public AddressViewModel()
        {
        }


        [RelayCommand]
        public void GoToAddAddress()
        {
            CurrentViewModel = new AddAddressViewModel();
        }

        [RelayCommand]
        public void GoToAddressList()
        {
            CurrentViewModel = new AllListsViewModel();
        }

        [RelayCommand]
        public void GoToMainAddress()
        {
            CurrentViewModel = new MainAddressViewModel();
        }
    }
}


