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
    public partial class StockView : Form
    {

        private readonly Form owner;
        private WaitWin wait;

        public Adapter Adapter { get; }
        public IEnumerable<StockItem> Entities { get;private set; }
        public StockView(Adapter adapter, Form owner = null)
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
            Entities = await Adapter.Retrive<StockItem>(withRelatedData: true);
            foreach (var stockItem in Entities)
            {
                    await Adapter.LoadRelatedData(stockItem);
                    await Adapter.LoadRelatedData(stockItem.PurchaseItem);
                    await Adapter.LoadRelatedData(stockItem.PurchaseItem.Item);
            }
        }

        public void LoadComponents(IEnumerable<StockItem> entities)
        {
            if (entities == null || entities.Count() <= 0)
            {
                return;
            }

            grid.DataSource = typeof(IEnumerable<StockItem>);
            grid.DataSource = entities.ToList() as IEnumerable<StockItem>;


            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.Visible = false;
            }

            var c0 = grid.Columns[nameof(StockItem.Code)];
            c0.Visible = true;
            c0.DisplayIndex = 0;
            c0.FillWeight = 50;

            var c1 = grid.Columns[nameof(StockItem.Name)];
            c1.Visible = true;
            c1.DisplayIndex = 1;
            c1.FillWeight = 200;

            var c2 = grid.Columns[nameof(StockItem.Brand)];
            c2.Visible = true;
            c2.DisplayIndex = 2;
            c2.FillWeight = 100;

            var c3= grid.Columns[nameof(StockItem.Serial)];
            c3.Visible = true;
            c3.DisplayIndex = 3;
            c3.FillWeight = 150;

            var c4 = grid.Columns[nameof(StockItem.Unit)];
            c4.Visible = true;
            c4.DisplayIndex = 4;
            c4.FillWeight = 100;

            var c5 = grid.Columns[nameof(StockItem.Batch)];
            c5.Visible = true;
            c5.DisplayIndex = 5;
            c5.FillWeight = 150;

            var c6 = grid.Columns[nameof(StockItem.SalePrice)];
            c6.Visible = true;
            c6.HeaderText = nameof(StockItem.SalePrice);
            c6.DisplayIndex = 6;
            c6.FillWeight = 100;

            var c7 = grid.Columns[nameof(StockItem.SalePrice)];
            c7.Visible = true;
            c7.HeaderText = nameof(StockItem.SalePrice);
            c7.DisplayIndex = 7;
            c7.FillWeight = 100;

            var c8 = grid.Columns[nameof(StockItem.Quantity)];
            c8.Visible = true;
            c8.DefaultCellStyle.Format = "0,0.00";
            c8.DisplayIndex = 8;
            c8.FillWeight = 100;

            //var c9 = grid.Columns[nameof(StockItem.Quantity)];
            //c9.Visible = true;
            //c9.DefaultCellStyle.Format = "$0,0.00";
            //c9.DisplayIndex = 9;
            //c9.FillWeight = 100;
        }
       

        private async void Button6_Click(object sender, EventArgs e)
        {
            if (btnRefresh.IsBusy()) return;
            btnRefresh.MarkBusy(out Image image, out Color color);

            Entities =
                (await Adapter.Retrive<StockItem>())?.ToList()
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

            foreach (var stockItem in Entities)
            {
                await Adapter.LoadRelatedData(stockItem);
                await Adapter.LoadRelatedData(stockItem.PurchaseItem);
                await Adapter.LoadRelatedData(stockItem.PurchaseItem.Item);
            }

            LoadComponents(Entities);
            btnRefresh.MarkFree(image, color);

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

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////
        ///
        private void PrintReport(XPrinter printer)
        {
            var graphics = this.CreateGraphics();
            printer.AddString(string.Format("{0,-" + G.RW(100) + "}", Properties.Settings.Default.BName), XFont.B12, g: graphics);

            var address = new XFString(G.RW(100), Properties.Settings.Default.BAddress);
            if (address.StringLines.Count() > 0)
            {
                printer.AddString(string.Format("{0,-" + G.RW(100) + "}", address.StringLines.ToList()[0]), XFont.R8, g: graphics);
                for (int i = 1; i < address.StringLines.Count(); i++)
                {
                    printer.AddString(string.Format("{0,-" + G.RW(100) + "}", address.StringLines.ToList()[i]), XFont.R8, g: graphics);
                }
            }
            printer.AddVerticalSpace(graphics);

            printer.AddString(string.Format("{0,-" + G.RW(50) + "}","Available Stock"), XFont.B9, XFontColor.Black, g: graphics);
            printer.AddString(G.RULine(), XFont.B8, g: graphics);
            printer.AddVerticalSpace(graphics);
     
            if (panelDates.Enabled == true)
            { 
                printer.AddString(string.Format("{0,-" + G.RW(5) + "}{1," + G.RW(15) + "}{2,-" + G.RW(5) + "}{3," + G.RW(15) + "}", 
                    "From", fromDate.Value.ToShortDateString(),
                    "To", toDate.Value.ToShortDateString()), XFont.B8, XFontColor.Gray, g: graphics);
            }
         
            printer.AddVerticalSpace(graphics);

            if (Entities != null && Entities.Count() > 0)
            {
                printer.AddVerticalSpace(graphics);
                string format = "{0,-" + G.RW(5) + "}{1,-" + G.RW(10) + "}{2,-" + G.RW(15) + "}{3,-" + G.RW(20) + "}{4,-" + G.RW(10) + "}{5,-" + G.RW(10) + "}" +
                    "{6,-" + G.RW(10) + ":C2}{7,-" + G.RW(10) + ":N2}{8,-" + G.RW(10) + ":C2}";
                printer.AddString(string.Format(format, "Sr","Code", "Name", "Serial", "Batch", "Unit", "S.Price", "Qtty", "Amount"), XFont.B8, g: graphics);
                printer.AddString(G.RUDotted(), XFont.B8, g: graphics);
                int sr = 1;
                foreach (var item in Entities)
                {
                    var itemName = new XFString(G.RW(20), item.Name);
                    if (itemName.StringLines.Count() > 0)
                    {
                        printer.AddString(string.Format(format,
                            sr++, item.Code,itemName.StringLines.ToList()[0], item.Serial, item.CreatedAt.ToShortDateString(),item.Unit,item.SalePrice, item.Quantity, item.Value), XFont.R8, g: graphics);
                        for (int i = 1; i < itemName.StringLines.Count(); i++)
                        {
                            printer.AddString(string.Format(format, "","",
                                itemName.StringLines.ToList()[i], "", "", "", "", "",""), XFont.R8, g: graphics);
                        }
                    }
                }
                printer.AddString(G.RUDotted(), XFont.B8, g: graphics);
                printer.AddString(string.Format(format, "", "", "","","","","",
                   Entities.Sum(x => x.Quantity),
                  Entities.Sum(x => x.Value)), XFont.B8, g: graphics);
                printer.AddString(G.RUDotted(), XFont.B8, g: graphics);
                printer.AddVerticalSpace(graphics);

            }

            printer.AddString(string.Format("{0,-" + G.RW(100) + "}", "Generated By : " + Auth.Operator()+ " at " + DateTime.Now.ToLongDateString()), XFont.R8, g: graphics);



        }

        private void Button4_Click(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            XPrinter printer = new XPrinter(printerName: Settings.Default.ReportPrinter, topMargin: 10, leftMargin: 10);
            PrintReport(printer);

            printer.Print(this, true);
        }

        private void TxtItemSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.ForeColor != Color.Black)
            {
                txtSearch.Clear();
                txtSearch.ForeColor = Color.Black;
            }

        }

        private void TxtItemSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length <= 0)
            {
                txtSearch.Text = "Search name, brand or category.";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private async void BtnFind_Click(object sender, EventArgs e)
        {
            if (btnFind.IsBusy()) return;
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) return;
            btnFind.MarkBusy(out Image image, out Color color);

           var entities  =  Entities?.ToList().FindAll(x =>
                {
                    var search = 
                    XString.Contains(x.Name, txtSearch.Text)
                    || XString.Contains(x.Brand, txtSearch.Text)
                    || XString.Contains(x.Category, txtSearch.Text);

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

            btnFind.MarkFree(image, color);
        }
    }
}
