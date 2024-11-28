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
    public partial class Form2 : Form
    {
        private Form previous;
        public Form2(Form previous)
        {
            InitializeComponent();
            this.previous = previous;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var toInsert = new Felhasznalok();
            if(textBox2.Text==textBox3.Text)
            {
                toInsert.Felhasznalonev = textBox1.Text;
                toInsert.Jelszo = textBox2.Text;

                var db = new ec_applicationContext();

                db.Felhasznaloks.Add(toInsert);
                db.SaveChanges();
                MessageBox.Show("Sikeres regisztrálás");
                this.Hide();
                Form3 f3 = new Form3(previous);
                f3.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Nem egyezik meg a két jelszó!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            previous.Show();
            Close();
        }
    }
}
