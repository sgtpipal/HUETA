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
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public OrdersWindow()
        {
            InitializeComponent();
        }

        private void Added(object sender, RoutedEventArgs e)
        {
            AddingOrders ao = new AddingOrders();
            ao.Show();
            this.Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить выбранную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (OrdersList.SelectedIndex >= 0)
                {
                    Orders orders = (Orders)OrdersList.SelectedItem;
                    db.Orders.Remove(db.Orders.Single(q => q.IDOrder == orders.IDOrder));
                    db.SaveChanges();

                    OrdersList.ItemsSource = db.Orders.ToList();
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrdersList.ItemsSource = db.Orders.ToList();
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            mw.Show();
            this.Close();
        }
    }
}
