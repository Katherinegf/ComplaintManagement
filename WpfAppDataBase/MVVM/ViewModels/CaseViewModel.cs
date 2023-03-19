using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class CaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        public CaseViewModel()
        { 
            currentViewModel = new ListCasesViewModel();
        }

        [RelayCommand]
        public void GoToAddCase()
        {
            CurrentViewModel = new AddCaseViewModel();
        }

        [RelayCommand]
        public void GoToCaseList()
        {
            CurrentViewModel = new AllListsViewModel();
        }

        [RelayCommand]
        public void GoToMAinCase()
        {
            CurrentViewModel = new MainCaseViewModel();
        }
    }
}