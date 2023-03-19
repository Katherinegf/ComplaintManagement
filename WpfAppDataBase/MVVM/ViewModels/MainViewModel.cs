using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableObject currentViewModel;

        public ICommand GoToAddCases
        {
            get { return new DelegateCommand<object>(CallGoToAddCases, EvaluateGoToAddCases); }
        }

        private void CallGoToAddCases(object context)
        {
            //this is called when the button is clicked
            CurrentViewModel = new AddCaseViewModel();

        }

        private bool EvaluateGoToAddCases(object context)
        { 
            return true;
        }

        public MainViewModel()
        {
            CurrentViewModel = new AddCaseViewModel();
        }

        [RelayCommand]
        public void GoToCustomers()
        {
            CurrentViewModel = new CustomerViewModel();
        }

        [RelayCommand]
        public void GoToAddress()
        {
            CurrentViewModel = new AddressViewModel();
        }
    }
}