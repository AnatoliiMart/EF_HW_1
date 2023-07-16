using EF_HW_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_HW_1
{
    public partial class Form2 : Form
    {
        private MyDbContext _db;
        public Form2(Form1 form)
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (_db = new MyDbContext())
            {
                _db.AddBook(txtBox_BookName.Text, txtBox_Categrory.Text, txtBox_PressName.Text, int.Parse(txtBox_PagesCount.Text), txtBox_BookAuthor.Text);
            }
            ClearTxtBoxes();
            Close();
        }


        private void ClearTxtBoxes()
        {
            txtBox_BookAuthor.Text = string.Empty;
            txtBox_BookName.Text = string.Empty;
            txtBox_Categrory.Text = string.Empty;
            txtBox_PagesCount.Text = string.Empty;
            txtBox_PressName.Text = string.Empty;
        }
    }
}
