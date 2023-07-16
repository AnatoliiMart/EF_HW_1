using EF_HW_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_HW_1
{
    public partial class Form4 : Form
    {
        private MyDbContext _db;
        private readonly Book _book;
        public Form4(Form1 form)
        {
            InitializeComponent();
            _book = form.GetOneBook();
            txtBox_BookAuthor.Text = _book.Author;
            txtBox_BookName.Text = _book.Name;
            txtBox_Categrory.Text = _book.Category;
            txtBox_PagesCount.Text = _book.PagesCount.ToString();
            txtBox_PressName.Text = _book.PressName;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (_db = new MyDbContext()) 
            {
                foreach (var item in _db.Books.ToList())
                {
                    if (item.Id == _book.Id)
                    {
                        item.Name = txtBox_BookName.Text;
                        item.Author = txtBox_BookAuthor.Text;
                        item.Category = txtBox_Categrory.Text;
                        item.PressName = txtBox_PressName.Text;
                        item.PagesCount = int.Parse(txtBox_PagesCount.Text);
                        _db.SaveChanges();
                        
                        break;
                    }
                }
            }
            Close();
        }
    }
}
