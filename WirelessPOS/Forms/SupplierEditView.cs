using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class SupplierEditView : Form
    {
        private readonly Form owner;
        private WaitWin wait;
        public Supplier Entity { get; private set; }
        public Adapter Adapter { get; }

        public SupplierEditView(Adapter adapter, int id, Form owner = null)
        {
            Adapter = adapter;
            this.owner = owner;

            InitializeComponent();
            InitializeForm(id);
        }

        private void InitializeForm(int id)
        {
            wait = new WaitWin("Loading View");
            wait.Show();
            LoadComponents(id);
        }

        private async void LoadComponents(int id)
        {
            if (id == 0) Entity = new Supplier();
            else
            {
                Entity = await Adapter.Retrive<Supplier>(id);
                if (Entity == null)
                {
                    wait.Close();
                    Message.Stop("No supplier found to show.");
                    this.Dispose();
                    return;
                }
            }

            BindEntity();

            InvalidateForm();
            Display();

        }

        public void BindEntity()
        {
            supplierBindingSource.Clear();
            supplierBindingSource.Add(Entity);
        }

        private void Display()
        {
            wait.Close();
            if (owner == null) return;
            this.ShowDialog(owner);

        }

        public void InvalidateForm()
        {
            if (Entity.IsNew)
            {
                lblTitle.Text = "          New Supplier";
                btnDelete.Enabled = false;
            }
            else
            {
                lblTitle.Text = "          Edit Supplier";
                btnDelete.Enabled = true;
            }
        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (Entity.HasErrors(out string errors))
            {
                Message.Error("Please fix the following errors to continue:\n" + errors);
                return;
            }
            if (btnSave.IsBusy()) return;
            btnSave.MarkBusy(out Image image, out Color color);
            var found =
                (await Adapter.Retrive<Supplier>())?.ToList()
                .FindAll(x => XString.Equal(x.Phone, Entity.Phone))
                .Except(new Supplier[] { Entity })?.ToList();

            if (found != null && found.Count > 0) Message.Error("Supplier already exists with same contact number.");
            else
            {
                int change = await Adapter.Save(Entity); 
                if (change>0)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            btnSave.MarkFree(image, color);
            InvalidateForm();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Message.Question("Are you sure you want to delete this supplier?") == DialogResult.No)
            {
                return;
            }

            if (btnDelete.IsBusy()) return;
            btnDelete.MarkBusy(out Image image, out Color color);
            int changes = await Adapter.Remove(Entity);
            btnDelete.MarkFree(image, color);
            if (changes <= 0) return;
            DialogResult = DialogResult.OK;
        }

    }
}
