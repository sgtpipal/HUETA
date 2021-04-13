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

namespace BookPublisher
{
    /// <summary>
    /// Логика взаимодействия для CustomersWindow.xaml
    /// </summary>
    public partial class CustomersWindow : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public CustomersWindow()
        {
            InitializeComponent();
        }

        private void Added(object sender, RoutedEventArgs e)
        {
            AddingCustomers ac = new AddingCustomers();
            ac.Show();
            this.Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить выбранную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (CustomersList.SelectedIndex >= 0)
                {
                    Customers customers = (Customers)CustomersList.SelectedItem;
                    db.Customers.Remove(db.Customers.Single(q => q.IDCustomer == customers.IDCustomer));
                    db.SaveChanges();

                    CustomersList.ItemsSource = db.Customers.ToList();
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CustomersList.ItemsSource = db.Customers.ToList();
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            mw.Show();
            this.Close();
        }
    }
}
