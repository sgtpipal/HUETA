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
    /// Логика взаимодействия для AddingBooks.xaml
    /// </summary>
    public partial class AddingBooks : Window
    {
        BookPublisherEntities db = new BookPublisherEntities();
        public AddingBooks()
        {
            InitializeComponent();
            IDAuthor.ItemsSource = db.Authors.ToList();
            IDAuthor.DisplayMemberPath = "Surname";
            IDAuthor.SelectedValuePath = "IDAuthor";
        }

        private void Adding(object sender, RoutedEventArgs e)
        {
            if (BookTitle.Text == "" || Edition.Text == "" || ReleaseDate.Text == "" || CostPrice.Text == "" || IDAuthor.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Возникла ошибка! Возможно вы не заполнили поля");
                return;
            }
            else
            {
                Books books = new Books();
                books.BookTitle = BookTitle.Text;
                books.Edition = Edition.Text;
                books.ReleaseDate = Convert.ToDateTime(ReleaseDate.Text);
                books.CostPrice = Convert.ToInt32(CostPrice.Text);
                books.IDAuthor = Convert.ToInt32(IDAuthor.SelectedValue.ToString());

                db.Books.Add(books);
                db.SaveChanges();
                MessageBox.Show("Добавлена книга");
                BooksWindow bw = new BooksWindow();
                bw.Show();
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
