using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class TransactionsListView<T> : Form
    {
        private readonly string entityName;
        private readonly Image headImage;
        private readonly ITransactionable trade;
        private readonly IEnumerable<T> entites;
        private readonly Form owner;


        public TransactionsListView(string entityName, Image headImage,ITransactionable trade,IEnumerable<T> entites, IEnumerable<DGColumn> columns, Form owner = null)
        {
            this.entityName = entityName;
            this.headImage = headImage;
            this.trade = trade;
            this.trade = trade;
            this.entites = entites;
            this.owner = owner;

            InitializeComponent();
            InvalidateForm();
            InitializeForm(entites, columns);
        }

        public void InvalidateForm()
        {
            lblTitle.Image = headImage;
            lblTitle.Text = "          " + entityName;
        }

        private void InitializeForm(IEnumerable<T> entites, IEnumerable<DGColumn> columns)
        {
       
            LoadComponents(entites, columns);
            Display();
        }

        private void Display()
        {
            if (owner == null) return;
            this.ShowDialog(owner);
        }

        private void LoadComponents(IEnumerable<T> entites, IEnumerable<DGColumn> columns)
        {
            lblTradeId.Text = trade.TradeId;
            lblTradeType.Text = trade.TradeName;
            lblTradeTotal.Text = trade.Total.ToString().ToCurrency();
            lblTradPaid.Text = trade.Paid.ToString().ToCurrency();
            lblTradDue.Text = trade.Due.ToString().ToCurrency();
            lblDate.Text = trade.Date.ToLongDateString();

            grid.DataSource = typeof(IEnumerable<T>);
            grid.DataSource = entites.ToList() as IEnumerable<T>;
            grid.ClearSelection();
            foreach (DataGridViewColumn gridColumn in grid.Columns)
            {
                var column = columns.ToList().Find(x => x.Column == gridColumn.Name);
                if (column != null)
                {
                    gridColumn.DisplayIndex = column.DisplayIndex;
                    gridColumn.Width = column.Width;
                    gridColumn.Visible = true;
                    gridColumn.HeaderText = gridColumn.Name.ToLabel();
                }
                else
                {
                    gridColumn.Visible = false;
                }
            }

        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////
    }
}
