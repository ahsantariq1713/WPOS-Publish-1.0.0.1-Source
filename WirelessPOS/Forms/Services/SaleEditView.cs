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
    public partial class SaleEditView : Form
    {
        private SaleItem currentSaleItem;
        private readonly Form owner;
        private WaitWin wait;
        public Sale Entity { get; private set; }
        public Adapter Adapter { get; }

        public SaleEditView(Adapter adapter, int id, Form owner = null)
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
            if (id == 0) Entity = new Sale() { Tax = Properties.Settings.Default.Tax };
            else
            {
                Entity = await Adapter.Retrive<Sale>(id);
                if (Entity == null)
                {
                    wait.Close();
                    Message.Stop("No customer found to show.");
                    this.Dispose();
                    return;
                }
                await EntityLoader.LoadComponents(Entity, Adapter);
            }
            

            Entity.SaleItems = Entity.SaleItems?? new List<SaleItem>();
            Entity.Transactions = Entity.Transactions ?? new List<Transaction>();

            BindEntity();
            var polices =
                  (await Adapter.Retrive<Policy>(withRelatedData: true, activeOnly: true))?.ToList()
                  .FindAll(x =>
                  {
                      return XString.Equal(x.PolicyType.Name, "Sale");
                  });

            var sb = new StringBuilder();
            var i = 1;
            foreach (var policy in polices)
            {
                sb.AppendLine(i++ + ". " + policy.Statement);
            }
            richTextBox1.Text = sb.ToString();

            InvalidateForm();
            Display();
            
        }

        public void BindEntity()
        {
            saleBindingSource.Clear();
            saleBindingSource.Add(Entity);

            BindSupplier();
            BindPurcahseItems();
        }

        public void BindSupplier()
        {
            customerBindingSource.Clear();
            customerBindingSource.Add(Entity.Customer);

            //InvalidateFinishButton()
        }

        public void BindSaleItem()
        {
            saleItemBindingSource.Clear();
            saleItemBindingSource.Add(currentSaleItem);
        }

        public void BindPurcahseItems()
        {
            grid.DataSource = typeof(IEnumerable<SaleItem>);
            grid.DataSource = Entity.SaleItems.ToList() as IEnumerable<SaleItem>;

            if (grid.Rows.Count>0) grid.Rows[grid.Rows.Count - 1].Selected = true;

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.Visible = false;
            }


            var colSerial = grid.Columns["Serial"];
            colSerial.Visible = true;
            colSerial.DisplayIndex = 0;
            colSerial.Width = 150;

            var colCode = grid.Columns["Code"];
            colCode.Visible = true;
            colCode.DisplayIndex = 1;
            colCode.Width = 150;


            var colName = grid.Columns["Name"];
            colName.Visible = true;
            colName.DisplayIndex = 2;

            var colSPrice = grid.Columns["SalePrice"];
            colSPrice.Visible = true;
            colSPrice.DisplayIndex = 3;
            colSPrice.Width = 150;
            colSPrice.HeaderText = "Price";
            colSPrice.DefaultCellStyle.Format = "0,0.0";

            var colQuantity = grid.Columns["Quantity"];
            colQuantity.Visible = true;
            colQuantity.DisplayIndex = 4;
            colQuantity.Width = 100;

            var colUnit = grid.Columns["Unit"];
            colUnit.Visible = true;
            colUnit.DisplayIndex = 5;
            colUnit.Width = 70;

            var colAmount = grid.Columns["Amount"];
            colAmount.Visible = true;
            colAmount.DisplayIndex = 6;
            colAmount.Width = 150;
            colAmount.DefaultCellStyle.Format = "0,0.0";

            gridTotals.Rows.Clear();
            gridTotals.Rows.Add(
                "",
                "",
                "",
                string.Format("{0:$0,0.00}", Entity.SaleItems?.Sum(x => x.PurchasePrice) ?? 0),
                string.Format("{0}", Entity.SaleItems?.Sum(x => x.Quantity) ?? 0),
                "",
               string.Format("{0:$0,0.00}", Entity.SaleItems?.Sum(x => x.Amount) ?? 0));
            gridTotals.Columns[0].Width = grid.Columns["Code"].Width;
            gridTotals.Columns[1].Width = grid.Columns["Serial"].Width;
            gridTotals.Columns[2].Width = grid.Columns["Name"].Width;
            gridTotals.Columns[3].Width = grid.Columns["SalePrice"].Width;
            gridTotals.Columns[4].Width = grid.Columns["Quantity"].Width;
            gridTotals.Columns[5].Width = grid.Columns["Unit"].Width;
            gridTotals.Columns[6].Width = grid.Columns["Amount"].Width;

            UpdateBill();
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
                lblTitle.Text = "          New Sale";
                btnTransactionInitiate.Enabled = false;
                billBtnPanel.Enabled = false;
                gridBtnsPanel.Enabled = true;
                btnAddCustomer.Enabled = true;
                btnFindCustomer.Enabled = true;
                panelHead.Enabled = true;
                btnFinish.Enabled = true;

                //InvalidateFinishButton()
            }
            else
            {
                lblTitle.Text = "          Edit Sale";
                btnTransactionInitiate.Enabled = true;
                billBtnPanel.Enabled = true;
                gridBtnsPanel.Enabled = false;
                btnAddCustomer.Enabled = false;
                btnFindCustomer.Enabled = false;
                panelHead.Enabled = false;
                btnFinish.Enabled = false;
            }

            if (Entity.Due <= 0)
            {
                btnTransactionInitiate.Enabled = false;
            }
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
                    btnFinish.Enabled = false;
                }
                else
                {
                    btnFinish.Enabled = true;
                }
            }
        }


        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////


        private async void BtnFindCustomer_Click(object sender, EventArgs e)
        {
            if (btnFindCustomer.IsBusy()) return;
            if (string.IsNullOrWhiteSpace(txtCustomerSearch.Text)) return;
            btnFindCustomer.MarkBusy(out Image image, out Color color);

            var customers =
                (await Adapter.Retrive<Customer>())?.ToList()
                .FindAll(x => {
                    return
                    XString.Equal(x.Phone.RemovePhoneFormat(), txtCustomerSearch.Text) ||
                    XString.Contains(x.Name, txtCustomerSearch.Text);
                });

            btnFindCustomer.MarkFree(image, color);

            if (customers != null && customers.Count > 0)
            {
               var searchView = new SearchView<Customer>("Supplier", customers, new List<DGColumn> {
                    new DGColumn("Id",0,50),
                    new DGColumn("Name",1,200),
                    new DGColumn("Phone",2,150),
                   new DGColumn("Email",3,150)

                });
                var result = searchView.ShowDialog(this);
                if(result == DialogResult.OK) {
                    Entity.Customer = customers.Find(x => x.Id == searchView.SelectedEntityId);
                    BindSupplier();
                    txtCustomerSearch.Clear();
                    txtCodeSearch.Focus();
                }
            }
            else
            {
                Message.Stop("No customer(s) found.");
//                txtSupplierSearch.SelectAll();
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
             new CustomerEditView(adapter, 0,this);

        }

        private async void BtnFindItem_Click(object sender, EventArgs e)
        {
            if (btnFindItem.IsBusy()) return;
            if (string.IsNullOrWhiteSpace(txtStockSearch.Text)) return;
            btnFindItem.MarkBusy(out Image image, out Color color);
            var stockItems = await LoadStockItems();
            var stock =   stockItems?.ToList().FindAll(x=>x.Quantity>0)?.FindAll(x => {
                    return
                    //XString.Equal(x.PurchaseItem.Code, txtStockSearch.Text) ||
                    XString.Contains(x.PurchaseItem.Name, txtStockSearch.Text) ||
                    XString.Contains(x.PurchaseItem.Item.Category, txtStockSearch.Text) ||
                    XString.Contains(x.PurchaseItem.Item.Brand, txtStockSearch.Text);
                });

            btnFindItem.MarkFree(image, color);

            if (stock != null && stock.Count > 0)
            {
                var searchView = new SearchView<StockItem>("Stock", stock, new List<DGColumn> {
                    new DGColumn(nameof(StockItem.Code),0,150),
                    new DGColumn(nameof(StockItem.Serial),1,70),
                    new DGColumn(nameof(StockItem.Name),2,150),
                    new DGColumn(nameof(StockItem.Category),3,100),
                    new DGColumn(nameof(StockItem.SalePrice),4,150),
                    new DGColumn(nameof(StockItem.Quantity),5,100),
                });
                var result = searchView.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var selectedStock = stock.Find(x => x.Id == searchView.SelectedEntityId);
                    currentSaleItem = new SaleItem { StockItem = selectedStock, SalePrice = selectedStock.SalePrice };
                    BindSaleItem();
                    txtStockSearch.Clear();
                }
            }
            else
            {
                Message.Stop("No stock(s) found.");
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (currentSaleItem == null) return;
            Entity.SaleItems.Add(currentSaleItem);
            BindPurcahseItems();
            currentSaleItem = null;
            saleItemBindingSource.Clear();
            txtCodeSearch.SelectAll();
            txtCodeSearch.Focus();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            btnEditRow.Enabled = true;
            btnDeleteRow.Enabled = true;

            if (grid.SelectedRows.Count <= 0)
            {
                btnDeleteRow.Enabled = false;
                btnEditRow.Enabled = false;
            }else if(grid.SelectedRows.Count > 1)
            {
                btnEditRow.Enabled = false;
            }

        }

        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grid.SelectedRows)
            {
               var code =  row.Cells["Code"].Value.ToString();
               var found = Entity.SaleItems?.ToList().Find(x => x.Code == code);
               if (found != null) { Entity.SaleItems.Remove(found); }
               BindPurcahseItems();
                txtCodeSearch.SelectAll();
                txtCodeSearch.Focus();
            }
        }

        private void BtnEditRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                var code = row.Cells["Code"].Value.ToString();
                var found = Entity.SaleItems?.ToList().Find(x => x.Code == code);
                if (found != null) { Entity.SaleItems.Remove(found); }
                currentSaleItem = found;
                BindSaleItem();
                BindPurcahseItems();
                txtQuantity.SelectAll();
                txtQuantity.Focus();
                
            }
        }

        private async void BtnFinish_Click(object sender, EventArgs e)
        {
            if (Entity.HasErrors(out string errors))
            {
                Message.Error("Please fix the following errors to continue:\n" + errors);
                return;
            }
            if (btnFinish.IsBusy()) return;
            ValidateChildren();
            btnFinish.MarkBusy(out Image image, out Color color);
            foreach (var saleItem in Entity.SaleItems)
            {
                var stockItem = saleItem.StockItem;
                stockItem.Sold(saleItem.Quantity);
            }

            var changes = await Adapter.Save(Entity);
            if (changes > 0)
            {
                if (Entity.Transactions?.Count == 0) new TransactionView<Sale>(Adapter, Entity, TransactionType.Cashin, this);
            }
            btnFinish.MarkFree(image, color);
            btnPrint.Focus();
            BindEntity();
            InvalidateForm();
            this.Close();
        }

        private async void BtnFindCode_Click(object sender, EventArgs e)
        {
            if (btnFindCode.IsBusy()) return;
            if (string.IsNullOrWhiteSpace(txtCodeSearch.Text)) return;
            btnFindCode.MarkBusy(out Image image, out Color color);
            var stockItems = await LoadStockItems();
            var stock = stockItems?.ToList()?.Find(x =>
            {
                return XString.Equal(x.PurchaseItem.Code, txtCodeSearch.Text) && x.Quantity > 0;
            });

            btnFindCode.MarkFree(image, color);

            if (stock != null)
            {
                currentSaleItem = new SaleItem { StockItem = stock, SalePrice = stock.SalePrice };
                BindSaleItem();
            }
            else
            {
                currentSaleItem = null;
                saleItemBindingSource.Clear();
                txtCodeSearch.SelectAll();
                txtCodeSearch.Focus();
            }


        }

        private async Task<IEnumerable<StockItem>> LoadStockItems()
        {
            var stockItems = await Adapter.Retrive<StockItem>();
            foreach (var stockItem in stockItems)
            {
                await Adapter.LoadRelatedData(stockItem);
                await Adapter.LoadRelatedData(stockItem.PurchaseItem);
                await Adapter.LoadRelatedData(stockItem.PurchaseItem.Item);
            }

            return stockItems;
        }

        private void BtnTransactionInitiate_Click(object sender, EventArgs e)
        {
            new TransactionView<Sale>(Adapter, Entity, TransactionType.Cashin, this,true);
            BindEntity();
                InvalidateForm();
            
        }

        private void BtnTransaction_Click(object sender, EventArgs e)
        {
              new TransactionsListView<Transaction>("Sale Transactions", Resources.icons8_transaction_list_30px,
                  Entity,Entity.Transactions, new List<DGColumn> {
                    new DGColumn("Date",0,100),
                    new DGColumn("TrxId",1,150),
                    new DGColumn("Amount",2,70),
                    new DGColumn("Cash",3,70),
                    new DGColumn("Return",4,70)
                },this);
        }
        private async void PurchaseEditView_Load(object sender, EventArgs e)
        {
            chkTax.Checked = Properties.Settings.Default.IncludeTax;
            InvalidateTaxControls();
            txtCodeSearch.Focus();
            await Task.Run(() => webBrowser1.Navigate(AdHandler.AdUrl));
        }


        private async void Button1_Click(object sender, EventArgs e)
        {
            if (btnFindSerial.IsBusy()) return;
            if (string.IsNullOrWhiteSpace(txtCodeSearch.Text)) return;
            btnFindSerial.MarkBusy(out Image image, out Color color);
            var stockItems = await LoadStockItems();
            var stock = stockItems?.ToList()?.Find(x =>
            {
                return XString.Equal(x.PurchaseItem.Serial, txtSearialSearch.Text) && x.Quantity > 0;
            });

            btnFindSerial.MarkFree(image, color);

            if (stock != null)
            {
                currentSaleItem = new SaleItem { StockItem = stock, SalePrice = stock.SalePrice };
                BindSaleItem();
            }
            else
            {
                currentSaleItem = null;
                saleItemBindingSource.Clear();
                txtCodeSearch.SelectAll();
                txtCodeSearch.Focus();
            }

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
            printer.AddString(string.Format("{0,-" + G.W(100) + "}", Properties.Settings.Default.BName), XFont.B12, g: graphics);

            var address = new XFString(G.W(100), Properties.Settings.Default.BAddress);
            if (address.StringLines.Count() > 0)
            {
                printer.AddString(string.Format("{0,-" + G.W(100) + "}", address.StringLines.ToList()[0]), XFont.R8, g: graphics);
                for (int i = 1; i < address.StringLines.Count(); i++)
                {
                    printer.AddString(string.Format("{0,-" + G.W(100) + "}", address.StringLines.ToList()[i]), XFont.R8, g: graphics);
                }
            }
            printer.AddString(string.Format("{0,-" + G.W(25) + "}{1,-" + G.W(50) + "}", "", Entity.TradeId), XFont.R12, XFontColor.Black, g: graphics, true);
            printer.AddVerticalSpace(graphics);
            printer.AddVerticalSpace(graphics);

            printer.AddString(string.Format("{0,-" + G.W(50) + "}", Entity.TradeName+" Slip"), XFont.B9, XFontColor.Black, g: graphics);
            printer.AddString(G.ULine(), XFont.B8, g: graphics);
            printer.AddVerticalSpace(graphics);
            printer.AddString(string.Format("{0,-" + G.W(50) + "}{1," + G.W(50) + "}", "Client Name", "Trade #"), XFont.B8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0,-" + G.W(50) + "}{1," + G.W(50) + "}", Entity.ClientName, Entity.TradeId), XFont.B8, g: graphics);
            printer.AddString(string.Format("{0,-" + G.W(50) + "}{1," + G.W(50) + "}", "Date", "Operator"), XFont.B8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0,-" + G.W(50) + "}{1," + G.W(50) + "}", Entity.Date, Auth.Operator()), XFont.B8, g: graphics);
            printer.AddVerticalSpace(graphics);
            printer.AddString(G.ULine(), XFont.B8, g: graphics);


            if (Entity.SaleItems != null && Entity.SaleItems.Count > 0)
            {
                printer.AddVerticalSpace(graphics);
                printer.AddString(string.Format("{0,-" + G.W(50) + "}", "Items"), XFont.B8, XFontColor.Gray, g: graphics);
                string format = "{0,-" + G.W(5) + "}{1,-" + G.W(20) + "}{2,-" + G.W(30) + "}{3,-" + G.W(15) + ":C2}{4,-" + G.W(15) + ":N2}{5,-" + G.W(15) + ":C2}";
                printer.AddString(string.Format(format, "Sr", "Name", "ID", "Price", "Qtty", "Amount"), XFont.B8, g: graphics);
                printer.AddString(G.UDotted(), XFont.B8, g: graphics);
                int sr = 1;
                foreach (var item in Entity.SaleItems)
                {
                    var itemName = new XFString(G.W(20), item.Name);
                    if (itemName.StringLines.Count() > 0)
                    {
                        printer.AddString(string.Format(format,
                            sr++, itemName.StringLines.ToList()[0], item.Serial, item.SalePrice, item.Quantity, item.Amount), XFont.R8, g: graphics);
                        for (int i = 1; i < itemName.StringLines.Count(); i++)
                        {
                            printer.AddString(string.Format(format, "",
                                itemName.StringLines.ToList()[i], "", "", "", "", ""), XFont.R8, g: graphics);
                        }
                    }
                }
                printer.AddString(G.UDotted(), XFont.B8, g: graphics);
                printer.AddString(string.Format(format, "", "", "","",
                   Entity.SaleItems.Sum(x => x.Quantity),
                  "",
                   Entity.SaleItems.Sum(x => x.Amount)), XFont.B8, g: graphics);
                printer.AddString(G.UDotted(), XFont.B8, g: graphics);
                printer.AddVerticalSpace(graphics);

            }

            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Bill Amount", "", Entity.Amount), XFont.R8, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Discount", " %" + Entity.Discount, Entity.DiscountAmount), XFont.R8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Subtotal", "", Entity.Subtotal), XFont.R8, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Tax", " %" + Entity.Tax, Entity.TaxAmount), XFont.R8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Total", "", Entity.Total), XFont.B8, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Paid", "", Entity.Paid), XFont.R8, XFontColor.Gray, g: graphics);

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

            var greeting = new XFString(G.W(100), Properties.Settings.Default.CGreeting);
            if (greeting.StringLines.Count() > 0)
            {
                printer.AddString(string.Format("{0,-" + G.W(100) + "}", greeting.StringLines.ToList()[0]), XFont.R8, g: graphics);
                for (int i = 1; i < greeting.StringLines.Count(); i++)
                {
                    printer.AddString(string.Format("{0,-" + G.W(100) + "}", greeting.StringLines.ToList()[i]), XFont.R8, g: graphics);
                }
            }

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            XPrinter printer = new XPrinter(printerName: Settings.Default.ReceiptPrinter, topMargin: 10, leftMargin: 10);
            PrintReceipt(printer);

            printer.Print(this, true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
