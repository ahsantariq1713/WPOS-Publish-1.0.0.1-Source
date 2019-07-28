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
    public partial class OperatorEditView : Form
    {
        private readonly Form owner;
        private WaitWin wait;
        public Operator Entity { get; private set; }
        public Adapter Adapter { get; }

        public OperatorEditView(Adapter adapter, int id, Form owner = null)
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
            if (id == 0) Entity = new Operator();
            else
            {
                Entity = await Adapter.Retrive<Operator>(id);
                if (Entity == null)
                {
                    wait.Close();
                    Message.Stop("No operator found to show.");
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
            operatorBindingSource.Clear();
            operatorBindingSource.Add(Entity);
            if (Entity.Role == Role.Administrator)
            {
                radioAdmin.Checked = true;
                radioUser.Checked = false;
            }
            else{
                radioAdmin.Checked = false;
                radioUser.Checked = true;
            }
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
                lblTitle.Text = "          New Operator";
                btnDelete.Enabled = false;
            }
            else
            {
                lblTitle.Text = "          Edit Operator";
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
            ValidateChildren();
            btnSave.MarkBusy(out Image image, out Color color);
            Entity.Password = Security.GetSHA1(Entity.Password);
            int change = await Adapter.Save(Entity); 
            if (change > 0)
            {
                DialogResult = DialogResult.OK;
            }
            btnSave.MarkFree(image, color);
            InvalidateForm();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Message.Question("Are you sure you want to delete this operator?") == DialogResult.No)
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

        private void CustomerEditView_Load(object sender, EventArgs e)
        {

        }

        private void RadioUser_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void RadioUser_Click(object sender, EventArgs e)
        {
            radioAdmin.Checked = false;
            Entity.Role = Role.StandardUser;
            radioAdmin.Checked = true;
        }

        private void RadioAdmin_Click(object sender, EventArgs e)
        {
            radioAdmin.Checked = true;
            Entity.Role = Role.Administrator;
            radioUser.Checked = false;
        }
    }
}
