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
    /// Логика взаимодействия для AddingAuthors.xaml
    /// </summary>
    public partial class AddingAuthors : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public AddingAuthors()
        {
            InitializeComponent();
        }

        private void Adding(object sender, RoutedEventArgs e)
        {
            AddAuthor(Surname.Text, FirstName.Text, MiddleName.Text);
        }

        private void BackWard(object sender, RoutedEventArgs e)
        {
            AuthorsWindow aw = new AuthorsWindow();
            aw.Show();
            this.Close();
        }

        public bool AddAuthor(string Surname, string FirstName, string MiddleName)
        {
            if (Surname == "" || FirstName == "" || MiddleName == "")
            {
                MessageBox.Show("Возникла ошибка! Возможно вы не заполнили поля");
                return false;
            }
            else
            {
                Authors authors = new Authors();

                authors.Surname = Surname;
                authors.FirstName = FirstName;
                authors.MiddleName = MiddleName;

                db.Authors.Add(authors);
                db.SaveChanges();
                MessageBox.Show("Добавлен автор");
                AuthorsWindow aw = new AuthorsWindow();
                aw.Show();
                this.Close();
                return true;
            }
        }
    }
}
