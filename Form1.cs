using Select_Gender_from_Article.MyClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Select_Gender_from_Article
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click_Click(object sender, EventArgs e)
        {
            main obj = new main(txt_text.Text);
            lbl_Gender.Text = obj.getCinsiyet();
        }
    }
}
