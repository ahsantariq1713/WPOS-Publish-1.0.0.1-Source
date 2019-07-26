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
    public partial class TradeListView : Form
    {

        private readonly Form owner;
        private WaitWin wait;

        public Adapter Adapter { get; }
        public List<ITransactionable> Entities { get; private set; } = new List<ITransactionable>();
        public TradeListView(Adapter adapter, Form owner = null)
        {
            Adapter = adapter;
            this.owner = owner;

            InitializeComponent();
            InvalidateForm();
            InitializeForm();
        }

        public TradeListView(Adapter adapter, string arg,  Form owner = null)
        {
            Adapter = adapter;
            this.owner = owner;

            InitializeComponent();
            InvalidateForm();

            
            InitializeForm(arg == "Repair" ? true : false, arg == "Layaway" ? true : false);
            
        }


        public void InvalidateForm()
        {
        }

        private async void InitializeForm(bool loadPendingRepairs = false, bool loadExpiredLayaways = false)
        {
            wait = new WaitWin("Loading View");
            wait.Show(this);
            if (loadPendingRepairs)
            {
                Entities.Clear();
                var Repairs = await Adapter.Retrive<Repair>();
                foreach (var Repair in Repairs) await EntityLoader.LoadComponents(Repair, Adapter);
                var found = Repairs?.ToList().FindAll(x => x.Status == "Pending");
                if (found!=null && found.Count>0)
                {
                    Entities.AddRange(Repairs);
                    LoadComponents(Entities);
                }

                ddlTrade.SelectedItem = "Repair";
                ddlStatus.SelectedItem = "Pending";
              
            }
            else if (loadExpiredLayaways)
            {
                Entities.Clear();
                var Layways = await Adapter.Retrive<Layaway>();
                foreach (var Repair in Layways) await EntityLoader.LoadComponents(Repair, Adapter);
                var found = Layways?.ToList().FindAll(x => x.DaysLeft <= 0 && x.Status == "Pending");
                if (found != null && found.Count > 0)
                {
                    Entities.AddRange(Layways);
                    LoadComponents(Entities);
                }

                ddlTrade.SelectedItem = "Layaway";
                ddlStatus.SelectedItem = "Pending";
            }
            else
            {
                await LoadEntites();
            }

            var statuses = await Adapter.Retrive<RepairStatus>(withRelatedData: true);
            InitializeDdlStatus(statuses);
            InitializeDdlTrade();
            Display();
        }

        private void InitializeDdlTrade()
        {
            ddlTrade.Items.Add("All");
            ddlTrade.Items.Add(nameof(Sale).ToLabel());
            ddlTrade.Items.Add(nameof(Purchase).ToLabel());
            ddlTrade.Items.Add(nameof(Repair).ToLabel());
            ddlTrade.Items.Add(nameof(NewActivation).ToLabel());
            ddlTrade.Items.Add(nameof(Payment).ToLabel());
            ddlTrade.Items.Add(nameof(Layaway).ToLabel());
            ddlTrade.Items.Add(nameof(CallingCard).ToLabel());
            ddlTrade.Items.Add(nameof(Portin).ToLabel());
            ddlTrade.Items.Add(nameof(Unlock).ToLabel());
            ddlTrade.SelectedItem = "All";
        }

        private void InitializeDdlStatus(IEnumerable<RepairStatus> statuses)
        {
            ddlStatus.Items.Add("All");
            statuses?.ToList().ForEach(x =>
            {

                ddlStatus.Items.Add(x.Status);

            });
            ddlStatus.SelectedItem = "All";
        }
            private void Display()
        {
            wait.Show();
            if (owner == null) return;
            this.MdiParent = owner;
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        private async Task LoadEntites()
        {
            Entities.Clear();

            var Sales = await Adapter.Retrive<Sale>();
            foreach (var Sale in Sales) await EntityLoader.LoadComponents(Sale, Adapter);
            Entities.AddRange(Sales);

            var Purchases = await Adapter.Retrive<Purchase>();
            foreach (var Purchase in Purchases) await EntityLoader.LoadComponents(Purchase, Adapter);
            Entities.AddRange(Purchases);


            var Repairs = await Adapter.Retrive<Repair>();
            foreach (var Repair in Repairs) await EntityLoader.LoadComponents(Repair, Adapter);
            Entities.AddRange(Repairs);

            var Layaways = await Adapter.Retrive<Layaway>();
            foreach (var Layaway in Layaways) await EntityLoader.LoadComponents(Layaway, Adapter);
            Entities.AddRange(Layaways);

            var NewActivations = await Adapter.Retrive<NewActivation>();
            foreach (var NewActivation in NewActivations) await EntityLoader.LoadComponents(NewActivation, Adapter);
            Entities.AddRange(NewActivations);

            var Portins = await Adapter.Retrive<Portin>();
            foreach (var Portin in Portins) await EntityLoader.LoadComponents(Portin, Adapter);
            Entities.AddRange(Portins);

            var CallingCards = await Adapter.Retrive<CallingCard>();
            foreach (var CallingCard in CallingCards) await EntityLoader.LoadComponents(CallingCard, Adapter);
            Entities.AddRange(CallingCards);

            var Payments = await Adapter.Retrive<Payment>();
            foreach (var Payment in Payments) await EntityLoader.LoadComponents(Payment, Adapter);
            Entities.AddRange(Payments);

            var Unlocks = await Adapter.Retrive<Unlock>();
            foreach (var Unlock in Unlocks) await EntityLoader.LoadComponents(Unlock, Adapter);
            Entities.AddRange(Unlocks);

            LoadComponents(Entities);
        }

        public void LoadComponents(IEnumerable<ITransactionable> entities)
        {

            grid.DataSource = typeof(IEnumerable<ITransactionable>);
            grid.DataSource = entities.ToList() as IEnumerable<ITransactionable>;

            InvalidateGrid();

            gridTotals.Rows.Clear();
            gridTotals.Rows.Add(
                "", "", "", "",
                string.Format("{0:$0,0.00}", entities?.Sum(x => x.Total) ?? 0),
                 string.Format("{0:$0,0.00}", entities?.Sum(x => x.Paid) ?? 0),
                  string.Format("{0:$0,0.00}", entities?.Sum(x => x.Due) ?? 0),
                  "");

            gridTotals.Columns[0].Width = grid.Columns["TradeId"].Width;
            gridTotals.Columns[1].Width = grid.Columns["TradeName"].Width;
            gridTotals.Columns[2].Width = grid.Columns["ClientName"].Width;
            gridTotals.Columns[3].Width = grid.Columns["ClientPhone"].Width;
            gridTotals.Columns[4].Width = grid.Columns["Total"].Width;
            gridTotals.Columns[5].Width = grid.Columns["Paid"].Width;
            gridTotals.Columns[6].Width = grid.Columns["Due"].Width;
            gridTotals.Columns[6].Width = grid.Columns["Status"].Width;

        }


        private void InvalidateGrid()
        {

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.Visible = false;
            }


            var c0 = grid.Columns[nameof(ITransactionable.TradeId)];
            c0.HeaderText = nameof(ITransactionable.TradeId).ToLabel();
            c0.Visible = true;
            c0.DisplayIndex = 0;
            c0.FillWeight = 100;

            var c1 = grid.Columns[nameof(ITransactionable.TradeName)];
            c1.HeaderText = nameof(ITransactionable.TradeName).ToLabel();
            c1.Visible = true;
            c1.DisplayIndex = 1;
            c1.FillWeight = 200;

            var c2 = grid.Columns[nameof(ITransactionable.ClientName)];
            c2.HeaderText = nameof(ITransactionable.ClientName).ToLabel();
            c2.Visible = true;
            c2.DisplayIndex = 2;
            c2.FillWeight = 150;

            var c3 = grid.Columns[nameof(ITransactionable.ClientPhone)];
            c3.HeaderText = nameof(ITransactionable.ClientPhone).ToLabel();
            c3.Visible = true;
            c3.DisplayIndex = 3;
            c3.FillWeight = 150;

            var c4 = grid.Columns[nameof(ITransactionable.Date)];
            c4.Visible = true;
            c4.DisplayIndex = 4;
            c4.FillWeight = 200;

            var c5 = grid.Columns[nameof(ITransactionable.Total)];
            c5.DefaultCellStyle.Format = "$0,0.00";
            c5.Visible = true;
            c5.DisplayIndex = 5;
            c5.FillWeight = 100;


            var c6 = grid.Columns[nameof(ITransactionable.Paid)];
            c6.DefaultCellStyle.Format = "$0,0.00";
            c6.Visible = true;
            c6.DisplayIndex = 6;
            c6.FillWeight = 100;

            var c8 = grid.Columns[nameof(ITransactionable.Due)];
            c8.DefaultCellStyle.Format = "$0,0.00";
            c8.Visible = true;
            c8.DisplayIndex = 8;
            c8.FillWeight = 100;

            var c9 = grid.Columns[nameof(ITransactionable.Status)];
            c9.Visible = true;
            c9.DisplayIndex = 9;
            c9.FillWeight = 100;


            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[nameof(ITransactionable.Status)].Value.ToString() == "Pending")
                {
                    grid.Rows[row.Index].DefaultCellStyle.BackColor = Color.SeaShell;
                    grid.Rows[row.Index].DefaultCellStyle.SelectionBackColor = Color.SeaShell;
                }
                else if (row.Cells[nameof(ITransactionable.Status)].Value.ToString() == "Closed")
                {
                    grid.Rows[row.Index].Cells[nameof(ITransactionable.Status)].Style.BackColor = Color.Honeydew;
                    grid.Rows[row.Index].Cells[nameof(ITransactionable.Status)].Style.SelectionBackColor = Color.Honeydew;
                }
            }
        }
        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LblTitle_Click(object sender, EventArgs e)
        {

        }



        private void Grid_SelectionChanged(object sender, EventArgs e)
        {

        }

        private async void Button6_Click(object sender, EventArgs e)
        {
            if (btnRefresh.IsBusy()) return;
            btnRefresh.MarkBusy(out Image image, out Color color);
            await LoadEntites();
            btnRefresh.MarkFree(image, color);

        }

        private void TxtItemSearch_Enter(object sender, EventArgs e)
        {


        }

        private void TxtItemSearch_Leave(object sender, EventArgs e)
        {
        }

        private void BtnFindItem_Click(object sender, EventArgs e)
        {
            var entities = Entities.FindAll(x =>
            {
                var search = txtSearch.Text.Trim();
                return
                ((!string.IsNullOrEmpty(search)) ?
                XString.Contains(x.ClientName, search) ||
                XString.Contains(x.ClientPhone.RemovePhoneFormat(), search)
                : true) &&
                (panelDates.Enabled ? x.Date >= fromDate.Value && x.Date <= toDate.Value : true) &&
                (checkBox1.Checked == true ? x.Due > 0 : true) &&
                (ddlTrade.SelectedItem.ToString() != "All" ? XString.Equal(x.TradeName, ddlTrade.SelectedItem.ToString()) : true) &&
                 (ddlStatus.SelectedItem.ToString() != "All" ? XString.Equal(x.Status, ddlStatus.SelectedItem.ToString()) : true);
            });

            LoadComponents(entities);
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (btnShowDetails.IsBusy()) return;
            btnShowDetails.MarkBusy(out Image image, out Color color);
       
            if (grid.SelectedRows.Count == 1 && grid.SelectedRows[0].Index != -1)
            {
                var text = grid.SelectedRows[0].Cells[nameof(ITransactionable.TradeId)].Value.ToString();
                var code = int.Parse(text.Substring(5, 1).ToString());
                var id = int.Parse(text.Substring(6).ToString());
                if (id > 0)
                {
                    if (code == 1)
                    {
                        await Adapter.Resolve<PurchaseEditView, int, Form>(id, Master.Instance);
                    }
                    else if (code == 2)
                    {
                        await Adapter.Resolve<SaleEditView, int, Form>(id, Master.Instance);
                    }
                    else if (code == 3)
                    {
                        await Adapter.Resolve<RepairEditView, int, Form>(id, Master.Instance);
                    }
                    else if (code == 4)
                    {
                        await Adapter.Resolve<LayawayEditView, int, Form>(id, Master.Instance);
                    }
                    else if (code == 5)
                    {
                        await Adapter.Resolve<PaymentEditView, int, Form>(id, Master.Instance);
                    }
                    else if (code == 6)
                    {
                        await Adapter.Resolve<CallingCardEditView, int, Form>(id, Master.Instance);
                    }
                    else if (code == 6)
                    {
                        await Adapter.Resolve<NewActivationEditView, int, Form>(id, Master.Instance);
                    }
                    else if (code == 8)
                    {
                        await Adapter.Resolve<UnlockEditView, int, Form>(id, Master.Instance);
                    }
                    else if (code == 9)
                    {
                        await Adapter.Resolve<PortinEditView, int, Form>(id, Master.Instance);
                    }
                }

                btnShowDetails.MarkFree(image, color);
            }
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Entities = Entities.FindAll(x =>
            //{
            //    var searchByTrade = x.TradeName.Equals(comboBox1.SelectedText ?? "");
            //    var searchByDate = x.Date >= fromDate.Value && x.Date <= toDate.Value;

            //    if (panelDates.Enabled == true)
            //    {
            //        return searchByDate && searchByTrade;
            //    }
            //    else
            //    {
            //        return searchByTrade;
            //    }
            //});

            //LoadComponents(Entities);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //{

            //    Entities = Entities.FindAll(x =>
            //    {
            //        var searchByDue = x.Due > 0;
            //        var searchByDate = x.Date >= fromDate.Value && x.Date <= toDate.Value;

            //        if (panelDates.Enabled == true)
            //        {
            //            return searchByDate && searchByDue;
            //        }
            //        else
            //        {
            //            return searchByDue;
            //        }
            //    });

            //    LoadComponents(Entities);
            //}
        }

        private void TradeListView_Load(object sender, EventArgs e)
        {
            InvalidateGrid();
        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////
    }
}
