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
    public partial class SuccessWin : Form
    {
        private readonly DateTime startedAt;
        private readonly int disposeAfter;

        public SuccessWin(string message, int disposeAfter = 3)
        {
            InitializeComponent();
            lblMessage.Text = message;
            timer.Enabled = true;
            startedAt = DateTime.Now;
            this.disposeAfter = disposeAfter;
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var elapsed = DateTime.Now - startedAt;
            if (elapsed.TotalSeconds >= disposeAfter)
            {
                this.Close();
            }
        }
    }
}
