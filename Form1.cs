using EF_HW_1.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace EF_HW_1
{
    public partial class Form1 : Form
    {
        private MyDbContext _context = new MyDbContext();
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = _context.Books.ToList();
        }

        private void btn_AddBook_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.btn_Save.Text = "Добавить";
            form.btn_Save.BackColor = btn_AddBook.BackColor;
            form.ShowDialog();
            using (_context = new MyDbContext())
            {
                listBox1.DataSource = _context.Books.ToList();
            }
        }

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_SearchByAuthor.Checked)
            {
                using (_context = new MyDbContext())
                {
                    List<Book> books = _context.SearchByAuthor(textBox1.Text);

                    if (books.Count == 0 || textBox1.Text == string.Empty)
                    {
                        MessageBox.Show("Ничего не найдено!!!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Form3 form = new Form3(this);
                        form.lstBox_SearchResults.DataSource = books;
                        form.ShowDialog();
                    }
                }
            }
            else if (rdb_SearchByCategory.Checked)
            {
                using (_context = new MyDbContext())
                {
                    List<Book> books = _context.SearchByCategory(textBox1.Text);

                    if (books.Count == 0 || textBox1.Text == string.Empty)
                        MessageBox.Show("Ничего не найдено!!!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        Form3 form = new Form3(this);
                        form.lstBox_SearchResults.DataSource = books;
                        form.ShowDialog();
                    }
                }
            }
            else if (rdb_SearchByPressName.Checked)
            {
                using (_context = new MyDbContext())
                {
                    List<Book> books = _context.SearchByPressName(textBox1.Text);

                    if (books.Count == 0 || textBox1.Text == string.Empty)
                        MessageBox.Show("Ничего не найдено!!!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        Form3 form = new Form3(this);
                        form.lstBox_SearchResults.DataSource = books;
                        form.ShowDialog();
                    }
                }
            }
            else if (rdb_SearchByTitle.Checked)
            {
                using (_context = new MyDbContext())
                {
                    List<Book> books = _context.SearchByBookName(textBox1.Text);

                    if (books.Count == 0 || textBox1.Text == string.Empty)
                        MessageBox.Show("Ничего не найдено!!!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        Form3 form = new Form3(this);
                        form.lstBox_SearchResults.DataSource = books;
                        form.ShowDialog();
                    }
                }
            }
        }

        private void btn_UpdateBook_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(this);
            form.btn_Save.Text = "Изменить";
            form.btn_Save.BackColor = btn_UpdateBook.BackColor;
            form.ShowDialog();
            using (_context = new MyDbContext())
            {
                listBox1.DataSource = _context.Books.ToList();
            }
        }

        public Book GetOneBook() => listBox1.SelectedItem as Book;

        private void btn_DeleteBook_Click(object sender, EventArgs e)
        {
            using (_context = new MyDbContext())
            {
                Book book = GetOneBook();
                foreach (var item in _context.Books)
                {
                    if (item.Id == book.Id)
                    {
                        _context.Books.Remove(item);
                        break;
                    }
                }
                _context.SaveChanges();
                listBox1.DataSource = _context.Books.ToList();
            }
        }
    }
}
