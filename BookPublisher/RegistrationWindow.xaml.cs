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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            Registr(Name.Text, Login.Text, Password.Password);
        }

        private void BackwardClick(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow auth = new AuthorizationWindow();
            auth.Show();
            this.Close();
        }

        public bool Registr(string Name, string Login, string Password)
        {
            if (Name == "" || Login == "" || Password == "")
            {
                MessageBox.Show("Возникла ошибка! Возможно вы не заполнили поля");
                return false;
            }
            if (db.Admininstration.Select(item => item.Login).Contains(Login))
            {
                MessageBox.Show("Возникла ошибка! Данный логин уже зарегистрирован в системе");
                return false;

            }
            else
            {
                Admininstration NewAdmin = new Admininstration();
                NewAdmin.Name = Name;
                NewAdmin.Login = Login;
                NewAdmin.Password = Password;

                db.Admininstration.Add(NewAdmin);
                db.SaveChanges();

            }
            MessageBox.Show("Вы успешно прошли регистрацию");
            AuthorizationWindow auth = new AuthorizationWindow();
            auth.Show();
            this.Close();
            return true;
        }
    }
}
