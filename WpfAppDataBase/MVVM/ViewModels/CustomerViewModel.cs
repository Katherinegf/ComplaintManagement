using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class CustomerViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        public CustomerViewModel()
        {
        }

        [RelayCommand]
        public void GoToAddCustomer()
        {
            CurrentViewModel = new AddCustomerViewModel();
        }

        [RelayCommand]
        public void GoToCustomerList()
        {
            CurrentViewModel = new AllListsViewModel();
        }

        [RelayCommand]
        public void GoToSpecCustomer()
        {
            CurrentViewModel = new MainCustomerViewModel();
        }
    }
}