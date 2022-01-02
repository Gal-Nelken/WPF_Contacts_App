using Contacts_App.Classes;
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

namespace Contacts_App.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {

        public Contact contact
        {
            get { return (Contact)GetValue(contactProperty); }
            set { SetValue(contactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty contactProperty =
            DependencyProperty.Register("contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact() { FirstName = "firstNAme", LastName = "Lastname", Email="example2@gmail.com", Phone="054-8987744"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;

            if(control != null)
            {
                control.firstNameTextBlock.Text = (e.NewValue as Contact).FirstName;
                control.lastNameTextBlock.Text = (e.NewValue as Contact).LastName;
                control.emailTextBlock.Text = (e.NewValue as Contact).Email;
                control.phoneTextBlock.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
