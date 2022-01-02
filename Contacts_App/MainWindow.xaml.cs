using System.Windows;
using Contacts_App.Windows;
using Contacts_App.Classes;
using SQLite;

using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Contacts_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public TextChangedEventHandler TextBox_TextChanged { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadDataBase();
        }

        private void NewContactWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDataBase();
        }

        void ReadDataBase()
        {
      
            using (SQLiteConnection connection = new SQLiteConnection(App.DataBasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList().OrderBy(contact => contact.FirstName).ToList();
            }

           if(contacts != null) ContactsListView.ItemsSource = contacts; 
        }


        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var FilteredList = contacts.Where(contact => contact.FirstName.ToLower().Contains(FilterBox.Text.ToLower()) || contact.LastName.ToLower().Contains(FilterBox.Text.ToLower())).ToList();
            ContactsListView.ItemsSource = FilteredList;
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact contact = (Contact)ContactsListView.SelectedItem;

            if (contact != null)
            {
                ContactDetailWindow contactDetailWindow = new ContactDetailWindow(contact);
                contactDetailWindow.ShowDialog();

                ReadDataBase();
            }
        }
    }
}
