using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodexoftSoftLock
{
    public partial class TiralDialog : Form
    {
        private string _Pass;

        public TiralDialog(string BaseString,
            string Password,int DaysToEnd,int Runed, string info)
        {
            InitializeComponent();
            sebBaseString.Text = BaseString;
            _Pass = Password;
            lblDays.Text = DaysToEnd.ToString() + " Day(s)";
            lblTimes.Text = Runed.ToString() + " Time(s)";
            lblText.Text = info;
            if (DaysToEnd <= 0 || Runed <= 0)
            {
                lblDays.Text = "Finished";
                lblTimes.Text = "Finished";
                btnTrial.Enabled = false;
            }

            sebPassword.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_Pass == sebPassword.Text)
            {
                MessageBox.Show("Serial is correct. License installed successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Serial is incorrect.", "Activation Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }
    }
}