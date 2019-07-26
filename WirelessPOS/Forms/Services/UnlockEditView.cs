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
    public partial class UnlockEditView : Form
    {
        private readonly Form owner;
        private WaitWin wait;
        private List<Device> devices;

        public Unlock Entity { get; private set; }
        public Adapter Adapter { get; }

        public UnlockEditView(Adapter adapter, int id, Form owner = null)
        {
            Adapter = adapter;
            this.owner = owner;
            Owner = owner;

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
            if (id == 0) Entity = new Unlock() { Tax = Properties.Settings.Default.Tax };
            else
            {
                Entity = await Adapter.Retrive<Unlock>(id);
                if (Entity == null)
                {
                    wait.Close();
                    Message.Stop("No Unlock found to show.");
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

            devices = (await Adapter.Retrive<Device>())?.ToList();
            BindDevices();

         
            InvalidateForm();
            Display();

        }

        private void BindDevices()
        {
            deviceBindingSource.Clear();
            devices?.ToList().ForEach(x =>
            {
                deviceBindingSource.Add(x);
            });
        }

        private void DdlFromCarrier_TextChanged(object sender, EventArgs e)
        {
            var text = ddlDevice.Text;
            if (text.IsNull())
            {
                btnAddDevice.Enabled = false;
                return;
            }
            var found = devices?.Find(x => XString.Equal(x.Name, text));
            if (found != null) btnAddDevice.Enabled = false;
            else btnAddDevice.Enabled = true;
        }

        private async void btnAddDevice_Click(object sender, EventArgs e)
        {
            if (btnAddDevice.IsBusy()) return;
            btnAddDevice.MarkBusy(out Image image, out Color color);
            var device = new Device { Name = ddlDevice.Text };
            int changes = await Adapter.Save(device);
            btnAddDevice.MarkFree(image, color);
            if (changes <= 0) return;
            devices.Add(device);
            deviceBindingSource.Add(device);
            ddlDevice.SelectedItem = device;
            btnAddDevice.Enabled = false;
        }


        public void BindEntity()
        {
            unlockBindingSource.Clear();
            unlockBindingSource.Add(Entity);
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
                lblTitle.Text = "          New Unlock";
                billBtnPanel.Enabled = false;
                btnAddCustomer.Enabled = true;
                btnFindCustomer.Enabled = true;
            }
            else
            {
                lblTitle.Text = "          Edit Unlock";
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
                if (Entity.Transactions?.Count == 0) new TransactionView<Unlock>(Adapter, Entity, TransactionType.Cashin, this);
            }
            btnSave.MarkFree(image, color);
            btnPrint.Focus();
            BindEntity();
            InvalidateForm();
            this.Close();
        }

        private void BtnTransactionInitiate_Click(object sender, EventArgs e)
        {
            new TransactionView<Unlock>(Adapter, Entity, TransactionType.Cashin, this);
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
            printer.AddString(string.Format("{0,-" + W(15) + "}{1,-" + W(35) + "}{2,-" + W(15) + "}{3,-" + W(35) + "}", "Device", ": "+Entity.Device.Name, "IMEI", ": " + Entity.IMEI), XFont.R8, XFontColor.Black, g: graphics);
            printer.AddString(string.Format("{0,-" + W(15) + "}{1,-" + W(35) + ":C2}", "Carhges", ": " + Entity.Charges), XFont.R8, XFontColor.Black, g: graphics);
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
                        sr++, trx.TrxId, trx.Date.ToShortDateString(), trx.TransactionType.ToString(), trx.Amount), XFont.R8, g: graphics);
                }
                printer.AddVerticalSpace(graphics);

            }

            printer.AddString(string.Format("{0," + W(75) + "}{1," + W(5) + "}{2," + W(20) + ":C2}", "Paid", "", Entity.Paid), XFont.R8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0," + W(75) + "}{1," + W(5) + "}{2," + W(20) + ":C2}", "Due", "", Entity.Due), XFont.B8, g: graphics);

            if (Entity.Policies != null && Entity.Policies.Count > 0 && chkPPolicies.Checked)
            {
                printer.AddVerticalSpace(graphics);
                printer.AddString(string.Format("{0,-" + W(50) + "}", "Policies"), XFont.B8, XFontColor.Gray, g: graphics);
                string trxformat = "{0,-" + W(5) + "}{1,-" + W(95) + "}";
                int sr = 1;
                foreach (var policy in Entity.Policies)
                {
                    var statement = new XFString(W(90), policy.Statement);
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
            new TransactionView<Unlock>(Adapter, Entity, TransactionType.Refund, this);
            BindEntity();
            InvalidateForm();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

            var view = new PolicySelectionView(Adapter);
            var result = view.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Entity.Policies = view.SelectedPolicies?.ToList();
                BindPolicies();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            XPrinter printer = new XPrinter(printerName: Settings.Default.ReceiptPrinter, topMargin: 10, leftMargin: 10);
            PrintReceipt(printer);

            printer.Print(this, true);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateBill();
        }
    }
}
