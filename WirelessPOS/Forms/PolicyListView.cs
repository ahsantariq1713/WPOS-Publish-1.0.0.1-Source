using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WirelessPOS.Properties;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class PolicyListView : Form
    {

        private readonly Form owner;
        private WaitWin wait;

        public Adapter Adapter { get; }
        public IEnumerable<Policy> Entities { get;private set; }
        public PolicyListView(Adapter adapter, Form owner = null)
        {

            Adapter = adapter;
            this.owner = owner;

            InitializeComponent();
            InvalidateForm();
            InitializeForm();
        }

        public void InvalidateForm()
        {

        }

        private async void InitializeForm()
        {
            wait = new WaitWin("Loading View");
            wait.Show(this);
            await LoadEntites();
            LoadComponents(Entities);
            var policyTypes = await Adapter.Retrive<PolicyType>(withRelatedData: true);
            InitializeDdlStatus(policyTypes);
            Display();
        }

        private void InitializeDdlStatus(IEnumerable<PolicyType> statuses)
        {
            ddlPolicyType.Items.Add("All");
            statuses?.ToList().ForEach(x =>
            {

                ddlPolicyType.Items.Add(x.Name);

            });
            ddlPolicyType.SelectedItem = "All";
        }

        private void Display()
        {
            wait.Close();
            if (owner == null) return;
            this.MdiParent = owner;
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        private async Task LoadEntites()
        {
            Entities = await Adapter.Retrive<Policy>(withRelatedData: true);
            foreach (var entity in Entities)
            {
                await Adapter.LoadRelatedData(entity);
            }
        }

        public void LoadComponents(IEnumerable<Policy> entities)
        {

            grid.DataSource = typeof(IEnumerable<Policy>);
            grid.DataSource = entities.ToList() as IEnumerable<Policy>;

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.Visible = false;
            }


            var c0 = grid.Columns[nameof(Policy.Id)];
            c0.Visible = true;
            c0.DisplayIndex = 0;
            c0.FillWeight = 50;

            var c1 = grid.Columns[nameof(Policy.Type)];
            c1.Visible = true;
            c1.DisplayIndex = 1;
            c1.FillWeight = 100;

            var c2 = grid.Columns[nameof(Policy.Statement)];
            c2.Visible = true;
            c2.DisplayIndex = 2;
            c2.FillWeight = 1000;
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LblTitle_Click(object sender, EventArgs e)
        {

        }

        private async void BtnEditRow_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Index != -1)
            {
                var entityId = int.TryParse(grid.SelectedRows[0].Cells["Id"].Value.ToString(), out int id) ? id : 0;
                if (btnEdit.IsBusy()) return;
                btnEdit.MarkBusy(out Image image, out Color color);
                await Adapter.Resolve<PolicyEditView, int, Form>(entityId, this);

                btnEdit.MarkFree(image, color);
            }

        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 1 && grid.SelectedRows[0].Index != -1)
            {
                btnEdit.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
            }

            if (grid.SelectedRows.Count>0 && grid.SelectedRows[0].Index != -1)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private async void Button6_Click(object sender, EventArgs e)
        {
            if (btnRefresh.IsBusy()) return;
            btnRefresh.MarkBusy(out Image image, out Color color);

          Entities = (await Adapter.Retrive<Policy>(withRelatedData:true,activeOnly: !chkdeleted.Checked))?.ToList()
                .FindAll(x =>
                {
                    if (panelDates.Enabled == true)
                    {
                        return x.CreatedAt >= fromDate.Value && x.CreatedAt <= toDate.Value;
                    }
                    else
                    {
                       return true;
                    }
                });

            LoadComponents(Entities);
            btnRefresh.MarkFree(image, color);

        }

        private async void Button5_Click(object sender, EventArgs e)
        {
            if (btnAdd.IsBusy()) return;
            btnAdd.MarkBusy(out Image image, out Color color);
            await Adapter.Resolve<PolicyEditView, int, Form>(0, this);

            btnAdd.MarkFree( image,  color);
        }

       
        private async void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Index != -1)
            {
                if (Message.Question("Are you sure you want to delete " + grid.SelectedRows.Count +" records?") == DialogResult.No)
                {
                    return;
                }
                var customers = grid.DataSource as List<Policy>;
                var deleteable = new List<Policy>();
                var changes = 0;
                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    var eid =
                    int.TryParse(row.Cells["Id"].Value.ToString(), out int id) ? id : 0;
                    var customer = customers?.Find(x => x.Id == eid);
                    if (customer != null)
                    {
                       changes+= await Adapter.Remove(customer);
                    }
                }
                if (changes>0)
                {
                    await LoadEntites();
                    LoadComponents(Entities);
                }
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "Disable Date Filter")
            {
                button1.Text = "Enable Date Filter";
                button1.Image = Resources.icons8_toggle_off_17px;
                panelDates.Enabled = false;

            }
            else if (button1.Text == "Enable Date Filter")
            {
                button1.Text = "Disable Date Filter";
                button1.Image = Resources.icons8_toggle_on_17px;
                panelDates.Enabled = true;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private async void DdlPolicyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var entities =
               (await Adapter.Retrive<Policy>(activeOnly: !chkdeleted.Checked))?.ToList()
               .FindAll(x =>
               {
                   var search = (ddlPolicyType.SelectedItem?.ToString()??"")
                   =="All"?true:(XString.Equal(x.PolicyType.Name, ddlPolicyType.SelectedItem.ToString() ?? ""));
                   if (panelDates.Enabled == true)
                   {
                       return search && x.CreatedAt >= fromDate.Value && x.CreatedAt <= toDate.Value;
                   }
                   else
                   {
                       return search;
                   }
               });

            LoadComponents(entities);
        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////
    }
}
