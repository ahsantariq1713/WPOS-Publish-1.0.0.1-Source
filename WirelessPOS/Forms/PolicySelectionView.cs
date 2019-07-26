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
    public partial class PolicySelectionView : Form
    {

        private readonly Form owner;
        private WaitWin wait;
        public Adapter Adapter { get; }

        public List<Policy> SelectedPolicies { get; private set; } = new List<Policy>();

        public PolicySelectionView(Adapter adapter, Form owner = null)
        {
            Adapter = adapter;
            this.owner = owner;

            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            wait = new WaitWin("Loading View");
            wait.Show(this);
            LoadComponents();
           
        }

        private async void LoadComponents()
        {
            
            var policies = (await Adapter.Retrive<Policy>(withRelatedData:true))?.ToList();
            BindEntities(policies);

            var policyTypes = (await Adapter.Retrive<PolicyType>())?.ToList();
            BindPolicyType(policyTypes);

            Display();

        }

        public void BindEntities(IEnumerable<Policy> policies)
        {
            policyBindingSource.Clear();
            policies?.ToList().ForEach(x =>
            {
                policyBindingSource.Add(x);
            });
        }
        private void BindPolicyType(IEnumerable<PolicyType> policyTypes)
        {
            policyTypeBindingSource.Clear();
            policyTypes?.ToList().ForEach(x =>
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems == null) return;
            foreach (Policy policy in listBox1.SelectedItems)
            {
                SelectedPolicies.Add(policy);
            }
            DialogResult = DialogResult.OK;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            var view = await Adapter.Resolve<PolicyEditView, int, Form>(0, null);
            view?.ShowDialog(this);
            LoadComponents();
        }

        private async void DdlPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var policies = (await Adapter.Retrive<Policy>(withRelatedData: true))?.ToList()
                .FindAll(x=>x.PolicyType.Name == ddlPolicy.Text);
            BindEntities(policies);
        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////
    }
}
