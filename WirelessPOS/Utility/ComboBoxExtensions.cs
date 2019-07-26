using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPos.Domain;

namespace WirelessPOS
{
    public static class ComboBoxExtensions
    {
        public static void NewItemCheck<TView>(this ComboBox combo, ref List<TView> items, ref Button btn)
        {
            if (combo == null) return;

            var text = combo.Text;
            if (text.IsNull())
            {
                btn.Enabled = false;
                return;
            }

            if (items == null)
            {
                btn.Enabled = true;
                return;
            }

            var found = items.Find(x => XString.Equal((x as IDropDown).Name, text));
            if (found != null) btn.Enabled = false;
            else btn.Enabled = true;
        }
    }
}
