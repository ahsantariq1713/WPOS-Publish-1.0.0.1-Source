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

namespace WirelessPOS
{
    public partial class PrintPreview : Form
    {
        public PrintPreview(PrintDocument document) 
        {
            InitializeComponent();
            printPreviewControl1.Document = document;
            printPreviewControl1.Zoom = 1;
        }
    }
}
