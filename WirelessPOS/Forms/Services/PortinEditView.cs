using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WirelessPOS.Properties;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class PortinEditView : Form
    {
        private readonly Form owner;
        private WaitWin wait;
        private List<Carrier> fromCarriers;
        private List<AirTimePlan> atPlans;
        private List<Carrier> toCarriers;

        public Portin Entity { get; private set; }
        public Adapter Adapter { get; }

        public PortinEditView(Adapter adapter, int id, Form owner = null)
        {
            Adapter = adapter;
            this.owner = owner;
            //Owner = owner;

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
            if (id == 0) Entity = new Portin() { Tax = Properties.Settings.Default.Tax };
            else
            {
                Entity = await Adapter.Retrive<Portin>(id);
                if (Entity == null)
                {
                    wait.Close();
                    Message.Stop("No Portin found to show.");
                    this.Dispose();
                    return;
                }
                await EntityLoader.LoadComponents(Entity, Adapter);
            }

            BindEntity();


            Entity.Transactions = Entity.Transactions ?? new List<Transaction>();
            Entity.Policies = Entity.Policies ?? new List<Policy>();

            BindPolicies();
            BindCustomer();

            fromCarriers = (await Adapter.Retrive<Carrier>())?.ToList();
            BindFromCarrier();

            toCarriers = (await Adapter.Retrive<Carrier>())?.ToList();
            BindToCarrier();

            atPlans = (await Adapter.Retrive<AirTimePlan>())?.ToList();
            BindATPlans();
            var polices =
                 (await Adapter.Retrive<Policy>(withRelatedData: true, activeOnly: true))?.ToList()
                 .FindAll(x =>
                 {
                     return XString.Equal(x.PolicyType.Name, "Portin");
                 });

            var sb = new StringBuilder();
            var i = 1;
            foreach (var policy in polices)
            {
                sb.AppendLine(i++ + ". " + policy.Statement);
            }
            richTextBox1.Text = sb.ToString();

            ddlATPlan.SelectedIndex = -1;
            ddlFromCarrier.SelectedIndex = -1;
            ddlToCarrier.SelectedIndex = -1;

            InvalidateForm();
            Display();

        }

        private void BindFromCarrier()
        {
            fromCarrierBindingSource.Clear();
            fromCarriers?.ToList().ForEach(x =>
            {
                fromCarrierBindingSource.Add(x);
            });
        }

        private void DdlFromCarrier_TextChanged(object sender, EventArgs e)
        {
            var text = ddlFromCarrier.Text;
            if (text.IsNull())
            {
                btnAddFromCarrier.Enabled = false;
                return;
            }
            var found = fromCarriers?.Find(x => XString.Equal(x.Name, text));
            if (found != null) btnAddFromCarrier.Enabled = false;
            else btnAddFromCarrier.Enabled = true;
        }

        private async void BtnAddFromCarrier_Click(object sender, EventArgs e)
        {
            if (btnAddFromCarrier.IsBusy()) return;
            btnAddFromCarrier.MarkBusy(out Image image, out Color color);
            var carrier = new Carrier { Name = ddlFromCarrier.Text };
            int changes = await Adapter.Save(carrier);
            btnAddFromCarrier.MarkFree(image, color);
            if (changes <= 0) return;
            fromCarriers.Add(carrier);
            fromCarrierBindingSource.Add(carrier);
            ddlFromCarrier.SelectedItem = carrier;
            btnAddFromCarrier.Enabled = false;
        }


        private void BindToCarrier()
        {
            toCarrierBindingSource.Clear();
            toCarriers?.ToList().ForEach(x =>
            {
                toCarrierBindingSource.Add(x);
            });
        }

        private void DdlToCarrier_TextChanged(object sender, EventArgs e)
        {
            var text = ddlToCarrier.Text;
            if (text.IsNull())
            {
                btnAddToCarrier.Enabled = false;
                return;
            }
            var found = toCarriers?.Find(x => XString.Equal(x.Name, text));
            if (found != null) btnAddToCarrier.Enabled = false;
            else btnAddToCarrier.Enabled = true;
        }

        private async void BtnAddToCarrier_Click(object sender, EventArgs e)
        {
            if (btnAddToCarrier.IsBusy()) return;
            btnAddToCarrier.MarkBusy(out Image image, out Color color);
            var carrier = new Carrier { Name = ddlToCarrier.Text };
            int changes = await Adapter.Save(carrier);
            btnAddToCarrier.MarkFree(image, color);
            if (changes <= 0) return;
            toCarriers.Add(carrier);
            toCarrierBindingSource.Add(carrier);
            ddlToCarrier.SelectedItem = carrier;
            btnAddToCarrier.Enabled = false;
        }


        private void BindATPlans()
        {
            airTimePlanBindingSource.Clear();
            atPlans?.ToList().ForEach(x =>
            {
                airTimePlanBindingSource.Add(x);
            });
        }

        private void DdlATPlan_TextChanged(object sender, EventArgs e)
        {
            var text = ddlATPlan.Text;
            if (text.IsNull())
            {
                btnAddATPlan.Enabled = false;
                return;
            }
            var found = atPlans?.Find(x => XString.Equal(x.Name, text));
            if (found != null) btnAddATPlan.Enabled = false;
            else btnAddATPlan.Enabled = true;
        }

        private async void BtnAddATPlan_Click(object sender, EventArgs e)
        {
            if (btnAddATPlan.IsBusy()) return;
            btnAddATPlan.MarkBusy(out Image image, out Color color);
            var atPlan = new AirTimePlan { Name = ddlATPlan.Text };
            int changes = await Adapter.Save(atPlan);
            btnAddATPlan.MarkFree(image, color);
            if (changes <= 0) return;
            atPlans.Add(atPlan);
            airTimePlanBindingSource.Add(atPlan);
            ddlATPlan.SelectedItem = atPlan;
            btnAddATPlan.Enabled = false;
        }

        public void BindEntity()
        {
           portinBindingSource.Clear();
           portinBindingSource.Add(Entity);
        }

        public void BindCustomer()
        {
            customerBindingSource.Clear();
            customerBindingSource.Add(Entity.Customer);

            //InvalidateFinishButton()
        }

        private void BindPolicies()
        {
            policyBindingSource.Clear();
            Entity.Policies?.ToList().ForEach(x =>
            {
                policyBindingSource.Add(x);
            });
        }





        private void Display()
        {
            wait.Close();
            if (owner == null) return;
            this.MdiParent = owner;
            this.Show();
            this.WindowState = FormWindowState.Maximized;

        }

        public void InvalidateForm()
        {

            if (Entity.IsNew)
            {
                lblTitle.Text = "          New Portin";
                billBtnPanel.Enabled = false;
                btnAddCustomer.Enabled = true;
                btnFindCustomer.Enabled = true;
            }
            else
            {
                lblTitle.Text = "          Edit Portin";
                billBtnPanel.Enabled = true;
                btnAddCustomer.Enabled = false;
                btnFindCustomer.Enabled = false;

            }

            if (Entity.Due <= 0)
            {
                btnTransactionInitiate.Enabled = false;
            }
            else
            {
                btnTransactionInitiate.Enabled = true;
            }

            //InvalidateFinishButton()
        }


        private void UpdateBill()
        {
            txtBillAmount.Text = string.Format("{0:0,0.00}", Entity.Amount);
            txtBillDiscountAmount.Text = string.Format("{0:0,0.00}", Entity.DiscountAmount);
            txtBillSubtotal.Text = string.Format("{0:0,0.00}", Entity.Subtotal);
            txtBillTaxAmount.Text = string.Format("{0:0,0.00}", Entity.TaxAmount);
            txtBillTotal.Text = string.Format("{0:0,0.00}", Entity.Total);
            txtBillDue.Text = string.Format("{0:0,0.00}", Entity.Due);

            //InvalidateFinishButton()
        }


        public void InvalidateFinishButton()
        {
            if (Entity.IsNew)
            {
                if (Entity.Total <= 0 || Entity.Customer == null)
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////
        //Events
        ///////////////////////////////////////////////////////////////////////////

        private async void BtnFindCustomer_Click(object sender, EventArgs e)
        {
            if (btnFindCustomer.IsBusy()) return;
            if (string.IsNullOrWhiteSpace(txtCustomerSearch.Text)) return;
            btnFindCustomer.MarkBusy(out Image image, out Color color);

            var customers =
                (await Adapter.Retrive<Customer>())?.ToList()
                .FindAll(x =>
                {
                    return
                    XString.Equal(x.Phone.RemovePhoneFormat(), txtCustomerSearch.Text) ||
                    XString.Contains(x.Name, txtCustomerSearch.Text);
                });

            btnFindCustomer.MarkFree(image, color);

            if (customers != null && customers.Count > 0)
            {
                var searchView = new SearchView<Customer>("Customers", customers, new List<DGColumn> {
                    new DGColumn("Id",0,50),
                    new DGColumn("Name",1,200),
                    new DGColumn("Phone",2,150),
                   new DGColumn("Email",3,150)

                });
                var result = searchView.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    Entity.Customer = customers.Find(x => x.Id == searchView.SelectedEntityId);
                    BindCustomer();
                    txtCustomerSearch.Clear();
                }
            }
            else
            {
                Message.Stop("No customer(s) found.");
                txtCustomerSearch.SelectAll();
                txtCustomerSearch.Focus();
            }

            //InvalidateFinishButton()
        }

        private async void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            if (btnAddCustomer.IsBusy()) return;
            btnAddCustomer.MarkBusy(out Image image, out Color color);
            var adapter = await Adapter.CreateInstance();
            btnAddCustomer.MarkFree(image, color);
            if (adapter == null) return;
            new CustomerEditView(adapter, 0, this);

        }

        private async void BtnFinish_Click(object sender, EventArgs e)
        {
            if (Entity.HasErrors(out string errors))
            {
                Message.Error("Please fix the following errors to continue:\n" + errors);
                return;
            }
            if (btnSave.IsBusy()) return;
            ValidateChildren();
            btnSave.MarkBusy(out Image image, out Color color);
            var changes = await Adapter.Save(Entity);
            if (changes > 0)
            {
                if (Entity.Transactions?.Count == 0) new TransactionView<Portin>(Adapter, Entity, TransactionType.Cashin, this);
            }
            btnSave.MarkFree(image, color);
            btnPrint.Focus();
            BindEntity();
            InvalidateForm();
        }

        private void BtnTransactionInitiate_Click(object sender, EventArgs e)
        {
            new TransactionView<Portin>(Adapter, Entity, TransactionType.Cashin, this);
            BindEntity();
            InvalidateForm();

        }

        private void BtnTransaction_Click(object sender, EventArgs e)
        {
            new TransactionsListView<Transaction>("New Activation Transactions", Resources.icons8_transaction_list_30px,
                Entity, Entity.Transactions, new List<DGColumn> {
                    new DGColumn("Date",0,100),
                    new DGColumn("TrxId",1,150),
                    new DGColumn("Amount",2,70),
                    new DGColumn("Cash",3,70),
                    new DGColumn("Return",4,70)
              }, this);
        }
        private async void PurchaseEditView_Load(object sender, EventArgs e)
        {
            chkTax.Checked = Properties.Settings.Default.IncludeTax;
            InvalidateTaxControls();
            await Task.Run(() => webBrowser1.Navigate(AdHandler.AdUrl));
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            XPrinter printer = new XPrinter(topMargin: 10, leftMargin: 10);
            PrintReceipt(printer);

            printer.Preview(this);
        }



        private void PrintReceipt(XPrinter printer)
        {
            int W(int percent)
            {
                int width = int.TryParse(Properties.Settings.Default.ReceiptWidth, out int r) ? r : 100;
                width -= 10;
                return (int)(width * percent / 100);
            }

            string UDotted()
            {
                int width = int.TryParse(Properties.Settings.Default.ReceiptWidth, out int r) ? r : 100;
                width -= 10;
                var sb = new StringBuilder();
                for (int i = 0; i < width; i++)
                {
                    sb.Append("-");
                }
                return sb.ToString();
            }

            string ULine()
            {
                int width = int.TryParse(Properties.Settings.Default.ReceiptWidth, out int r) ? r : 100;
                width -= 10;
                var sb = new StringBuilder();
                for (int i = 0; i < width; i++)
                {
                    sb.Append("_");
                }
                return sb.ToString();
            }

            var graphics = this.CreateGraphics();
            printer.AddString(string.Format("{0,-" + W(100) + "}", Properties.Settings.Default.BName), XFont.B12, g: graphics);

            var address = new XFString(W(100), Properties.Settings.Default.BAddress);
            if (address.StringLines.Count() > 0)
            {
                printer.AddString(string.Format("{0,-" + W(100) + "}", address.StringLines.ToList()[0]), XFont.R8, g: graphics);
                for (int i = 1; i < address.StringLines.Count(); i++)
                {
                    printer.AddString(string.Format("{0,-" + W(100) + "}", address.StringLines.ToList()[i]), XFont.R8, g: graphics);
                }
            }
            printer.AddString(string.Format("{0,-" + G.W(25) + "}{1,-" + G.W(50) + "}", "", Entity.TradeId), XFont.R12, XFontColor.Black, g: graphics, true);
            printer.AddVerticalSpace(graphics);
            printer.AddVerticalSpace(graphics);

            printer.AddString(string.Format("{0,-" + G.W(50) + "}", Entity.TradeName + " Slip"), XFont.B9, XFontColor.Black, g: graphics);
            printer.AddString(ULine(), XFont.B8, g: graphics);
            printer.AddVerticalSpace(graphics);
            printer.AddString(string.Format("{0,-" + W(50) + "}{1," + W(50) + "}", "Client Name", "Trade #"), XFont.B8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0,-" + W(50) + "}{1," + W(50) + "}", Entity.ClientName, Entity.TradeId), XFont.B8, g: graphics);
            printer.AddString(string.Format("{0,-" + W(50) + "}{1," + W(50) + "}", "Date", "Operator"), XFont.B8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0,-" + W(50) + "}{1," + W(50) + "}", Entity.Date, Auth.Operator()), XFont.B8, g: graphics);
            printer.AddVerticalSpace(graphics);
            printer.AddString(ULine(), XFont.B8, g: graphics);
            printer.AddVerticalSpace(graphics);
            printer.AddString(string.Format("{0,-" + W(50) + "}", "Details"), XFont.B8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0,-" + W(15) + "}{1,-" + W(35) + "}{2,-" + W(15) + "}{3,-" + W(35) + "}", "From Carrier", ": "+Entity.FromCarrier.Name, "To Carrier", ": " + Entity.ToCarrier.Name), XFont.R8, XFontColor.Black, g: graphics);
            printer.AddString(string.Format("{0,-" + W(15) + "}{1,-" + W(35) + "}", "Phone No", ": " + Entity.Phone), XFont.R8, XFontColor.Black, g: graphics);
            printer.AddString(string.Format("{0,-" + W(15) + "}{1,-" + W(35) + "}{2,-" + W(15) + "}{3,-" + W(35) + "}", "IMEI", ": " + Entity.IMEI, "Sim No", ": " + Entity.SimCardNumber), XFont.R8, XFontColor.Black, g: graphics);
            printer.AddString(string.Format("{0,-" + W(15) + "}{1,-" + W(35) + "}{2,-" + W(15) + "}{3,-" + W(35) + ":C2}", "AT Plan", ": " + Entity.AirTime.Name, "Rate", ": " + Entity.Rate), XFont.R8, XFontColor.Black, g: graphics);
            printer.AddVerticalSpace(graphics);
            printer.AddString(string.Format("{0,-" + W(35) + "}{1,-" + W(15) + "}", "Send Promo Message?", Entity.SendPromoMessage?"Yes":"NO"), XFont.R8, XFontColor.Black, g: graphics);
            printer.AddVerticalSpace(graphics);

            printer.AddString(string.Format("{0," + W(75) + "}{1," + W(5) + "}{2," + W(20) + ":C2}", "Bill Amount", "", Entity.Amount), XFont.R8, g: graphics);
            printer.AddString(string.Format("{0," + W(75) + "}{1," + W(5) + "}{2," + W(20) + ":C2}", "Discount", " %" + Entity.Discount, Entity.DiscountAmount), XFont.R8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0," + W(75) + "}{1," + W(5) + "}{2," + W(20) + ":C2}", "Subtotal", "", Entity.Subtotal), XFont.R8, g: graphics);
            printer.AddString(string.Format("{0," + W(75) + "}{1," + W(5) + "}{2," + W(20) + ":C2}", "Tax", " %" + Entity.Tax, Entity.TaxAmount), XFont.R8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0," + W(75) + "}{1," + W(5) + "}{2," + W(20) + ":C2}", "Total", "", Entity.Total), XFont.B8, g: graphics);


            if (Entity.Transactions != null && Entity.Transactions.Count > 0 && chkWithPayment.Checked)
            {
                printer.AddVerticalSpace(graphics);
                printer.AddString(string.Format("{0,-" + W(50) + "}", "Payment History"), XFont.B8, XFontColor.Gray, g: graphics);
                string trxformat = "{0,-" + W(5) + "}{1,-" + W(35) + "}{2,-" + W(25) + "}{3," + W(15) + "}{4," + W(20) + ":C2}";
                printer.AddString(string.Format(trxformat, "Sr", "TrxId", "Date", "Mode", "Amount"), XFont.B8, g: graphics);
                printer.AddString(UDotted(), XFont.B8, g: graphics);
                int sr = 1;
                foreach (var trx in Entity.Transactions)
                {

                    printer.AddString(string.Format(trxformat,
                        sr++, trx.TrxId, trx.Date.ToShortDateString().ToString(), trx.Amount), XFont.R8, g: graphics);
                }
                printer.AddVerticalSpace(graphics);

            }

            printer.AddString(string.Format("{0," + W(75) + "}{1," + W(5) + "}{2," + W(20) + ":C2}", "Paid", "", Entity.Paid), XFont.R8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0," + W(75) + "}{1," + W(5) + "}{2," + W(20) + ":C2}", "Due", "", Entity.Due), XFont.B8, g: graphics);


            if (richTextBox1.Text.Length > 0 && chkPPolicies.Checked)
            {
                printer.AddVerticalSpace(graphics);
                printer.AddString(string.Format("{0,-" + W(50) + "}", "Policies"), XFont.B8, XFontColor.Gray, g: graphics);
                string trxformat = "{0,-" + W(5) + "}{1,-" + W(95) + "}";
                int sr = 1;

                var lines = richTextBox1.Text.Split('\n');

                foreach (var ln in lines)
                {
                    var statement = new XFString(W(90), ln);
                    if (statement.StringLines.Count() > 0)
                    {
                        printer.AddString(string.Format(trxformat,
                            sr++, statement.StringLines.ToList()[0]), XFont.R8, g: graphics);
                        for (int i = 1; i < statement.StringLines.Count(); i++)
                        {
                            printer.AddString(string.Format(trxformat, "",
                                statement.StringLines.ToList()[i]), XFont.R8, g: graphics);
                        }
                    }
                }
            }

            printer.AddVerticalSpace(graphics);

            var greeting = new XFString(W(100), Properties.Settings.Default.CGreeting);
            if (greeting.StringLines.Count() > 0)
            {
                printer.AddString(string.Format("{0,-" + W(100) + "}", greeting.StringLines.ToList()[0]), XFont.R8, g: graphics);
                for (int i = 1; i < greeting.StringLines.Count(); i++)
                {
                    printer.AddString(string.Format("{0,-" + W(100) + "}", greeting.StringLines.ToList()[i]), XFont.R8, g: graphics);
                }
            }

        }


        private void Label42_Click(object sender, EventArgs e)
        {

        }



        private void Button2_Click(object sender, EventArgs e)
        {
            new TransactionView<Portin>(Adapter, Entity, TransactionType.Refund, this);
            BindEntity();
            InvalidateForm();
        }

      

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            XPrinter printer = new XPrinter(printerName: Settings.Default.ReceiptPrinter, topMargin: 10, leftMargin: 10);
            PrintReceipt(printer);

            printer.Print(this, true);
        }

        private void chkTax_CheckedChanged(object sender, EventArgs e)
        {
            InvalidateTaxControls();
        }

        private void InvalidateTaxControls()
        {
            if (chkTax.Checked)
            {
                chkIncTax.Text = Properties.Settings.Default.Tax.ToString();
                chkIncTax.Enabled = true;

            }
            else
            {
                chkIncTax.Text = 0.ToString();
                chkIncTax.Enabled = false;
            }

            ValidateChildren();
        }
    }
}
