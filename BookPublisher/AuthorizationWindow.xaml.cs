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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void AuthorizationClick(object sender, RoutedEventArgs e)
        {
            Authorize(Login.Text, Password.Password);
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow();
            rw.Show();
            this.Close();
        }

        public bool Authorize(string login, string password)
        {

            if (login == "" || password == "")
            {
                MessageBox.Show("Возникла ошибка! Возможно вы не заполнили поля");
                return false;
            }
            if (db.Admininstration.Select(item => item.Login + " " + item.Password).Contains(login + " " + password))
            {
                MessageBox.Show("Добро пожаловать, " + login);
                MenuWindow mw = new MenuWindow();
                mw.Show();
                this.Close();
                return true;

            }
            else
            {
                MessageBox.Show("Возникла ошибка! Наверное, вы ввели неправильно логин, либо пароль");
                return false;
            }
        }
    }
}
