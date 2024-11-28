using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Chef
{
    public partial class Form4 : Form
    {
        private Form previous;
        public Form4(Form previous)
        {
            InitializeComponent();
            this.previous = previous;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5(this);
            f5.Show();


        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8(this);
            f8.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            previous.Show();
            Close();
        }
    }
}
