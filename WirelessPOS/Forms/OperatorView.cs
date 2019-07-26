using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WirelessPOS.Properties;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class OperatorView : Form
    {
      
        public void RefreshBalanceSheet()
        {
            grid.Rows.Clear();
            if (operatorBindingSource.Count > 0)
            {
                int sr = 1;
                var op = (operatorBindingSource[0] as Operator);
                if (op == null) return;
                op.LastShift?.CurrentTransactions?.ForEach(x =>
                {

                    int.TryParse(x.TradeId[5].ToString(), out int code);
                    grid.Rows.Add(sr++, TradeCode.GetType(code)?.Name.ToLabel(), x.TradeId, x.Amount, x.TransactionType.ToString());
                });
                lblOpening.Text = string.Format("{0:C2}", op.LastShift?.OpeningBalance);
                lblCashin.Text = string.Format("{0:C2}", op.LastShift?.CashIn);
                lblCashout.Text = string.Format("{0:C2}", op.LastShift?.CashOut);
                lblClosing.Text = string.Format("{0:C2}", op.LastShift?.ClosingBalance);
            }
        }

        public async void RefreshNotificationCenter()
        {
            if (operatorBindingSource.Count > 0)
            {
                var repairs = (await Adapter.Retrive<Repair>(withRelatedData:true))?.ToList().FindAll(x => x.Status == "Pending");

                if (repairs!=null && repairs.Count>0)
                {
                    btnPendingRepairs.Enabled = true;
                    btnPendingRepairs.Text = repairs.Count + " Pending Repair";
                }
                else
                {
                    btnPendingRepairs.Enabled = false;
                    btnPendingRepairs.Text = 0 + " Pending Repair";
                }

                var layaways = (await Adapter.Retrive<Layaway>())?.ToList().FindAll(x => x.DaysLeft == 0 && x.Status == "Pending");

                if (layaways != null && layaways.Count>0)
                {
                    btnExpiredLayaways.Enabled = true;
                    btnExpiredLayaways.Text = layaways.Count + " Expired Layaways";
                }
                else
                {
                    btnExpiredLayaways.Enabled = false;
                    btnExpiredLayaways.Text = 0 + " Expired Layaways";
                }

                var payments = (await Adapter.Retrive<Payment>(withRelatedData: true))?.ToList().FindAll(x => x.Status == "Pending");

                if (payments != null && payments.Count > 0)
                {
                    btnPendingPayments.Enabled = true;
                    btnPendingPayments.Text = payments.Count + " Pending Payments";
                }
                else
                {
                    btnPendingPayments.Enabled = false;
                    btnPendingPayments.Text = 0 + " Pending Payments";
                }
            }
        }




        private int currentTradeId;
        private int currentTradeCode;
        private readonly IEnumerable<DGColumn> columns = new List<DGColumn> {
             new DGColumn("Id",0,50),
                    new DGColumn("Name",1,150),
                    new DGColumn("Phone",2,100),
                    new DGColumn("Email",3,100),
                    new DGColumn("Address",4,250)
        };

        private readonly Form owner;

        public Adapter Adapter { get; }
        public IEnumerable<Customer> Entities { get; private set; }
        public OperatorView(Adapter adapter, Form owner = null)
        {

            Adapter = adapter;
            this.owner = owner;

            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {

            LoadEntites();
            Display();
        }

        private void Display()
        {
            if (owner == null) return;
            this.MdiParent = owner;
            this.Show();
            this.WindowState = FormWindowState.Maximized;
          
        }

        private void LoadEntites()
        {
            var op = Auth.GetOperator();
            operatorBindingSource.Clear();
            operatorBindingSource.Add(op);
            RefreshBalanceSheet();
            RefreshNotificationCenter();
        }

        private void LblTitle_Click(object sender, EventArgs e)
        {

        }

        private void TxtItemSearch_Enter(object sender, EventArgs e)
        {

            txtTradeSearch.SelectAll();

        }

        private void TxtItemSearch_Leave(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (Auth.IsLoggedIn()) Auth.Logout();
        }

        private async void btnFindTrade_Click(object sender, EventArgs e)
        {
            if (btnFindTrade.IsBusy()) return;
         
            var text = txtTradeSearch.Text;
            if (text.Replace("-", "").Length != 11)
            {
                Message.Warning("Trade ID must contains 11 digits");
                return;
            }

            var parts = text.Split('-');
            if (parts.Length != 3)
            {
                Message.Warning("Trade ID is invalid");
                return;
            }

            var s = parts[1];
            var code = int.Parse(s[s.Length - 1].ToString());
            var search = text.Split('-');
            var id = int.Parse(search[2].ToString());

            iTransactionableBindingSource.Clear();
            currentTradeCode = 0;
            btnFindTrade.MarkBusy(out Image image, out Color color);
            if (code == 1)
            {
                var entity = await Adapter.Retrive<Purchase>(id);
                if (entity!=null)
                {
                    await EntityLoader.LoadComponents(entity, Adapter);

                    iTransactionableBindingSource.Clear();
                    iTransactionableBindingSource.Add(entity);
                }
            }
            else if (code == 2)
            {
                var entity = await Adapter.Retrive<Sale>(id);
                if (entity != null)
                {
                    await  EntityLoader.LoadComponents(entity, Adapter);
                    iTransactionableBindingSource.Clear();
                    iTransactionableBindingSource.Add(entity);
                }

            }
            else if (code == 3)
            {
                var entity = await Adapter.Retrive<Repair>(id);
                if (entity != null)
                {
                    await EntityLoader.LoadComponents(entity, Adapter);
                    iTransactionableBindingSource.Clear();
                    iTransactionableBindingSource.Add(entity);
                }
            }
            else if (code == 4)
            {
                var entity = await Adapter.Retrive<Layaway>(id);
                if (entity != null)
                {
                    await EntityLoader.LoadComponents(entity, Adapter);
                    iTransactionableBindingSource.Clear();
                    iTransactionableBindingSource.Add(entity);
                }
            }
            else if (code == 5)
            {
                var entity = await Adapter.Retrive<Payment>(id);
                if (entity != null)
                {
                    await EntityLoader.LoadComponents(entity, Adapter);
                    iTransactionableBindingSource.Clear();
                    iTransactionableBindingSource.Add(entity);
                }
            }
            else if (code == 6)
            {
                var entity = await Adapter.Retrive<CallingCard>(id);
                if (entity != null)
                {
                    await EntityLoader.LoadComponents(entity, Adapter);
                    iTransactionableBindingSource.Clear();
                    iTransactionableBindingSource.Add(entity);
                }
            }
            else if (code == 7)
            {
                var entity = await Adapter.Retrive<NewActivation>(id);
                if (entity != null)
                {
                    await EntityLoader.LoadComponents(entity, Adapter);
                    iTransactionableBindingSource.Clear();
                    iTransactionableBindingSource.Add(entity);
                }
            }
            else if (code == 8)
            {
                var entity = await Adapter.Retrive<Unlock>(id);
                if (entity != null)
                {
                    await EntityLoader.LoadComponents(entity, Adapter);
                    iTransactionableBindingSource.Clear();
                    iTransactionableBindingSource.Add(entity);
                }
            }
            else if (code == 9)
            {
                var entity = await Adapter.Retrive<Portin>(id);
                if (entity != null)
                {
                    await EntityLoader.LoadComponents(entity, Adapter);
                    iTransactionableBindingSource.Clear();
                    iTransactionableBindingSource.Add(entity);
                }
            }

            btnFindTrade.MarkFree(image, color);

            if (iTransactionableBindingSource.Count > 0)
            {
                currentTradeId = id;
                currentTradeCode = code;
            }
        }

        private void OperatorView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Auth.IsLoggedIn())
            {
                e.Cancel = true;
                return;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            iTransactionableBindingSource.Clear();
            txtTradeSearch.Clear();
            txtTradeSearch.Focus();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (currentTradeCode!=0)
            {
                await ViewDetails(currentTradeCode, currentTradeId);
            }
            
        }

        private async Task ViewDetails(int code, int id)
        {
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
                else if (code == 7)
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
        }

        private async void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 5)
            {
                var v = grid.Rows[e.RowIndex].Cells[2].Value.ToString().Substring(5);
                var codeChr = v[0];
                int.TryParse(codeChr.ToString(), out int code);
                var idStr = v.Substring(1);
                int.TryParse(idStr, out int id);

               await ViewDetails(code, id);
            }
        }

        private void OperatorView_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState!= FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void TxtTradeSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindTrade.PerformClick();
            }
        }

        private void Label24_Click(object sender, EventArgs e)
        {
            
        }

        private async void Button15_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<StockView, Form>(Master.Instance);
        }

        private async void Button16_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<TradeListView, Form>(Master.Instance);
        }

        private async void Button17_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<CustomerListView, Form>(Master.Instance);
        }

        private void OperatorView_Load(object sender, EventArgs e)
        {
            
        }

        private async void BtnPendingRepairs_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<TradeListView, string, Form>("Repair", Master.Instance);
        }

        private async void BtnExpiredLayaways_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<TradeListView,string,Form>("Layaway", Master.Instance);
        }

        private void OperatorView_Shown(object sender, EventArgs e)
        {
           
        }

        private async void Button6_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<SaleEditView, int, Form>(0, Master.Instance);
        }

        private async void Button7_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<RepairEditView, int, Form>(0, Master.Instance);
        }

        private async void Button8_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PortinEditView, int, Form>(0, Master.Instance);
        }

        private async void Button9_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PaymentEditView, int, Form>(0, Master.Instance);
        }

        private async void Button10_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<LayawayEditView, int, Form>(0, Master.Instance);
        }

        private async void Button11_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<UnlockEditView, int, Form>(0, Master.Instance);
        }

        private async void Button14_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PurchaseEditView, int, Form>(0, Master.Instance);
        }

        private async void Button13_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<NewActivationEditView, int, Form>(0, Master.Instance);
        }

        private async void Button12_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<CallingCardEditView, int, Form>(0, Master.Instance);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
        }

        private async void BtnPendingPayments_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<TradeListView, string, Form>("Payments", Master.Instance);
        }
    }
}
