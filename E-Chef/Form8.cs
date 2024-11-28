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
    public partial class Form8 : Form
    {
        private Form previous;

        public Form8(Form previous)
        {
            InitializeComponent();
            this.previous = previous;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = new ec_applicationContext();
            var foundRecipeindb = db.Recepteks.FirstOrDefault(x => x.Desszertnev == listBox1.SelectedItem);
            if (foundRecipeindb != null)
            {
                /*
                var list = db.Recepteks.Where(x => x.Desszertnev == listBox1.SelectedItem);
                foreach (var item in list)
                {
                    textBox1.Visible = true;
                    textBox1.Text = item.Recept;
                }*/
                textBox1.Visible = true;
                textBox1.Text = foundRecipeindb.Recept;
            }
            else
            {
                MessageBox.Show("Nincs ilyen recept");
            }
            textBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previous.Show();
        }
    }
}
