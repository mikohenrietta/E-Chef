using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Chef
{
    public partial class Form3 : Form
    {
        private Form previous;
        public Form3(Form previous)
        {
            InitializeComponent();
            this.previous = previous;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new ec_applicationContext();
            var foundUserindb = db.Felhasznaloks.FirstOrDefault(x => x.Felhasznalonev == textBox1.Text && x.Jelszo == textBox2.Text);
            
            var list = db.Felhasznaloks.Where(x => x.Felhasznalonev !=null);
          
            if (foundUserindb != null) {
                MessageBox.Show("Sikeres bejelentkezés!");
                this.Hide();
                Form4 f4 = new Form4(this);
                f4.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Nincs ilyen felhasználó!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            previous.Show();
            Close();
        }
    }
}
