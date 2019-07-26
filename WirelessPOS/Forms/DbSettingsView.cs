using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WirelessPOS.Utility;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class DbSettingsView : Form
    {
        public MySqlConnection Connection { get; set; }
        public DbSettingsView(Form owner = null)
        {
            //Owner = owner;
            Connection = new MySqlConnection();
            InitializeComponent();
            BindEntity();
            Show(owner);
        }

        private void BindEntity()
        {
            mySqlConnectionBindingSource.Clear();
            mySqlConnectionBindingSource.Add(Connection);
        }

        private void Show(Form owner)
        {
            if (owner == null) return;
            this.ShowDialog(owner);
        }

        private void BtnSaveClose_Click(object sender, EventArgs e)
        {
            Connection.Save();
            DialogResult = DialogResult.OK;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.IsBusy()) return;
            btnSave.MarkBusy(out Image image, out Color color);
            var connection = MySqlConnection
               .CreateConnection(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            var adapter = await Adapter.CreateInstance(connection, "Connecting to database...");
            btnSave.MarkFree(image, color);
            if (adapter != null) Message.Info("Database connection successful.");
        }
    }
}
