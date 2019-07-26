using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WirelessPOS.Utility;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class PrintSettingsView : Form
    { 
        public PrintSettingsView(Form owner = null)
        {
            //Owner = owner;
            InitializeComponent();
            LoadPrinterDropDowns();
            Show(owner);
        }

        private void LoadPrinterDropDowns()
        {
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                ddlReceiptPrinter.Items.Add(printer);
                ddlReportPrinter.Items.Add(printer);
            }
        }

        private void Show(Form owner)
        {
            if (owner == null) return;
            this.ShowDialog(owner);
        }

        private void BtnSaveClose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

      
    }
}
