using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WirelessPOS
{
    public interface IEntityForm<TView>
    {

        void BindEntity();
        void DeleteEntity();
        void InitializeForm(int id);
        void InvalidateForm();
        void SaveEntity();
        void Show(Form owner);
    }
}
