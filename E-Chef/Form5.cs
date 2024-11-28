using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Globalization;

namespace E_Chef
{
    public partial class Form5 : Form
    {
        private Form bezaras;
       
        SerialPort serialPort;
        decimal talsuly = 0, alapanyagsuly = 0, lisztsuly = 0, cukorsuly = 0, vajsuly = 0, kakaosuly = 0, tejsuly = 0, kekszsuly = 0, diosuly = 0, tojassuly = 0, turosuly = 0, mezsuly = 0, lekvarsuly = 0, csokisuly = 0, tejszinsuly = 0, olajsuly = 0, almasuly = 0, epersuly = 0, szilvasuly = 0, oreosuly = 0, mascarponesuly = 0, karamellsuly=0,kokuszsuly=0;
        public Form5(Form bezaras)
        {
            InitializeComponent();
            this.bezaras = bezaras;
            
            
            serialPort = new SerialPort("COM5",57600);
            serialPort.ReadTimeout = 1000;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(Reader);
            serialPort.Open();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            button2.Visible = true;
            textBox2.Visible = true;
            string szoveg = textBox2.Text;
            try
            {
                talsuly=Convert.ToDecimal(szoveg, CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Invalid input, please enter a valid decimal number.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            try
            {
                alapanyagsuly = Convert.ToDecimal(textBox2.Text, CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Invalid input, please enter a valid decimal number.");
            }
            alapanyagsuly = alapanyagsuly - talsuly;

            if (comboBox1.SelectedItem == "Liszt")
            {
                lisztsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Cukor")
            {
                cukorsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Vaj")
            {
                vajsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Kakaó")
            {
                kakaosuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Tej")
            {
                tejsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Keksz")
            {
                kekszsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Dió")
            {
                diosuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Tojás")
            {
                tojassuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Túró")
            {
                turosuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Méz")
            {
                mezsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Lekvár")
            {
                lekvarsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Csoki")
            {
                csokisuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Tejszín")
            {
                tejszinsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Olaj")
            {
                olajsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Alma")
            {
                almasuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Eper")
            {
                epersuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Szilva")
            {
                szilvasuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Oreó")
            {
                oreosuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Mascarpone")
            {
                mascarponesuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Karamell")
            {
                karamellsuly = alapanyagsuly;
            }
            else if (comboBox1.SelectedItem == "Kókusz")
            {
                kokuszsuly = alapanyagsuly;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            button1.Visible = false;
            label3.Visible = false;
            button2.Visible = false;
            label4.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            textBox2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            var db = new ec_applicationContext();
            var foundrecipeindb = db.Recepteks.FirstOrDefault(x => x.Liszt <= lisztsuly && x.Cukor <= cukorsuly && x.Vaj <= vajsuly && x.Kakaó <= kakaosuly && x.Tej <= tejsuly && x.Keksz <= kekszsuly && x.Dió <= diosuly && x.Tojás <= tojassuly && x.Túró <= turosuly && x.Méz <= mezsuly && x.Lekvár <= lekvarsuly && x.Csoki <= csokisuly && x.Tejszín <= tejszinsuly && x.Olaj <= olajsuly && x.Alma <= almasuly && x.Eper <= epersuly && x.Szilva <= szilvasuly && x.Oreó <= oreosuly && x.Mascarpone <= mascarponesuly && x.Karamell <= karamellsuly && x.Kókusz <= kokuszsuly);
            if(foundrecipeindb!=null)
            {
                textBox1.Text = foundrecipeindb.Recept;
            }
            else
            {
                textBox1.Text = "Nincs ilyen recept";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            this.Close();
            bezaras.Show();
        }

      
        
        private void Reader(object sender, EventArgs e)
        {
            
            string text = serialPort.ReadExisting().ToString();
            SetText(text.Trim());
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if(this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d,new object[] { text });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }
    }
}
