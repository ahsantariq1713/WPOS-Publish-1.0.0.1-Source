﻿using System;
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
    public partial class CallingCardEditView : Form
    {
        private readonly Form owner;
        private WaitWin wait;
        private List<Company> companies;

        public CallingCard Entity { get; private set; }
        public Adapter Adapter { get; }

        public CallingCardEditView(Adapter adapter, int id, Form owner = null)
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
            if (id == 0) Entity = new CallingCard() { Tax = Properties.Settings.Default.Tax};
            else
            {
                Entity = await Adapter.Retrive<CallingCard>(id);
                if (Entity == null)
                {
                    wait.Close();
                    Message.Stop("No CallingCard found to show.");
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

            companies = (await Adapter.Retrive<Company>())?.ToList();
            BindCompanies();

            LoadCCodes();

            InvalidateForm();
            Display();

        }

        private void LoadCCodes()
        {
            foreach (var code in countryCodes)
            {
                ddlCCodes.Items.Add(code);
            }
        }

        private void BindCompanies()
        {
            companyBindingSource.Clear();
            companies?.ToList().ForEach(x =>
            {
                companyBindingSource.Add(x);
            });
        }

        private void DdlCompany_TextChanged(object sender, EventArgs e)
        {
            var text = ddlCompany.Text;
            if (text.IsNull())
            {
                btnAddCompany.Enabled = false;
                return;
            }
            var found = companies?.Find(x => XString.Equal(x.Name, text));
            if (found != null) btnAddCompany.Enabled = false;
            else btnAddCompany.Enabled = true;
        }

        private async void btnAddCompany_Click(object sender, EventArgs e)
        {
            if (btnAddCompany.IsBusy()) return;
            btnAddCompany.MarkBusy(out Image image, out Color color);
            var company = new Company { Name = ddlCompany.Text };
            int changes = await Adapter.Save(company);
            btnAddCompany.MarkFree(image, color);
            if (changes <= 0) return;
            companies.Add(company);
            companyBindingSource.Add(company);
            ddlCompany.SelectedItem = company;
            btnAddCompany.Enabled = false;
        }


        public void BindEntity()
        {
            callingCardBindingSource.Clear();
            callingCardBindingSource.Add(Entity);
        }

        public void BindCustomer()
        {
            customerBindingSource.Clear();
            customerBindingSource.Add(Entity.Customer);

            //InvalidateFinishButton();
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
                lblTitle.Text = "          New CallingCard";
                billBtnPanel.Enabled = false;
                btnAddCustomer.Enabled = true;
                btnFindCustomer.Enabled = true;
            }
            else
            {
                lblTitle.Text = "          Edit CallingCard";
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

            //InvalidateFinishButton();
        }


        private void UpdateBill()
        {
            txtBillAmount.Text = string.Format("{0:0,0.00}", Entity.Amount);
            txtBillDiscountAmount.Text = string.Format("{0:0,0.00}", Entity.DiscountAmount);
            txtBillSubtotal.Text = string.Format("{0:0,0.00}", Entity.Subtotal);
            txtBillTaxAmount.Text = string.Format("{0:0,0.00}", Entity.TaxAmount);
            txtBillTotal.Text = string.Format("{0:0,0.00}", Entity.Total);
            txtBillDue.Text = string.Format("{0:0,0.00}", Entity.Due);

            //InvalidateFinishButton();
        }


        //public void InvalidateFinishButton()
        //{
        //    if (Entity.IsNew)
        //    {
        //        if (Entity.Total <= 0 || Entity.Customer == null)
        //        {
        //            btnSave.Enabled = false;
        //        }new SearchView<Customer>("Supplier", customers, new List<DGColumn>
        //        else
        //        {
        //            btnSave.Enabled = true;
        //        }
        //    }
        //}

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

            //InvalidateFinishButton();
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
                if (Entity.Transactions?.Count == 0) new TransactionView<CallingCard>(Adapter, Entity, TransactionType.Cashin, this);
            }
            btnSave.MarkFree(image, color);
            btnPrint.Focus();
            BindEntity();
            InvalidateForm();
            this.Close();
        }

        private void BtnTransactionInitiate_Click(object sender, EventArgs e)
        {
            new TransactionView<CallingCard>(Adapter, Entity, TransactionType.Cashin, this);
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
            printer.AddString(string.Format("{0,-" + W(15) + "}{1,-" + W(35) + "}{2,-" + W(15) + "}{3,-" + W(35) + "}", "Loc. Phone", ": " + Entity.LocalPhone, "Int. Phone", ": " + Entity.CCode+"-" + Entity.Phone), XFont.R8, XFontColor.Black, g: graphics);
            printer.AddString(string.Format("{0,-" + W(15) + "}{1,-" + W(35) + ":C2}", "Company", ": " + Entity.Company), XFont.R8, XFontColor.Black, g: graphics);
            printer.AddString(string.Format("{0,-" + W(15) + "}{1,-" + W(35) + ":C2}", "Price", ": " + Entity.Price), XFont.R8, XFontColor.Black, g: graphics);

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
            new TransactionView<CallingCard>(Adapter, Entity, TransactionType.Refund, this);
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

        private void Panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private readonly string[] countryCodes = new string[] {
            "+93",
            "+355",
            "+213",
            "+1-684",
            "+376",
            "+244",
            "+1-264",
            "+672",
            "+1-268",
            "+54",
            "+374",
            "+297",
            "+61",
            "+43",
            "+994",
            "+1-242",
            "+973",
            "+880",
            "+1-246",
            "+375",
            "+32",
            "+501",
            "+229",
            "+1-441",
            "+975",
            "+591",
            "+387",
            "+267",
            "+55",
            "+673",
            "+359",
            "+226",
            "+257",
            "+855",
            "+237",
            "+1",
            "+238",
            "+1-345",
            "+236",
            "+235",
            "+56",
            "+86",
            "+53",
            "+61",
            "+57",
            "+269",
            "+243",
            "+242",
            "+682",
            "+506",
            "+225",
            "+385",
            "+53",
            "+357",
            "+420",
            "+45",
            "+253",
            "+1-767",
            "+1-809",
            "+1-829",
            "+670",
            "+593",
            "+20",
            "+503",
            "+240",
            "+291",
            "+372",
            "+251",
            "+500",
            "+298",
            "+679",
            "+358",
            "+33",
            "+594",
            "+689",
            "+241",
            "+220",
            "+995",
            "+49",
            "+233",
            "+350",
            "+30",
            "+299",
            "+1-473",
            "+590",
            "+1-671",
            "+502",
            "+224",
            "+245",
            "+592",
            "+509",
            "+504",
            "+852",
            "+36",
            "+354",
            "+91",
            "+62",
            "+98",
            "+964",
            "+353",
            "+972",
            "+39",
            "+1-876",
            "+81",
            "+962",
            "+7",
            "+254",
            "+686",
            "+850",
            "+82",
            "+965",
            "+996",
            "+856",
            "+371",
            "+961",
            "+266",
            "+231",
            "+218",
            "+423",
            "+370",
            "+352",
            "+853",
            "+389",
            "+261",
            "+265",
            "+60",
            "+960",
            "+223",
            "+356",
            "+692",
            "+596",
            "+222",
            "+230",
            "+269",
            "+52",
            "+691",
            "+373",
            "+377",
            "+976",
            "+1-664",
            "+212",
            "+258",
            "+95",
            "+264",
            "+674",
            "+977",
            "+31",
            "+599",
            "+687",
            "+64",
            "+505",
            "+227",
            "+234",
            "+683",
            "+672",
            "+1-670",
            "+47",
            "+968",
            "+92",
            "+680",
            "+970",
            "+507",
            "+675",
            "+595",
            "+51",
            "+63",
            "+48",
            "+351",
            "+1-787",
            "+1-939",
            "+974",
            "+262",
            "+40",
            "+7",
            "+250",
            "+290",
            "+1-869",
            "+1-758",
            "+508",
            "+1-784",
            "+685",
            "+378",
            "+239",
            "+966",
            "+221",
            "+248",
            "+232",
            "+65",
            "+421",
            "+386",
            "+677",
            "+252",
            "+27",
            "+34",
            "+94",
            "+249",
            "+597",
            "+268",
            "+46",
            "+41",
            "+963",
            "+886",
            "+992",
            "+255",
            "+66",
            "+690",
            "+676",
            "+1-868",
            "+216",
            "+90",
            "+993",
            "+1-649",
            "+688",
            "+256",
            "+380",
            "+971",
            "+44",
            "+1",
            "+598",
            "+998",
            "+678",
            "+418",
            "+58",
            "+84",
            "+1-284",
            "+1-340",
            "+681",
            "+967",
            "+260",
            "+263"
        };

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateBill();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            XPrinter printer = new XPrinter(printerName: Settings.Default.ReceiptPrinter, topMargin: 10, leftMargin: 10);
            PrintReceipt(printer);

            printer.Print(this, true);
        }
    }

}