using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppDataBase.MVVM.Models;
using WpfAppDataBase.Services;

namespace WpfAppDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Customer> customers = new List<Customer>();
        public MainWindow()
        {
            InitializeComponent();
            
          
            
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            customers.Add(new Customer
            {
                //FirstName = tb_FirstName.Text,
                //LastName = tb_LastName.Text,
                //Email = tb_Email.text

            } );
            ClearForm();

        }

        private void ClearForm()
        {
            //tb_FirstName.Text = "";
            //tb_LastName.Text = "";
            //tb_Email.Text = "";
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
