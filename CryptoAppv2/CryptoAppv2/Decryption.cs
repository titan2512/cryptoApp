using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Contracts;

namespace CryptoAppv2
{
    public partial class Decryption : Form
    {
        public long t = 0L;
        public Decryption()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contract.Assert(Int64.TryParse(textBox1.Text, out t), "Ключ введен неверно!");     
            DecryptionAld.SecretKey = t;
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
