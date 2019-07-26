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
    public partial class TransactionView<T> : Form
    {
        private readonly Form owner;
        private readonly bool isAmountReadonly;

        public Adapter Adapter { get; }
        public Transaction Transaction { get; private set; }
        public T Trade { get; }

        public TransactionView(Adapter adapter, T Trade, TransactionType transactionType, Form owner = null, bool isAmountReadonly = false)
        {
            Adapter = adapter;
          
            this.Trade = Trade;
            this.owner = owner;
            this.isAmountReadonly = isAmountReadonly;
            InitializeComponent();
            InitializeForm(transactionType);
        }

        private void InitializeForm(TransactionType transactionType)
        {
            LoadComponents(transactionType);
        }

        private void LoadComponents(TransactionType transactionType)
        {   Transaction = new Transaction(transactionType);
         
            BindTransaction();
            InvalidateForm();
            Display();

        }

        public void BindTransaction()
        {
            BindTrade();
            var trade = Trade as ITransactionable;
            Transaction.TradeId = trade.TradeId;
            Transaction.Amount = Transaction.TransactionType == TransactionType.Refund? trade.RefundAmount : trade.Due;
            Transaction.Cash = Transaction.Amount;

            transactionBindingSource.Clear();
            transactionBindingSource.Add(Transaction);
         

        }

        public void BindTrade()
        {
            var trade = (Trade as ITransactionable);
            lblTradeType.Text = trade.TradeName;
            lblTradeReference.Text = trade.TradeId;
            lblTradeDue.Text = trade.Due.ToString().ToCurrency();
            lblClientName.Text = trade.ClientName;
            lblClientPhone.Text = trade.ClientPhone;
        }

        private void Display()
        {
            if (this.owner == null) return;
            this.ShowDialog(owner);
        }

        public void InvalidateForm()
        {
            lblTitle.Text = "          " + Transaction.TransactionType.ToString();

            if (Transaction.IsNew)
            {
                btnCancel.Visible = true;
                btnInititate.Visible = true;
                btnSuccess.Visible = false;
            }
            else
            {
                btnCancel.Visible = false;
                btnInititate.Visible = false;
                btnSuccess.Visible = true;
                btnSuccess.Focus();
            }

            txtAmount.ReadOnly = isAmountReadonly;
        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////


        private async void BtnInitiateTransaction_Click(object sender, EventArgs e)
        {
            
            if (btnInititate.IsBusy()) return;
            if(Transaction.Amount<=0 || (Transaction.Amount > (Trade as ITransactionable).Due && Transaction.TransactionType != TransactionType.Refund))
            { 
               
                    Message.Stop("Invalid transaction amount." +
                  " Amount must be greater than zero and cannot be more than due amount.");
              
                return;
            }

            if (Transaction.Amount <= 0 || (Transaction.Amount > (Trade as ITransactionable).Paid && Transaction.TransactionType == TransactionType.Refund))
            {

                Message.Stop("Invalid transaction amount." +
              " Amount must be greater than zero and cannot be more than paid amount.");

                return;
            }
            ValidateChildren();
            btnInititate.MarkBusy(out Image image, out Color color);
            (Trade as ITransactionable).Transactions.Add(Transaction);
            var op = Auth.GetOperator();
            if (op != null)
            {
                op.LastShift?.AddTransaction(Transaction);
                await Adapter.Save(op);
                (Master.Instance.OperatorView as OperatorView).RefreshBalanceSheet();
            }
            await Adapter.Save(Trade);
            btnInititate.MarkFree(image, color);
            InvalidateForm();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
           DialogResult = DialogResult.Cancel;
        }


        private void BtnSuccess_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Txtcash_Enter(object sender, EventArgs e)
        {
            txtcash.SelectAll();
        }

        private void TxtAmount_Enter(object sender, EventArgs e)
        {

        }
    }
}
