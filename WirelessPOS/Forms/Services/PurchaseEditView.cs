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
    public partial class PurchaseEditView : Form
    {
        private PurchaseItem currentPurchaseItem;
        private readonly Form owner;
        private WaitWin wait;
        public Purchase Entity { get; private set; }
        public Adapter Adapter { get; }

        public PurchaseEditView(Adapter adapter, int id,Form owner = null)
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
            if (id == 0) Entity = new Purchase() { Tax = Properties.Settings.Default.Tax };
            else
            {
                Entity = await Adapter.Retrive<Purchase>(id);
                if (Entity == null)
                {
                    wait.Close();
                    Message.Stop("No puchase found to show.");
                    this.Dispose();
                    return;
                }

                await EntityLoader.LoadComponents(Entity, Adapter);
            }

            Entity.PurchaseItems = Entity.PurchaseItems ?? new List<PurchaseItem>();
            Entity.Transactions = Entity.Transactions ?? new List<Transaction>();

            BindEntity();

            InvalidateForm();
            Display();

        }

        public void BindEntity()
        {
            purchaseBindingSource.Clear();
            purchaseBindingSource.Add(Entity);

            BindSupplier();
            BindPurcahseItems();
        }

        public void BindSupplier()
        {
            supplierBindingSource.Clear();
            supplierBindingSource.Add(Entity.Supplier);
        }

        public void BindPurchaseItem()
        {
            purchaseItemBindingSource.Clear();
            purchaseItemBindingSource.Add(currentPurchaseItem);
        }

        public void BindPurcahseItems()
        {
            grid.DataSource = typeof(IEnumerable<PurchaseItem>);
            grid.DataSource = Entity.PurchaseItems.ToList() as IEnumerable<PurchaseItem>;

            if (grid.Rows.Count > 0) grid.Rows[grid.Rows.Count - 1].Selected = true;

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
            colSPrice.HeaderText = "S. Price";
            colSPrice.DefaultCellStyle.Format = "0,0.0";

            var colPPrice = grid.Columns["PurchasePrice"];
            colPPrice.Visible = true;
            colPPrice.DisplayIndex = 4;
            colPPrice.Width = 150;
            colPPrice.HeaderText = "P. Price";
            colPPrice.DefaultCellStyle.Format = "0,0.0";

            var colQuantity = grid.Columns["Quantity"];
            colQuantity.Visible = true;
            colQuantity.DisplayIndex = 5;
            colQuantity.Width = 100;

            var colUnit = grid.Columns["Unit"];
            colUnit.Visible = true;
            colUnit.DisplayIndex = 6;
            colUnit.Width = 70;

            var colAmount = grid.Columns["Amount"];
            colAmount.Visible = true;
            colAmount.DisplayIndex = 7;
            colAmount.Width = 150;
            colAmount.DefaultCellStyle.Format = "0,0.0";

            gridTotals.Rows.Clear();
            gridTotals.Rows.Add(
                "",
                "",
                "",
                string.Format("{0:$0,0.00}", Entity.PurchaseItems?.Sum(x => x.SalePrice) ?? 0),
                string.Format("{0:$0,0.00}", Entity.PurchaseItems?.Sum(x => x.PurchasePrice) ?? 0),
                string.Format("{0}", Entity.PurchaseItems?.Sum(x => x.Quantity) ?? 0),
                "",
               string.Format("{0:$0,0.00}", Entity.PurchaseItems?.Sum(x => x.Amount) ?? 0));

            gridTotals.Columns[0].Width = grid.Columns["Code"].Width;
            gridTotals.Columns[1].Width = grid.Columns["Serial"].Width;
            gridTotals.Columns[2].Width = grid.Columns["Name"].Width;
            gridTotals.Columns[3].Width = grid.Columns["SalePrice"].Width;
            gridTotals.Columns[4].Width = grid.Columns["PurchasePrice"].Width;
            gridTotals.Columns[5].Width = grid.Columns["Quantity"].Width;
            gridTotals.Columns[6].Width = grid.Columns["Unit"].Width;
            gridTotals.Columns[7].Width = grid.Columns["Amount"].Width;

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
            gridBtnsPanel.Enabled = Entity.IsStockUpdateable;
            btnUpdateStock.Enabled = Entity.IsStockUpdateable;
            cartPanel.Enabled = Entity.IsStockUpdateable;
            lblTitle.Text = "          "+ (Entity.IsNew?"New Purchase":"Edit Purchase");
            billBtnPanel.Enabled = Entity.IsNew ? false:true;
            btnTransactionInitiate.Enabled = Entity.Due <= 0 ? false : true;
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
                if (Entity.Total <= 0 || Entity.Supplier == null)
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

            if (btnFindSupplier.IsBusy()) return;
            if (string.IsNullOrWhiteSpace(txtSupplierSearch.Text)) return;
            btnFindSupplier.MarkBusy(out Image image, out Color color);

            var suppliers =
                (await Adapter.Retrive<Supplier>())?.ToList()
                .FindAll(x => {
                    return
                    XString.Equal(x.Phone.RemovePhoneFormat(), txtSupplierSearch.Text) ||
                    XString.Contains(x.Name, txtSupplierSearch.Text) ||
                    XString.Contains(x.Company, txtSupplierSearch.Text);
                });

            btnFindSupplier.MarkFree(image, color);

            if (suppliers != null && suppliers.Count > 0)
            {
                var searchView = new SearchView<Supplier>("Supplier", suppliers, new List<DGColumn> {
                    new DGColumn("Id",0,50),
                    new DGColumn("Name",1,200),
                    new DGColumn("Company",2,150),
                    new DGColumn("Phone",3,150)
                });
                var result = searchView.ShowDialog(this);
                if (result == DialogResult.OK) {
                    Entity.Supplier = suppliers.Find(x => x.Id == searchView.SelectedEntityId);
                    BindSupplier();
                    txtSupplierSearch.Clear();
                    txtCodeSearch.Focus();
                }
            }
            else
            {
                Message.Stop("No supplier(s) found.");
                //txtSupplierSearch.SelectAll();
                txtSupplierSearch.Focus();
            }

            //InvalidateFinishButton()
        }

        private async void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            if (btnAddSupplier.IsBusy()) return;
            btnAddSupplier.MarkBusy(out Image image, out Color color);
            var adapter = await Adapter.CreateInstance();
            btnAddSupplier.MarkFree(image, color);
            if (adapter == null) return;
            new SupplierEditView(adapter, 0, this);

        }

        private async void btnAddItem_Click(object sender, EventArgs e)
        {
            if (btnAddItem.IsBusy()) return;
            btnAddItem.MarkBusy(out Image image, out Color color);
            var adapter = await Adapter.CreateInstance();
            btnAddItem.MarkFree(image, color);
            if (adapter == null) return;
            new ItemEditView(adapter, 0, this);


        }

        private async void BtnFindItem_Click(object sender, EventArgs e)
        {
            if (btnFindItem.IsBusy()) return;
            if (string.IsNullOrWhiteSpace(txtItemSearch.Text)) return;
            btnFindItem.MarkBusy(out Image image, out Color color);
            var items = (await Adapter.Retrive<Item>(withRelatedData: true))?.ToList()
                .FindAll(x => {
                    return
                    XString.Equal(x.Code, txtItemSearch.Text) ||
                    XString.Contains(x.Name, txtItemSearch.Text) ||
                    XString.Contains(x.Brand, txtItemSearch.Text) ||
                    XString.Contains(x.Category, txtItemSearch.Text);
                });

            btnFindItem.MarkFree(image, color);

            if (items != null && items.Count > 0)
            {
                var searchView = new SearchView<Item>("Item", items, new List<DGColumn> {
                    new DGColumn("Id",0,50),
                    new DGColumn("Code",1,150),
                    new DGColumn("Name",2,200),
                    new DGColumn("Brand",3,150),
                    new DGColumn("Category",4,150)
                });
                var result = searchView.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    currentPurchaseItem = new PurchaseItem { Item = items.Find(x => x.Id == searchView.SelectedEntityId) };
                    BindPurchaseItem();
                    txtItemSearch.Clear();
                    if (currentPurchaseItem.Item.HasUID)
                    {
                        txtSerial.Enabled = true;
                        txtSerial.Focus();
                    }
                    else
                    {
                        txtSerial.Enabled = false;
                        txtSalePrice.Focus();
                    }
                }
            }
            else
            {
                Message.Stop("No item(s) found.");
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (currentPurchaseItem == null) return;
            Entity.PurchaseItems.Add(currentPurchaseItem);
            BindPurcahseItems();
            currentPurchaseItem = null;
            purchaseItemBindingSource.Clear();
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
            } else if (grid.SelectedRows.Count > 1)
            {
                btnEditRow.Enabled = false;
            }

        }

        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                var code = row.Cells["Code"].Value.ToString();
                var found = Entity.PurchaseItems?.ToList().Find(x => x.Code == code);
                if (found != null) { Entity.PurchaseItems.Remove(found); }
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
                var found = Entity.PurchaseItems?.ToList().Find(x => x.Code == code);
                if (found != null) { Entity.PurchaseItems.Remove(found); }
                currentPurchaseItem = found;
                BindPurchaseItem();
                BindPurcahseItems();
                txtQuantity.SelectAll();
                txtQuantity.Focus();

            }
        }

        //private bool IsValidForm()
        //{
        //    if (string.IsNullOrEmpty(Entity.ClientName))
        //    {
        //        Message.Warning("No Supplier is associated with this purchase.");
        //        return false;
        //    }

        //    //if (Entity.Total<=0)
        //    //{
        //    //    Message.Warning("This purchase has 0 amount bill transaction stopped.");
        //    //    return false;
        //    //}

        //    return true;
        //}

        private async void BtnFinish_Click(object sender, EventArgs e)
        {
            if (Entity.HasErrors(out string errors))
            {
                Message.Error("Please fix the following errors to continue:\n" + errors);
                return;
            }
            if (btnFinish.IsBusy()) return;
            //if(!IsValidForm()) return;
            ValidateChildren();
            btnFinish.MarkBusy(out Image image, out Color color);
            var isNew = Entity.IsNew;
            var changes = await Adapter.Save(Entity);
            MessageBox.Show("Changes = " + changes);
            btnFinish.MarkFree(image, color);
            if (changes > 0 && isNew)
            {
                new TransactionView<Purchase>(Adapter, Entity, TransactionType.Cashout, this);
            }

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
            var item = (await Adapter.Retrive<Item>(withRelatedData: true))?.ToList()
                .Find(x => XString.Equal(x.Code, txtCodeSearch.Text));

            btnFindCode.MarkFree(image, color);

            if (item != null)
            {
                currentPurchaseItem = new PurchaseItem { Item = item };
                BindPurchaseItem();
                txtSalePrice.SelectAll();
                txtSalePrice.Focus();
            }
            else
            {
                currentPurchaseItem = null;
                purchaseItemBindingSource.Clear();
                txtCodeSearch.SelectAll();
                txtCodeSearch.Focus();
            }


        }

        private void BtnTransactionInitiate_Click(object sender, EventArgs e)
        {
            new TransactionView<Purchase>(Adapter, Entity, TransactionType.Cashout, this);
            BindEntity();
            InvalidateForm();

        }

        private void BtnTransaction_Click(object sender, EventArgs e)
        {
            new TransactionsListView<Transaction>("Purchase Transactions", Resources.icons8_transaction_list_30px,
                Entity, Entity.Transactions, new List<DGColumn> {
                    new DGColumn("Date",0,100),
                    new DGColumn("TrxId",1,150),
                    new DGColumn("Amount",2,70),
                    new DGColumn("Cash",3,70),
                    new DGColumn("Return",4,70)
              }, this);
        }

        private void Panel6_Paint(object sender, PaintEventArgs e)
        {

        }



        private void BtnPrint_Click(object sender, EventArgs e)
        {
            XPrinter printer = new XPrinter(printerName: Settings.Default.ReceiptPrinter, topMargin: 10, leftMargin: 10);
            PrintReceipt(printer);

            printer.Print(this, true);
        }


        private async void BtnUpdateStock_Click(object sender, EventArgs e)
        {

            if (btnUpdateStock.IsBusy()) return;
            btnUpdateStock.MarkBusy(out Image image, out Color color);
            if (Entity.IsStockUpdateable)
            {
                var stock = new List<StockItem>();
                foreach (var purchaseItem in Entity.PurchaseItems)
                {
                    stock.Add(new StockItem { PurchaseItem = purchaseItem, Quantity = purchaseItem.Quantity, SalePrice = purchaseItem.SalePrice });
                }
                var changes = await Adapter.Save<StockItem>(stock);
                if (changes == stock.Count())
                {
                    Entity.SetUpdateStockFlag();
                    await Adapter.Save<Purchase>(Entity);
                }
            }
            btnUpdateStock.MarkFree(image, color);
            InvalidateForm();
        }

        private async void PurchaseEditView_Load(object sender, EventArgs e)
        {
            txtCodeSearch.Focus();
            await Task.Run(() => webBrowser1.Navigate(AdHandler.AdUrl));
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            XPrinter printer = new XPrinter(topMargin: 10, leftMargin: 10);
            MessageBox.Show("Strting Print...");
            PrintReceipt(printer);
            MessageBox.Show("Previewing...");

            printer.Preview(this);
        }


        private void PrintReceipt(XPrinter printer)
        {
           

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

            printer.AddString(string.Format("{0,-" + G.W(50) + "}", Entity.TradeName + " Slip"), XFont.B9, XFontColor.Black, g: graphics);
            printer.AddString(G.ULine(), XFont.B8, g: graphics);
            printer.AddVerticalSpace(graphics);
            printer.AddString(string.Format("{0,-" + G.W(50) + "}{1," + G.W(50) + "}", "Client Name", "Trade #"), XFont.B8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0,-" + G.W(50) + "}{1," + G.W(50) + "}", Entity.ClientName, Entity.TradeId), XFont.B8, g: graphics);
            printer.AddString(string.Format("{0,-" + G.W(50) + "}{1," + G.W(50) + "}", "Date", "Operator"), XFont.B8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0,-" + G.W(50) + "}{1," + G.W(50) + "}", Entity.Date, Auth.Operator()), XFont.B8, g: graphics);
            printer.AddVerticalSpace(graphics);
            printer.AddString(G.ULine(), XFont.B8, g: graphics);

            MessageBox.Show("printing purchase items...");
            if (Entity.PurchaseItems != null && Entity.PurchaseItems.Count > 0)
            {
                printer.AddVerticalSpace(graphics);
                printer.AddString(string.Format("{0,-" + G.W(50) + "}", "Items"), XFont.B8, XFontColor.Gray, g: graphics);
                string format = "{0,-" + G.W(5) + "}{1,-" + G.W(20) + "}{2,-" + G.W(30) + "}{3,-" + G.W(15) + ":C2}{4,-" + G.W(15) + ":N2}{5,-"+ G.W(15) + ":C2}";
                printer.AddString(string.Format(format, "Sr", "Name", "ID", "Price", "Qtty", "Amount"), XFont.B8, g: graphics);
                printer.AddString(G.UDotted(), XFont.B8, g: graphics);
                int sr = 1;
                foreach (var item in Entity.PurchaseItems)
                {
                    var itemName = new XFString(G.W(20), item.Name);
                    if (itemName.StringLines.Count() > 0)
                    {
                        printer.AddString(string.Format(format,
                            sr++, itemName.StringLines.ToList()[0], item.Serial, item.SalePrice, item.Quantity,  item.Amount), XFont.R8, g: graphics);
                        for (int i = 1; i < itemName.StringLines.Count(); i++)
                        {
                            printer.AddString(string.Format(format, "",
                                itemName.StringLines.ToList()[i], "", "", "", "", ""), XFont.R8, g: graphics);
                        }
                    }
                }
                printer.AddString(G.UDotted(), XFont.B8, g: graphics);
                printer.AddString(string.Format(format, "", "", "","",
                   Entity.PurchaseItems.Sum(x => x.Quantity),
                  "",
                   Entity.PurchaseItems.Sum(x => x.Amount)), XFont.B8, g: graphics);
                printer.AddString(G.UDotted(), XFont.B8, g: graphics);
                printer.AddVerticalSpace(graphics);

            }
            MessageBox.Show("Printing totals...");
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Bill Amount", "", Entity.Amount), XFont.R8, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Discount", " %" + Entity.Discount, Entity.DiscountAmount), XFont.R8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Subtotal", "", Entity.Subtotal), XFont.R8, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Tax", " %" + Entity.Tax, Entity.TaxAmount), XFont.R8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Total", "", Entity.Total), XFont.B8, g: graphics);


            if (Entity.Transactions != null && Entity.Transactions.Count > 0 && chkWithPayment.Checked)
            {
                printer.AddVerticalSpace(graphics);
                printer.AddString(string.Format("{0,-" + G.W(50) + "}", "Payment History"), XFont.B8, XFontColor.Gray, g: graphics);
                string trxformat = "{0,-" + G.W(5) + "}{1,-" + G.W(35) + "}{2,-" + G.W(25) + "}{3," + G.W(15) + "}{4," + G.W(20) + ":C2}";
                printer.AddString(string.Format(trxformat, "Sr", "TrxId", "Date", "Mode", "Amount"), XFont.B8, g: graphics);
                printer.AddString(G.UDotted(), XFont.B8, g: graphics);
                int sr = 1;
                foreach (var trx in Entity.Transactions)
                {

                    printer.AddString(string.Format(trxformat,
                        sr++, trx.TrxId, trx.Date.ToShortDateString(), trx.TransactionType.ToString(), trx.Amount), XFont.R8, g: graphics);
                }
                printer.AddVerticalSpace(graphics);

            }

            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Paid", "", Entity.Paid), XFont.R8, XFontColor.Gray, g: graphics);
            printer.AddString(string.Format("{0," + G.W(75) + "}{1," + G.W(5) + "}{2," + G.W(20) + ":C2}", "Due", "", Entity.Due), XFont.B8, g: graphics);

          
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

        private void Label20_Click(object sender, EventArgs e)
        {

        }

        private void TxtItemSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
