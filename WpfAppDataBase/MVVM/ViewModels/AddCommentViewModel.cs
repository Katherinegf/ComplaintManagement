using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDataBase.MVVM.Models;
using WpfAppDataBase.MVVM.Models.Entities;
using WpfAppDataBase.Services;

namespace WpfAppDataBase.MVVM.ViewModels;
public partial class AddCommentViewModel : ObservableObject
{
    [ObservableProperty]
    public Case currentTask = null!;

    [ObservableProperty]
    public string id;

    [ObservableProperty]
    private string? description;

    [ObservableProperty]
    public DateTime entryTime;

    [ObservableProperty]
    public string status;

    [ObservableProperty]
    private string firstName = string.Empty;

    [ObservableProperty]
    public string lastName = string.Empty;

    [ObservableProperty]
    public string email = string.Empty;

    [ObservableProperty]
    public string? phoneNumber = string.Empty;

    [ObservableProperty]
    public string comment = string.Empty;

    [ObservableProperty]
    public string selectedStatus = "Välj en uppdaterad status:";

    [ObservableProperty]
    private ObservableCollection<Customer> customersList = null!;

    public AddCommentViewModel()
    {
    }

    public async Task populateCustomersList()
    {
        CustomersList = new ObservableCollection<Customer>(await CustomerService.GetAllCustomersAsync());
    }

    public AddCommentViewModel(Case currentCase, ObservableCollection<Customer> customers)
    {

        customersList = customers;
        Task.Run(async () => await populateCustomersList());

        currentTask = currentCase;

        id = currentTask.CaseNumber;
        description = currentTask.Description;
        entryTime = currentTask.EntryDate;

        //Convert the enum to a string, in swedish:
        if (currentTask.Status == "NotStarted")
            status = "Ej påbörjad";
        else if (currentTask.Status == "InProgress")
            status = "Pågående";
        else if (currentTask.Status == "Completed")
            status = "Avslutad";
        firstName = currentTask.CustomerName;
        //lastName = currentTask.CustomerLastName;
        email = currentTask.CustomerEmail;

        //Check if there is a phonenumber in the db and if there isn't any,
        //sets it to a string-message for the frontend:
        if (currentTask.CustomerPhoneNumber == "             ")
            phoneNumber = "Inget telefonnummer angivet.";
        else
            phoneNumber = currentTask.CustomerPhoneNumber;

    }

    [RelayCommand]
    public async Task UpdateStatusAsync()
    {
        if (SelectedStatus != "Välj en uppdaterad status:")
        {

            if (SelectedStatus == "Ej påbörjad")
                Status = "NotStarted";
            else if (SelectedStatus == "Pågående")
                Status = "InProgress";
            else if (SelectedStatus == "Avslutad")
                Status = "Completed";

            
        }
    }
}
