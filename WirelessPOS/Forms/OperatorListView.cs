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
    public partial class OperatorListView : Form
    {

        private readonly Form owner;
        private WaitWin wait;

        public Adapter Adapter { get; }
        public IEnumerable<Operator> Entities { get; private set; }
        public OperatorListView(Adapter adapter, Form owner = null)
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
            Display();
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
            Entities = await Adapter.Retrive<Operator>(withRelatedData: true);
            foreach (var entity in Entities)
            {
                await Adapter.LoadRelatedData(entity);
                foreach (var shift in entity.Shifts)
                {
                    await Adapter.LoadRelatedData(shift);
                }
            }
        }
 


        public void LoadComponents(IEnumerable<Operator> entities)
        {

            grid.DataSource = typeof(IEnumerable<Operator>);
            grid.DataSource = entities.ToList() as IEnumerable<Operator>;

            InvalidateGrid();
        }

        private void InvalidateGrid()
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.Visible = false;
            }

            var c0 = grid.Columns[nameof(Operator.Id)];
            c0.Visible = true;
            c0.DisplayIndex = 0;
            c0.FillWeight = 50;

            var c1 = grid.Columns[nameof(Operator.User)];
            c1.Visible = true;
            c1.DisplayIndex = 1;
            c1.FillWeight = 200;

            var c2 = grid.Columns[nameof(Operator.Phone)];
            c2.Visible = true;
            c2.DisplayIndex = 2;
            c2.FillWeight = 150;

            var c3 = grid.Columns[nameof(Operator.Email)];
            c3.Visible = true;
            c3.DisplayIndex = 3;
            c3.FillWeight = 150;

            var c4 = grid.Columns[nameof(Operator.Role)];
            c4.Visible = true;
            c4.DisplayIndex = 4;
            c4.FillWeight = 200;

            var c5 = grid.Columns[nameof(Operator.CNIC)];
            c5.Visible = true;
            c5.DisplayIndex = 5;
            c5.FillWeight = 200;

            var c7 = grid.Columns[nameof(Operator.NetOpeining)];
            c7.HeaderText = nameof(Operator.NetOpeining).ToLabel();
            c7.DefaultCellStyle.Format = "$0,0.00";
            c7.Visible = true;
            c7.DisplayIndex = 7;
            c7.FillWeight = 100;

            var c8 = grid.Columns[nameof(Operator.CashReceived)];
            c8.HeaderText = nameof(Operator.CashReceived).ToLabel();
            c8.DefaultCellStyle.Format = "$0,0.00";
            c8.Visible = true;
            c8.DisplayIndex = 8;
            c8.FillWeight = 100;

            var c9 = grid.Columns[nameof(Operator.Cashout)];
            c9.HeaderText = nameof(Operator.Cashout).ToLabel();
            c9.DefaultCellStyle.Format = "$0,0.00";
            c9.Visible = true;
            c9.DisplayIndex = 9;
            c9.FillWeight = 100;

            var c10 = grid.Columns[nameof(Operator.NetClosing)];
            c10.HeaderText = nameof(Operator.NetClosing).ToLabel();
            c10.DefaultCellStyle.Format = "$0,0.00";
            c10.Visible = true;
            c10.DisplayIndex = 10;
            c10.FillWeight = 100;
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
                await Adapter.Resolve<OperatorEditView, int, Form>(entityId, this);

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

        }

        private async void Button6_Click(object sender, EventArgs e)
        {
            if (btnRefresh.IsBusy()) return;
            btnRefresh.MarkBusy(out Image image, out Color color);
           
            Entities =
                (await Adapter.Retrive<Operator>(activeOnly: !chkdeleted.Checked))?.ToList()
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

            foreach (var entity in Entities)
            {
                await Adapter.LoadRelatedData(entity);
                foreach (var shift in entity.Shifts)
                {
                    await Adapter.LoadRelatedData(shift);
                }
            }
            LoadComponents(Entities);
            btnRefresh.MarkFree(image, color);

        }

        private async void Button5_Click(object sender, EventArgs e)
        {
            if (btnAdd.IsBusy()) return;
            btnAdd.MarkBusy(out Image image, out Color color);
            await Adapter.Resolve<OperatorEditView, int, Form>(0, this);

            btnAdd.MarkFree( image,  color);
        }

        private void TxtItemSearch_Enter(object sender, EventArgs e)
        {
            if(txtSearch.ForeColor != Color.Black)
            {
                txtSearch.Clear();
                txtSearch.ForeColor = Color.Black;
            }
            
        }

        private void TxtItemSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length <= 0)
            {
                txtSearch.Text = "Search name, email or phone.";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private async void BtnFindItem_Click(object sender, EventArgs e)
        {

            if (btnFind.IsBusy()) return;
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) return;
            btnFind.MarkBusy(out Image image, out Color color);

            var entities =
                Entities?.ToList()
                .FindAll(x =>
                {
                    var search =
                    XString.Contains(x.Phone.RemovePhoneFormat(), txtSearch.Text) || 
                    XString.Contains(x.Email, txtSearch.Text) ||
                    XString.Contains(x.CNIC, txtSearch.Text)||
                    XString.Contains(x.User, txtSearch.Text);
                    if (panelDates.Enabled == true)
                    {
                        return search && x.CreatedAt >= fromDate.Value && x.CreatedAt <= toDate.Value;
                    }else
                    {
                        return search;
                    }
                });

           LoadComponents(entities);

            btnFind.MarkFree(image, color);
        }

        private async void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Index != -1)
            {
                if (Message.Question("Are you sure you want to delete " + grid.SelectedRows.Count +" records?") == DialogResult.No)
                {
                    return;
                }
                var customers = grid.DataSource as List<Operator>;
                var deleteable = new List<Operator>();
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

        private void OperatorListView_Load(object sender, EventArgs e)
        {

        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////
    }
}
