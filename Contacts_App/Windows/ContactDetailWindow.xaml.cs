using Contacts_App.Classes;
using SQLite;
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
using System.Windows.Shapes;

namespace Contacts_App.Windows
{
    /// <summary>
    /// Interaction logic for ContactDetailWindow.xaml
    /// </summary>
    public partial class ContactDetailWindow : Window
    {
        Contact contact;
        public ContactDetailWindow(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contact = contact;

            FirstNameBox.Text = contact.FirstName;
            LastNameBox.Text = contact.LastName; 
            EmailBox.Text = contact.Email;
            PhoneBox.Text = contact.Phone;
            
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            contact.FirstName = FirstNameBox.Text;
            contact.LastName = LastNameBox.Text;
            contact.Email = EmailBox.Text;
            contact.Phone = PhoneBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.DataBasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DataBasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            Close();
        }
    }
}
