using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace CryptoApp
{
    public partial class KeysForm : Form
    {
        private readonly Encrypting _encrypting;
        public KeysForm(Encrypting encrypting)
        {
            InitializeComponent();
            _encrypting = encrypting;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty &&
                textBox4.Text != string.Empty)
            {
                _encrypting.OpenKey = new Key(Convert.FromBase64String(textBox1.Text), Convert.FromBase64String(textBox3.Text));
                _encrypting.CloseKey = new Key(Convert.FromBase64String(textBox2.Text), Convert.FromBase64String(textBox4.Text));
                Close();
            }
            else
            {
                MessageBox.Show(this, "Задайте значения закрытого и открытого ключа");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            RSAParameters paramsRSA = _encrypting.RsaProvider.ExportParameters(true);
            textBox1.Text = Convert.ToBase64String(paramsRSA.Exponent);
         
            textBox3.Text = Convert.ToBase64String(paramsRSA.D);
            textBox2.Text = Convert.ToBase64String(paramsRSA.Modulus);
            textBox4.Text = Convert.ToBase64String(paramsRSA.Modulus);
        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
