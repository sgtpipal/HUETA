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
    /// Логика взаимодействия для AddingCustomers.xaml
    /// </summary>
    public partial class AddingCustomers : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public AddingCustomers()
        {
            InitializeComponent();
        }

        private void Adding(object sender, RoutedEventArgs e)
        {
            if (NameCustomer.Text == "" || PhoneNumber.Text == "" || Adress.Text == "")
            {
                MessageBox.Show("Возникла ошибка! Возможно вы не заполнили поля");
                return;
            }
            else
            {
                Customers customers = new Customers();
                customers.NameCustomer = NameCustomer.Text;
                customers.PhoneNumber = Convert.ToInt32(PhoneNumber.Text);
                customers.Adress = Adress.Text;

                db.Customers.Add(customers);
                db.SaveChanges();
                MessageBox.Show("Добавлен заказчик");
                CustomersWindow cw = new CustomersWindow();
                cw.Show();
                this.Close();
            }
        }

        private void BackWard(object sender, RoutedEventArgs e)
        {
            CustomersWindow cw = new CustomersWindow();
            cw.Show();
            this.Close();
        }
    }
}
