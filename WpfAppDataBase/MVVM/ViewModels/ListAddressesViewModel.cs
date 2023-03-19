using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class ListAddressesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Alla Adresser";

    }
}
