using BarcodeStandard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WirelessPOS
{
    public partial class LicenseView : Form
    {
        public LicenseView()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (new JAN21().ValidateKey(Properties.Settings.Default.Key) == true)
            {
                Properties.Settings.Default.Save();
                Properties.Settings.Default.LisenceStatus = "User License";
                InvalidateForm();
                Message.Success("License key is successfully installed. Thanks for using Wireless POS");
            }
            else
            {
                Message.Error("Invalid license key. Purchase new key to activate the software or try again");
            }
        }

        private void LicenseView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.LisenceStatus != "User License")
            {
                Properties.Settings.Default.Key = string.Empty;
            }
        }

        private void LicenseView_Load(object sender, EventArgs e)
        {
            InvalidateForm();
        }

        private void InvalidateForm()
        {
            if (Properties.Settings.Default.LisenceStatus == "Trial")
            {
                btnActivate.Enabled = true;
                maskedTextBox1.Enabled = true;
            }
            else
               if (Properties.Settings.Default.LisenceStatus == "User License")
            {

                btnActivate.Enabled = false;
                maskedTextBox1.Enabled = false;

            }
        }
    }
}
