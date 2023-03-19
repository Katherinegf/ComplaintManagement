using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDataBase.MVVM.ViewModels
{
    public partial class ListCasesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Alla ärenden.";

        /*[ObservableProperty]
        private ObservableCollection<Case>? cases;

        public ListCasesViewModel()
        {
            LoadCasesAsync().ConfigureAwait(false);
        }

        public async Task LoadCasesAsync()
        {
            Cases = new ObservableCollection<Case>(await CaseService.GetAllCasesAsync());
        }*/
    }
}