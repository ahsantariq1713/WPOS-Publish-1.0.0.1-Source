using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirelessPOS
{
    public class DGColumn
    {
        public DGColumn(string column,int displayIndex,int width)
        {
            Column = column;
            DisplayIndex = displayIndex;
            Width = width;
        }
        public string Column { get; set; }
        public int DisplayIndex { get; set; }
        public int Width { get; set; }
    }
}
