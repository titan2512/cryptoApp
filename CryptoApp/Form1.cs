using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoApp
{
    public partial class Form1 : Form
    {
        private KeysForm keysForm;
        private Encrypting encrypting;

        public Form1()
        {
            InitializeComponent();
            encrypting = new Encrypting();
            encrypting.OpenKey = null;
            encrypting.CloseKey = null;
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keysForm = new KeysForm(encrypting);
            keysForm.Visible = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = encrypting.Encrypt(richTextBox1.Text);
        }
    }
}
