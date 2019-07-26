namespace WirelessPOS {
    partial class TransactionView<T>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.transactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTradeDue = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblReturn = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblClientPhone = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTradeReference = new System.Windows.Forms.Label();
            this.lblTradeType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtcash = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInititate = new System.Windows.Forms.Button();
            this.btnSuccess = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel.Controls.Add(this.txtAmount);
            this.panel.Controls.Add(this.lblTradeDue);
            this.panel.Controls.Add(this.label23);
            this.panel.Controls.Add(this.label11);
            this.panel.Controls.Add(this.label12);
            this.panel.Controls.Add(this.lblReturn);
            this.panel.Controls.Add(this.label22);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.lblClientPhone);
            this.panel.Controls.Add(this.lblClientName);
            this.panel.Controls.Add(this.label16);
            this.panel.Controls.Add(this.label17);
            this.panel.Controls.Add(this.label9);
            this.panel.Controls.Add(this.lblTradeReference);
            this.panel.Controls.Add(this.lblTradeType);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.label18);
            this.panel.Controls.Add(this.label19);
            this.panel.Controls.Add(this.txtcash);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label20);
            this.panel.Controls.Add(this.label10);
            this.panel.Controls.Add(this.btnCancel);
            this.panel.Controls.Add(this.lblTitle);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.btnInititate);
            this.panel.Controls.Add(this.btnSuccess);
            this.panel.Controls.Add(this.label13);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(10, 10);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(1);
            this.panel.Size = new System.Drawing.Size(466, 390);
            this.panel.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.BackColor = System.Drawing.Color.Honeydew;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionBindingSource, "Amount", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.txtAmount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(210, 262);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(246, 16);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Text = "$0.00";
            this.txtAmount.Enter += new System.EventHandler(this.TxtAmount_Enter);
            // 
            // transactionBindingSource
            // 
            this.transactionBindingSource.DataSource = typeof(WPos.Domain.Transaction);
            // 
            // lblTradeDue
            // 
            this.lblTradeDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTradeDue.BackColor = System.Drawing.Color.SeaShell;
            this.lblTradeDue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTradeDue.Location = new System.Drawing.Point(203, 102);
            this.lblTradeDue.Margin = new System.Windows.Forms.Padding(0);
            this.lblTradeDue.Name = "lblTradeDue";
            this.lblTradeDue.Padding = new System.Windows.Forms.Padding(5);
            this.lblTradeDue.Size = new System.Drawing.Size(262, 30);
            this.lblTradeDue.TabIndex = 62;
            this.lblTradeDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.BackColor = System.Drawing.Color.SeaShell;
            this.label23.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(106, 102);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Padding = new System.Windows.Forms.Padding(5);
            this.label23.Size = new System.Drawing.Size(96, 30);
            this.label23.TabIndex = 61;
            this.label23.Text = "Due";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Image = global::WirelessPOS.Properties.Resources.icons8_calendar_20px;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(106, 224);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5);
            this.label11.Size = new System.Drawing.Size(96, 30);
            this.label11.TabIndex = 60;
            this.label11.Text = "Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label12.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionBindingSource, "Date", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "F"));
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.label12.Location = new System.Drawing.Point(203, 224);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(5);
            this.label12.Size = new System.Drawing.Size(262, 30);
            this.label12.TabIndex = 59;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReturn
            // 
            this.lblReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblReturn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionBindingSource, "Return", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.lblReturn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturn.Location = new System.Drawing.Point(203, 316);
            this.lblReturn.Margin = new System.Windows.Forms.Padding(0);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Padding = new System.Windows.Forms.Padding(5);
            this.lblReturn.Size = new System.Drawing.Size(262, 30);
            this.lblReturn.TabIndex = 58;
            this.lblReturn.Text = "$0.00";
            this.lblReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Image = global::WirelessPOS.Properties.Resources.icons8_us_dollar_20px_4;
            this.label22.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label22.Location = new System.Drawing.Point(106, 317);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(5);
            this.label22.Size = new System.Drawing.Size(96, 30);
            this.label22.TabIndex = 57;
            this.label22.Text = "Return";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Image = global::WirelessPOS.Properties.Resources.icons8_barcode_20px;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(106, 194);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(96, 30);
            this.label2.TabIndex = 56;
            this.label2.Text = "Id";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClientPhone
            // 
            this.lblClientPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblClientPhone.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblClientPhone.Location = new System.Drawing.Point(203, 163);
            this.lblClientPhone.Margin = new System.Windows.Forms.Padding(0);
            this.lblClientPhone.Name = "lblClientPhone";
            this.lblClientPhone.Padding = new System.Windows.Forms.Padding(5);
            this.lblClientPhone.Size = new System.Drawing.Size(262, 30);
            this.lblClientPhone.TabIndex = 55;
            this.lblClientPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClientName
            // 
            this.lblClientName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblClientName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblClientName.Location = new System.Drawing.Point(203, 133);
            this.lblClientName.Margin = new System.Windows.Forms.Padding(0);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Padding = new System.Windows.Forms.Padding(5);
            this.lblClientName.Size = new System.Drawing.Size(262, 30);
            this.lblClientName.TabIndex = 54;
            this.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Image = global::WirelessPOS.Properties.Resources.icons8_phone_20px;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label16.Location = new System.Drawing.Point(106, 163);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(5);
            this.label16.Size = new System.Drawing.Size(96, 30);
            this.label16.TabIndex = 53;
            this.label16.Text = "Phone";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Image = global::WirelessPOS.Properties.Resources.icons8_user_20px;
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label17.Location = new System.Drawing.Point(106, 133);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(5);
            this.label17.Size = new System.Drawing.Size(96, 30);
            this.label17.TabIndex = 52;
            this.label17.Text = "Name";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label9.Location = new System.Drawing.Point(1, 133);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 7, 5, 5);
            this.label9.Size = new System.Drawing.Size(104, 60);
            this.label9.TabIndex = 51;
            this.label9.Text = "Client";
            // 
            // lblTradeReference
            // 
            this.lblTradeReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTradeReference.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblTradeReference.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTradeReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblTradeReference.Location = new System.Drawing.Point(203, 71);
            this.lblTradeReference.Margin = new System.Windows.Forms.Padding(0);
            this.lblTradeReference.Name = "lblTradeReference";
            this.lblTradeReference.Padding = new System.Windows.Forms.Padding(5);
            this.lblTradeReference.Size = new System.Drawing.Size(262, 30);
            this.lblTradeReference.TabIndex = 50;
            this.lblTradeReference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTradeType
            // 
            this.lblTradeType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTradeType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblTradeType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTradeType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblTradeType.Location = new System.Drawing.Point(203, 41);
            this.lblTradeType.Margin = new System.Windows.Forms.Padding(0);
            this.lblTradeType.Name = "lblTradeType";
            this.lblTradeType.Padding = new System.Windows.Forms.Padding(5);
            this.lblTradeType.Size = new System.Drawing.Size(262, 30);
            this.lblTradeType.TabIndex = 49;
            this.lblTradeType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(106, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(96, 30);
            this.label4.TabIndex = 48;
            this.label4.Text = "Reference";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(106, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(96, 30);
            this.label3.TabIndex = 47;
            this.label3.Text = "Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label6.Location = new System.Drawing.Point(1, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 7, 5, 5);
            this.label6.Size = new System.Drawing.Size(104, 91);
            this.label6.TabIndex = 46;
            this.label6.Text = "Trade";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.Color.Honeydew;
            this.label18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(203, 255);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label18.Size = new System.Drawing.Size(262, 30);
            this.label18.TabIndex = 45;
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.Color.Honeydew;
            this.label19.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Image = global::WirelessPOS.Properties.Resources.icons8_cash__20px;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Location = new System.Drawing.Point(106, 255);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(5);
            this.label19.Size = new System.Drawing.Size(96, 30);
            this.label19.TabIndex = 44;
            this.label19.Text = "Amount";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcash
            // 
            this.txtcash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcash.BackColor = System.Drawing.Color.White;
            this.txtcash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcash.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionBindingSource, "Cash", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.txtcash.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcash.Location = new System.Drawing.Point(210, 294);
            this.txtcash.Name = "txtcash";
            this.txtcash.Size = new System.Drawing.Size(246, 16);
            this.txtcash.TabIndex = 1;
            this.txtcash.Text = "$0.00";
            this.txtcash.Enter += new System.EventHandler(this.Txtcash_Enter);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(203, 286);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(262, 30);
            this.label5.TabIndex = 43;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Image = global::WirelessPOS.Properties.Resources.icons8_cash_in_hand_20px;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label20.Location = new System.Drawing.Point(106, 286);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(5);
            this.label20.Size = new System.Drawing.Size(96, 30);
            this.label20.TabIndex = 41;
            this.label20.Text = "Cash";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transactionBindingSource, "TrxId", true));
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.label10.Location = new System.Drawing.Point(203, 194);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5);
            this.label10.Size = new System.Drawing.Size(262, 30);
            this.label10.TabIndex = 28;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Image = global::WirelessPOS.Properties.Resources.icons8_delete_sign_17px;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(313, 352);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitle.Image = global::WirelessPOS.Properties.Resources.icons8_cashflow_25px_2;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(1, 1);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblTitle.Size = new System.Drawing.Size(464, 40);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "          Transaction";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(1, 194);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 7, 5, 5);
            this.label1.Size = new System.Drawing.Size(104, 153);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction";
            // 
            // btnInititate
            // 
            this.btnInititate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInititate.AutoSize = true;
            this.btnInititate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInititate.ForeColor = System.Drawing.Color.Black;
            this.btnInititate.Image = global::WirelessPOS.Properties.Resources.icons8_submit_progress_17px;
            this.btnInititate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInititate.Location = new System.Drawing.Point(385, 352);
            this.btnInititate.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.btnInititate.Name = "btnInititate";
            this.btnInititate.Size = new System.Drawing.Size(75, 30);
            this.btnInititate.TabIndex = 2;
            this.btnInititate.Text = "Initiate";
            this.btnInititate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInititate.UseVisualStyleBackColor = true;
            this.btnInititate.Click += new System.EventHandler(this.BtnInitiateTransaction_Click);
            // 
            // btnSuccess
            // 
            this.btnSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuccess.AutoSize = true;
            this.btnSuccess.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuccess.Image = global::WirelessPOS.Properties.Resources.icons8_ok_17px;
            this.btnSuccess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuccess.Location = new System.Drawing.Point(386, 352);
            this.btnSuccess.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.btnSuccess.Name = "btnSuccess";
            this.btnSuccess.Size = new System.Drawing.Size(75, 30);
            this.btnSuccess.TabIndex = 63;
            this.btnSuccess.Text = "Success";
            this.btnSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuccess.UseVisualStyleBackColor = true;
            this.btnSuccess.Click += new System.EventHandler(this.BtnSuccess_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1, 348);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(5);
            this.label13.Size = new System.Drawing.Size(464, 40);
            this.label13.TabIndex = 18;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TransactionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(486, 410);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TransactionView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInititate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtcash;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblClientPhone;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTradeReference;
        private System.Windows.Forms.Label lblTradeType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTradeDue;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSuccess;
        private System.Windows.Forms.BindingSource transactionBindingSource;
    }
}