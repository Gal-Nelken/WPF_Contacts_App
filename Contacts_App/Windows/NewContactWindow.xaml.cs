using Contacts_App.Classes;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SQLite;

namespace Contacts_App.Windows
{
    /// <summary>
    /// Interaction logic for NewContact.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                Email = EmailBox.Text,
                Phone = PhoneBox.Text
            };



            using (SQLiteConnection connection = new SQLiteConnection(App.DataBasePath))
            { 
            connection.CreateTable<Contact>();
            connection.Insert(contact);
            }

            Close();
        }
    }
}
