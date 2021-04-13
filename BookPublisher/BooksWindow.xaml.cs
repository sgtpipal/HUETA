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
    /// Логика взаимодействия для BooksWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public BooksWindow()
        {
            InitializeComponent();
        }

        private void Added(object sender, RoutedEventArgs e)
        {
            AddingBooks ab = new AddingBooks();
            ab.Show();
            this.Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить выбранную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (BooksList.SelectedIndex >= 0)
                {
                    Books books = (Books)BooksList.SelectedItem;
                    db.Books.Remove(db.Books.Single(q => q.IDBook == books.IDBook));
                    db.SaveChanges();

                    BooksList.ItemsSource = db.Books.ToList();
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BooksList.ItemsSource = db.Books.ToList();
        }

        private void Backward(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            mw.Show();
            this.Close();
        }
    }
}

    
