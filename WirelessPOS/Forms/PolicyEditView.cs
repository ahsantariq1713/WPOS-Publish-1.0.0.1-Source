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
    public partial class PolicyEditView : Form
    {

        private List<PolicyType> types;

        private readonly Form owner;
        private WaitWin wait;
        public Policy Entity { get; private set; }
        public Adapter Adapter { get; }


        public PolicyEditView(Adapter adapter, int id, Form owner = null)
        {
            Adapter = adapter;
            this.owner = owner;

            InitializeComponent();
            InitializeForm(id);
        }

        private void InitializeForm(int id)
        {
            wait = new WaitWin("Loading View");
            wait.Show(this);
            LoadComponents(id);
           
        }

        private async void LoadComponents(int id)
        {
            if (id == 0) Entity = new Policy();
            else
            {
                Entity  = await Adapter.Retrive<Policy>(id);
                if (Entity == null)
                {
                    wait.Close();
                    Message.Stop("No poiicy found to show.");
                    this.Dispose();
                    return;
                }
                await Adapter.LoadRelatedData(Entity);
            }

            BindEntity();

            types = (await Adapter.Retrive<PolicyType>())?.ToList();
            BindPolicyType();


            InvalidateForm();
            Display();

        }

        public void BindEntity()
        {
            policyBindingSource.Clear();
            policyBindingSource.Add(Entity);
        }
        private void BindPolicyType()
        {
            policyTypeBindingSource.Clear();
            types?.ToList().ForEach(x =>
            {
                policyTypeBindingSource.Add(x);
            });
        }




        private void Display()
        {
            wait.Close();
            if (this.owner == null) return;
            this.ShowDialog(owner);
        }

        public void InvalidateForm()
        {
            if (Entity.IsNew)
            {
                lblTitle.Text = "          New Policy";
                btnDelete.Enabled = false;
            }
            else
            {
                lblTitle.Text = "          Edit Policy";
                btnDelete.Enabled = true;
            }
        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.IsBusy()) return;
            ValidateChildren();
            btnSave.MarkBusy(out Image image, out Color color);
            var changes = await Adapter.Save(Entity);
            if (changes>0)
            {
                DialogResult = DialogResult.OK;
            }
            btnSave.MarkFree(image, color);
            InvalidateForm();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Message.Question("Are you sure you want to delete this item?") == DialogResult.No)
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

        private void DdlPolicyType_TextChanged(object sender, EventArgs e)
        {
            var text = ddlPolicyList.Text;
            if (text.IsNull())
            {
                btnAddPolicyType.Enabled = false;
                return;
            }
            var found = types?.Find(x => XString.Equal(x.Name, text));
            if (found != null) btnAddPolicyType.Enabled = false;
            else btnAddPolicyType.Enabled = true;
        }

        private async void BtnAddPolicyType_Click(object sender, EventArgs e)
        {
            if (btnAddPolicyType.IsBusy()) return;
            btnAddPolicyType.MarkBusy(out Image image, out Color color);
            var policyType = new PolicyType { Name = ddlPolicyList.Text };
            int changes = await Adapter.Save(policyType);
            btnAddPolicyType.MarkFree(image, color);
            if (changes <= 0) return;
            types.Add(policyType);
            policyTypeBindingSource.Add(policyType);
            ddlPolicyList.SelectedItem = policyType;
            btnAddPolicyType.Enabled = false;
        }


       
    }
}
