using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Serial_Maker
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                stbPass.Text = CodexoftSoftLock.Encryption.MakePassword(stbBase.Text, txtIdentifier.Text);
                button1.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can't make password\n" + ex.Message);
                stbPass.Text = string.Empty;
                button1.Enabled = false;
            }
        }
    }
}