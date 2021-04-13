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
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void Authors(object sender, RoutedEventArgs e)
        {
            AuthorsWindow mw = new AuthorsWindow();
            mw.Show();
            this.Close();
        }

        private void Books(object sender, RoutedEventArgs e)
        {
            BooksWindow mw = new BooksWindow();
            mw.Show();
            this.Close();
        }

        private void Customers(object sender, RoutedEventArgs e)
        {
            CustomersWindow mw = new CustomersWindow();
            mw.Show();
            this.Close();
        }

        private void Orders(object sender, RoutedEventArgs e)
        {
            OrdersWindow mw = new OrdersWindow();
            mw.Show();
            this.Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow auth = new AuthorizationWindow();
            auth.Show();
            this.Close();
        }
    }
}
