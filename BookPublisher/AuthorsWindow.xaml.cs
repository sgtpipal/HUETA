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
    /// Логика взаимодействия для AuthorsWindow.xaml
    /// </summary>
    public partial class AuthorsWindow : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public AuthorsWindow()
        {
            InitializeComponent();
        }

        private void Added(object sender, RoutedEventArgs e)
        {
            AddingAuthors aa = new AddingAuthors();
            aa.Show();
            this.Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Authors authors = (Authors)AuthorsList.SelectedItem;
            DeleteAuthors(authors.IDAuthor);
            AuthorsList.ItemsSource = db.Authors.ToList();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            mw.Show();
            this.Close();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AuthorsList.ItemsSource = db.Authors.ToList();
        }

        public bool DeleteAuthors(int IDAuthor)
        {
            var result = MessageBox.Show("Вы точно хотите удалить выбранную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var query = db.Authors.SingleOrDefault(q => q.IDAuthor == IDAuthor);
                if (query != null)
                {
                    db.Authors.Remove(query);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}
