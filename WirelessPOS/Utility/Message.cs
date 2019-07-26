using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WirelessPOS
{
    public static class Message
    {
        public static DialogResult Info(string message)
        {
           return MessageBox.Show(message, "Heads Up!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Success(string message)
        {
            // return new SuccessWin(message).ShowDialog();
            return MessageBox.Show(message, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Error(string message)
        {
            //return new ErrorWin(message).ShowDialog();
            return MessageBox.Show(message, "Oh Snap!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Stop(string message)
        {
            return MessageBox.Show(message, "Oh Snap!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public static DialogResult Warning(string message)
        {
            return MessageBox.Show(message, "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult Question(string message)
        {
            return MessageBox.Show(message, "Hold On!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
