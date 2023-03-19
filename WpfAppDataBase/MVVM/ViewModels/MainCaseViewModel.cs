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
    public partial class MainCaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Skapa ett ärende";

        [ObservableProperty]
        private ObservableCollection<Case> cases = new ObservableCollection<Case>();

        [ObservableProperty]
        public Case selectedCase = null!;

        [RelayCommand]
        public async Task EditStatusCase()
        {
            MessageBox.Show($"Status ändrat för kundnummer: {SelectedCase.CaseNumber}.");
            //await CaseService.UpdateStatusCaseAsync(SelectedCase.CaseNumber, SelectedCase);
        }
        public async Task UpdateStatusCase(string casenumber, Case @case)
        {
            //await CaseService.UpdateStatusCaseAsync(casenumber, @case);
        }

        [RelayCommand]
        public async Task AddComment(Comment comment)
        {
            MessageBox.Show($"Kommentar tillagd till {SelectedCase.CaseNumber}.");
            await CaseService.SaveCommentAsync(SelectedCase.CaseNumber, comment);
        }
        public async Task UpdateCommentCase(string customerid, Comment comment)
        {
            MessageBox.Show($"Kommentar tillagd till {SelectedCase.CaseNumber}.");
            await CaseService.SaveCommentAsync(SelectedCase.CaseNumber, comment);
        }

        [RelayCommand]
        public async Task EditCase()
        {
            MessageBox.Show($"Ärende med kundnummer {SelectedCase.CaseNumber} är uppdaterad. ");
            //await CaseService.UpdateCaseAsync(SelectedCase.CaseNumber, SelectedCase);
        }

        public async Task UpdateCase(string casenumber, Case @case)
        {
           
        }

        [RelayCommand]
        public async Task Remove(string selectedCaseNumber)
        {
            MessageBox.Show($"Är du säker att du vill ta bort {selectedCaseNumber}");
            await CaseService.RemoveCaseAsync(selectedCaseNumber);
        }

    }
}