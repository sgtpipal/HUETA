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
    /// Логика взаимодействия для AddingOrders.xaml
    /// </summary>
    public partial class AddingOrders : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public AddingOrders()
        {
            InitializeComponent();
            IDStatusOrder.ItemsSource = db.StatusOrder.ToList();
            IDStatusOrder.DisplayMemberPath = "NameStatus";
            IDStatusOrder.SelectedValuePath = "IDStatusOrder";

            IDBook.ItemsSource = db.Books.ToList();
            IDBook.DisplayMemberPath = "BookTitle";
            IDBook.SelectedValuePath = "IDBook";

            IDCustomer.ItemsSource = db.Customers.ToList();
            IDCustomer.DisplayMemberPath = "NameCustomer";
            IDCustomer.SelectedValuePath = "IDCustomer";
        }

        private void Adding(object sender, RoutedEventArgs e)
        {
            if (NumberOrder.Text == "" || DateOrder.Text == "" || CostOrder.Text == "" || IDStatusOrder.SelectedValue.ToString() == "" || IDBook.SelectedValue.ToString() == "" || IDCustomer.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Возникла ошибка! Возможно вы не заполнили поля");
                return;
            }
            else
            {
                Orders orders = new Orders();
                orders.NumberOrder = Convert.ToInt32(NumberOrder.Text);
                orders.DateOrder = Convert.ToDateTime(DateOrder.Text);
                orders.CostOrder = Convert.ToInt32(CostOrder.Text);
                orders.IDStatusOrder = Convert.ToInt32(IDStatusOrder.SelectedValue.ToString());
                orders.IDBook = Convert.ToInt32(IDBook.SelectedValue.ToString());
                orders.IDCustomer = Convert.ToInt32(IDCustomer.SelectedValue.ToString());

                db.Orders.Add(orders);
                db.SaveChanges();
                MessageBox.Show("Добавлен заказ");
                OrdersWindow ow = new OrdersWindow();
                ow.Show();
                this.Close();
            }
        }

        private void BackWard(object sender, RoutedEventArgs e)
        {
            BooksWindow bw = new BooksWindow();
            bw.Show();
            this.Close();
        }
    }
}
