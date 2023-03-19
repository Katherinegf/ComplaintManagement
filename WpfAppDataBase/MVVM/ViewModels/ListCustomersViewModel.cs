using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class ListCustomersViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Alla kunder";

        /*[ObservableProperty]
        private ObservableCollection<Customer>? customers;

        public ListCustomersViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Customers = new ObservableCollection<Customer>(await CustomerService.GetAllCustomersAsync());
        }*/
    }
}