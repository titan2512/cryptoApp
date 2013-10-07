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
                _encrypting.OpenKey = new Key(int.Parse(textBox1.Text), int.Parse(textBox3.Text));
                _encrypting.CloseKey = new Key(int.Parse(textBox2.Text), int.Parse(textBox4.Text));
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
            _encrypting.InitKeyData();
            textBox1.Text = _encrypting.OpenKey.FirstPart.ToString();
            textBox3.Text = _encrypting.OpenKey.SecondPart.ToString();
            textBox2.Text = _encrypting.CloseKey.FirstPart.ToString();
            textBox4.Text = _encrypting.CloseKey.SecondPart.ToString();
        }
    }
}
