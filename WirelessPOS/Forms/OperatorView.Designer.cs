using System.Threading;
using System.Windows.Forms;
using System;
using System.IO;

namespace WirelessPOS
{
    partial class OperatorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTradeSearch = new System.Windows.Forms.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.lblClosing = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblCashout = new System.Windows.Forms.Label();
            this.lblOpening = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblCashin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.iTransactionableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnFindTrade = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.operatorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPendingPayments = new System.Windows.Forms.Button();
            this.btnExpiredLayaways = new System.Windows.Forms.Button();
            this.btnPendingRepairs = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTransactionableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel.Controls.Add(this.panel2);
            this.panel.Controls.Add(this.panel1);
            this.panel.Controls.Add(this.lblTitle);
            this.panel.Location = new System.Drawing.Point(10, 10);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(1);
            this.panel.Size = new System.Drawing.Size(1067, 605);
            this.panel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Location = new System.Drawing.Point(1, 41);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1065, 180);
            this.panel2.TabIndex = 47;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(211, 9);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(1);
            this.panel7.Size = new System.Drawing.Size(371, 38);
            this.panel7.TabIndex = 117;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Location = new System.Drawing.Point(589, 51);
            this.panel5.Margin = new System.Windows.Forms.Padding(5);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(1);
            this.panel5.Size = new System.Drawing.Size(465, 117);
            this.panel5.TabIndex = 134;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iTransactionableBindingSource, "Due", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(233, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(231, 15);
            this.label3.TabIndex = 132;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(233, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(231, 15);
            this.label4.TabIndex = 131;
            this.label4.Text = "Due";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iTransactionableBindingSource, "Paid", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(233, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(231, 15);
            this.label9.TabIndex = 130;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(233, 42);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(231, 15);
            this.label10.TabIndex = 129;
            this.label10.Text = "Paid";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iTransactionableBindingSource, "Total", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(233, 22);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label11.Size = new System.Drawing.Size(231, 15);
            this.label11.TabIndex = 128;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Location = new System.Drawing.Point(233, 7);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label12.Size = new System.Drawing.Size(231, 15);
            this.label12.TabIndex = 127;
            this.label12.Text = "Total";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(233, 1);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(5);
            this.label13.Size = new System.Drawing.Size(231, 115);
            this.label13.TabIndex = 126;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iTransactionableBindingSource, "Date", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "G"));
            this.label14.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Location = new System.Drawing.Point(1, 92);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label14.Size = new System.Drawing.Size(231, 15);
            this.label14.TabIndex = 125;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Location = new System.Drawing.Point(1, 77);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label15.Size = new System.Drawing.Size(231, 15);
            this.label15.TabIndex = 124;
            this.label15.Text = "Date";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label16.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iTransactionableBindingSource, "ClientName", true));
            this.label16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label16.Location = new System.Drawing.Point(1, 57);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label16.Size = new System.Drawing.Size(231, 15);
            this.label16.TabIndex = 123;
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.Location = new System.Drawing.Point(1, 42);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label17.Size = new System.Drawing.Size(231, 15);
            this.label17.TabIndex = 122;
            this.label17.Text = "Client";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label18.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iTransactionableBindingSource, "TradeName", true));
            this.label18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label18.Location = new System.Drawing.Point(1, 22);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label18.Size = new System.Drawing.Size(231, 15);
            this.label18.TabIndex = 121;
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label19.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DimGray;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Location = new System.Drawing.Point(1, 7);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label19.Size = new System.Drawing.Size(231, 15);
            this.label19.TabIndex = 120;
            this.label19.Text = "Trade";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Location = new System.Drawing.Point(1, 1);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(5);
            this.label21.Size = new System.Drawing.Size(231, 115);
            this.label21.TabIndex = 113;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnFindTrade);
            this.panel3.Controls.Add(this.txtTradeSearch);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Location = new System.Drawing.Point(589, 9);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1);
            this.panel3.Size = new System.Drawing.Size(465, 38);
            this.panel3.TabIndex = 1;
            // 
            // txtTradeSearch
            // 
            this.txtTradeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTradeSearch.BackColor = System.Drawing.Color.White;
            this.txtTradeSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTradeSearch.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTradeSearch.ForeColor = System.Drawing.Color.Black;
            this.txtTradeSearch.Location = new System.Drawing.Point(119, 9);
            this.txtTradeSearch.Mask = "0-99999-99999";
            this.txtTradeSearch.Name = "txtTradeSearch";
            this.txtTradeSearch.Size = new System.Drawing.Size(104, 19);
            this.txtTradeSearch.TabIndex = 114;
            this.txtTradeSearch.Enter += new System.EventHandler(this.TxtItemSearch_Enter);
            this.txtTradeSearch.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TxtTradeSearch_PreviewKeyDown);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(111, 1);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(5);
            this.label20.Size = new System.Drawing.Size(280, 36);
            this.label20.TabIndex = 116;
            this.label20.Text = "Search Trade ID";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel6.Controls.Add(this.button5);
            this.panel6.Controls.Add(this.label22);
            this.panel6.Controls.Add(this.label30);
            this.panel6.Controls.Add(this.label31);
            this.panel6.Controls.Add(this.label32);
            this.panel6.Controls.Add(this.label33);
            this.panel6.Controls.Add(this.label34);
            this.panel6.Controls.Add(this.label35);
            this.panel6.Controls.Add(this.label29);
            this.panel6.Location = new System.Drawing.Point(10, 9);
            this.panel6.Margin = new System.Windows.Forms.Padding(5);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(1);
            this.panel6.Size = new System.Drawing.Size(194, 158);
            this.panel6.TabIndex = 133;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label22.Location = new System.Drawing.Point(1, 1);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(5);
            this.label22.Size = new System.Drawing.Size(192, 39);
            this.label22.TabIndex = 120;
            this.label22.Text = "Operator";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label30.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operatorBindingSource, "Role", true));
            this.label30.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label30.Location = new System.Drawing.Point(2, 133);
            this.label30.Margin = new System.Windows.Forms.Padding(0);
            this.label30.Name = "label30";
            this.label30.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label30.Size = new System.Drawing.Size(148, 15);
            this.label30.TabIndex = 125;
            this.label30.Text = "Purchase";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label31.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.DimGray;
            this.label31.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label31.Location = new System.Drawing.Point(2, 118);
            this.label31.Margin = new System.Windows.Forms.Padding(0);
            this.label31.Name = "label31";
            this.label31.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label31.Size = new System.Drawing.Size(148, 15);
            this.label31.TabIndex = 124;
            this.label31.Text = "Role";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label32.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operatorBindingSource, "User", true));
            this.label32.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label32.Location = new System.Drawing.Point(2, 98);
            this.label32.Margin = new System.Windows.Forms.Padding(0);
            this.label32.Name = "label32";
            this.label32.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label32.Size = new System.Drawing.Size(148, 15);
            this.label32.TabIndex = 123;
            this.label32.Text = "Purchase";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label33.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.DimGray;
            this.label33.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label33.Location = new System.Drawing.Point(2, 83);
            this.label33.Margin = new System.Windows.Forms.Padding(0);
            this.label33.Name = "label33";
            this.label33.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label33.Size = new System.Drawing.Size(148, 15);
            this.label33.TabIndex = 122;
            this.label33.Text = "Name";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label34.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operatorBindingSource, "Id", true));
            this.label34.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label34.Location = new System.Drawing.Point(2, 63);
            this.label34.Margin = new System.Windows.Forms.Padding(0);
            this.label34.Name = "label34";
            this.label34.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label34.Size = new System.Drawing.Size(148, 15);
            this.label34.TabIndex = 121;
            this.label34.Text = "Purchase";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label35.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.DimGray;
            this.label35.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label35.Location = new System.Drawing.Point(2, 48);
            this.label35.Margin = new System.Windows.Forms.Padding(0);
            this.label35.Name = "label35";
            this.label35.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label35.Size = new System.Drawing.Size(148, 15);
            this.label35.TabIndex = 120;
            this.label35.Text = "Id";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label29.Location = new System.Drawing.Point(1, 41);
            this.label29.Margin = new System.Windows.Forms.Padding(0);
            this.label29.Name = "label29";
            this.label29.Padding = new System.Windows.Forms.Padding(5);
            this.label29.Size = new System.Drawing.Size(192, 116);
            this.label29.TabIndex = 126;
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel8.Controls.Add(this.btnPendingPayments);
            this.panel8.Controls.Add(this.btnExpiredLayaways);
            this.panel8.Controls.Add(this.btnPendingRepairs);
            this.panel8.Controls.Add(this.label45);
            this.panel8.Location = new System.Drawing.Point(211, 51);
            this.panel8.Margin = new System.Windows.Forms.Padding(5);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(1);
            this.panel8.Size = new System.Drawing.Size(370, 116);
            this.panel8.TabIndex = 135;
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label45.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label45.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label45.Location = new System.Drawing.Point(1, 1);
            this.label45.Margin = new System.Windows.Forms.Padding(0);
            this.label45.Name = "label45";
            this.label45.Padding = new System.Windows.Forms.Padding(5);
            this.label45.Size = new System.Drawing.Size(368, 114);
            this.label45.TabIndex = 113;
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(1, 218);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1065, 386);
            this.panel1.TabIndex = 46;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Controls.Add(this.button17);
            this.panel4.Controls.Add(this.button16);
            this.panel4.Controls.Add(this.button15);
            this.panel4.Controls.Add(this.button14);
            this.panel4.Controls.Add(this.button13);
            this.panel4.Controls.Add(this.button12);
            this.panel4.Controls.Add(this.button11);
            this.panel4.Controls.Add(this.button10);
            this.panel4.Controls.Add(this.button9);
            this.panel4.Controls.Add(this.button8);
            this.panel4.Controls.Add(this.button7);
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.lblClosing);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.lblCashout);
            this.panel4.Controls.Add(this.lblOpening);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.lblCashin);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.grid);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(1);
            this.panel4.Size = new System.Drawing.Size(1045, 366);
            this.panel4.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label24.Location = new System.Drawing.Point(1, 1);
            this.label24.Margin = new System.Windows.Forms.Padding(0);
            this.label24.Name = "label24";
            this.label24.Padding = new System.Windows.Forms.Padding(5);
            this.label24.Size = new System.Drawing.Size(432, 364);
            this.label24.TabIndex = 129;
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label24.Click += new System.EventHandler(this.Label24_Click);
            // 
            // lblClosing
            // 
            this.lblClosing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClosing.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblClosing.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblClosing.Location = new System.Drawing.Point(557, 335);
            this.lblClosing.Margin = new System.Windows.Forms.Padding(0);
            this.lblClosing.Name = "lblClosing";
            this.lblClosing.Padding = new System.Windows.Forms.Padding(5);
            this.lblClosing.Size = new System.Drawing.Size(229, 30);
            this.lblClosing.TabIndex = 125;
            this.lblClosing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label25.Location = new System.Drawing.Point(787, 242);
            this.label25.Margin = new System.Windows.Forms.Padding(0);
            this.label25.Name = "label25";
            this.label25.Padding = new System.Windows.Forms.Padding(5);
            this.label25.Size = new System.Drawing.Size(257, 123);
            this.label25.TabIndex = 124;
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCashout
            // 
            this.lblCashout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashout.BackColor = System.Drawing.Color.White;
            this.lblCashout.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashout.ForeColor = System.Drawing.Color.Black;
            this.lblCashout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCashout.Location = new System.Drawing.Point(558, 304);
            this.lblCashout.Margin = new System.Windows.Forms.Padding(0);
            this.lblCashout.Name = "lblCashout";
            this.lblCashout.Padding = new System.Windows.Forms.Padding(5);
            this.lblCashout.Size = new System.Drawing.Size(228, 30);
            this.lblCashout.TabIndex = 123;
            this.lblCashout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOpening
            // 
            this.lblOpening.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOpening.BackColor = System.Drawing.Color.White;
            this.lblOpening.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpening.ForeColor = System.Drawing.Color.Black;
            this.lblOpening.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOpening.Location = new System.Drawing.Point(558, 242);
            this.lblOpening.Margin = new System.Windows.Forms.Padding(0);
            this.lblOpening.Name = "lblOpening";
            this.lblOpening.Padding = new System.Windows.Forms.Padding(5);
            this.lblOpening.Size = new System.Drawing.Size(228, 30);
            this.lblOpening.TabIndex = 122;
            this.lblOpening.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label23.Location = new System.Drawing.Point(434, 242);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Padding = new System.Windows.Forms.Padding(5);
            this.label23.Size = new System.Drawing.Size(123, 30);
            this.label23.TabIndex = 121;
            this.label23.Text = "Opening Balance";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCashin
            // 
            this.lblCashin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashin.BackColor = System.Drawing.Color.White;
            this.lblCashin.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashin.ForeColor = System.Drawing.Color.Black;
            this.lblCashin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCashin.Location = new System.Drawing.Point(558, 273);
            this.lblCashin.Margin = new System.Windows.Forms.Padding(0);
            this.lblCashin.Name = "lblCashin";
            this.lblCashin.Padding = new System.Windows.Forms.Padding(5);
            this.lblCashin.Size = new System.Drawing.Size(228, 30);
            this.lblCashin.TabIndex = 120;
            this.lblCashin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(434, 335);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(5);
            this.label8.Size = new System.Drawing.Size(352, 30);
            this.label8.TabIndex = 119;
            this.label8.Text = "Closing Balance";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(434, 304);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5);
            this.label7.Size = new System.Drawing.Size(123, 30);
            this.label7.TabIndex = 118;
            this.label7.Text = "Cash Out";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(434, 273);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(123, 30);
            this.label5.TabIndex = 117;
            this.label5.Text = "Cash In";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.ColumnHeadersHeight = 30;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.grid.Location = new System.Drawing.Point(433, 31);
            this.grid.Margin = new System.Windows.Forms.Padding(0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grid.RowTemplate.Height = 30;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(612, 211);
            this.grid.TabIndex = 46;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Sr";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Trade";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "TID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Amount";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Mode";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(434, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5);
            this.label6.Size = new System.Drawing.Size(610, 30);
            this.label6.TabIndex = 116;
            this.label6.Text = "Transactions";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::WirelessPOS.Properties.Resources.icons8_view_details_20px;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 70;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Image = global::WirelessPOS.Properties.Resources.icons8_notification_center_25px;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(369, 36);
            this.label1.TabIndex = 116;
            this.label1.Text = "         Notification Center";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iTransactionableBindingSource
            // 
            this.iTransactionableBindingSource.DataSource = typeof(WPos.Domain.ITransactionable);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::WirelessPOS.Properties.Resources.icons8_view_details_25px;
            this.button1.Location = new System.Drawing.Point(428, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 36);
            this.button1.TabIndex = 22;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnFindTrade
            // 
            this.btnFindTrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindTrade.AutoSize = true;
            this.btnFindTrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.btnFindTrade.FlatAppearance.BorderSize = 0;
            this.btnFindTrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindTrade.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindTrade.Image = global::WirelessPOS.Properties.Resources.icons8_search_25px;
            this.btnFindTrade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindTrade.Location = new System.Drawing.Point(391, 1);
            this.btnFindTrade.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.btnFindTrade.Name = "btnFindTrade";
            this.btnFindTrade.Size = new System.Drawing.Size(36, 36);
            this.btnFindTrade.TabIndex = 115;
            this.btnFindTrade.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFindTrade.UseVisualStyleBackColor = false;
            this.btnFindTrade.Click += new System.EventHandler(this.btnFindTrade_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::WirelessPOS.Properties.Resources.icons8_print_25px;
            this.button2.Location = new System.Drawing.Point(1, 1);
            this.button2.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 36);
            this.button2.TabIndex = 23;
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Enabled = false;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::WirelessPOS.Properties.Resources.icons8_export_pdf_25px;
            this.button4.Location = new System.Drawing.Point(38, 1);
            this.button4.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 36);
            this.button4.TabIndex = 103;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::WirelessPOS.Properties.Resources.icons8_clear_symbol_25px;
            this.button3.Location = new System.Drawing.Point(75, 1);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 36);
            this.button3.TabIndex = 104;
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.AutoSize = true;
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::WirelessPOS.Properties.Resources.icons8_import_25px;
            this.button5.Location = new System.Drawing.Point(157, 2);
            this.button5.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(36, 36);
            this.button5.TabIndex = 117;
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // operatorBindingSource
            // 
            this.operatorBindingSource.DataSource = typeof(WPos.Domain.Operator);
            // 
            // btnPendingPayments
            // 
            this.btnPendingPayments.BackColor = System.Drawing.Color.White;
            this.btnPendingPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPendingPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendingPayments.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingPayments.ForeColor = System.Drawing.Color.DimGray;
            this.btnPendingPayments.Image = global::WirelessPOS.Properties.Resources.icons8_bank_20px;
            this.btnPendingPayments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPendingPayments.Location = new System.Drawing.Point(21, 42);
            this.btnPendingPayments.Margin = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.btnPendingPayments.Name = "btnPendingPayments";
            this.btnPendingPayments.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnPendingPayments.Size = new System.Drawing.Size(333, 30);
            this.btnPendingPayments.TabIndex = 144;
            this.btnPendingPayments.Text = "999 Pending Payments";
            this.btnPendingPayments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPendingPayments.UseVisualStyleBackColor = false;
            this.btnPendingPayments.Click += new System.EventHandler(this.BtnPendingPayments_Click);
            // 
            // btnExpiredLayaways
            // 
            this.btnExpiredLayaways.BackColor = System.Drawing.Color.White;
            this.btnExpiredLayaways.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpiredLayaways.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpiredLayaways.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpiredLayaways.ForeColor = System.Drawing.Color.DimGray;
            this.btnExpiredLayaways.Image = global::WirelessPOS.Properties.Resources.icons8_merchant_account_20px;
            this.btnExpiredLayaways.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpiredLayaways.Location = new System.Drawing.Point(21, 76);
            this.btnExpiredLayaways.Margin = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.btnExpiredLayaways.Name = "btnExpiredLayaways";
            this.btnExpiredLayaways.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnExpiredLayaways.Size = new System.Drawing.Size(333, 30);
            this.btnExpiredLayaways.TabIndex = 143;
            this.btnExpiredLayaways.Text = "999 Expired Layaways";
            this.btnExpiredLayaways.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExpiredLayaways.UseVisualStyleBackColor = false;
            this.btnExpiredLayaways.Click += new System.EventHandler(this.BtnExpiredLayaways_Click);
            // 
            // btnPendingRepairs
            // 
            this.btnPendingRepairs.BackColor = System.Drawing.Color.White;
            this.btnPendingRepairs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPendingRepairs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendingRepairs.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingRepairs.ForeColor = System.Drawing.Color.DimGray;
            this.btnPendingRepairs.Image = global::WirelessPOS.Properties.Resources.icons8_maintenance_20px;
            this.btnPendingRepairs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPendingRepairs.Location = new System.Drawing.Point(21, 7);
            this.btnPendingRepairs.Margin = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.btnPendingRepairs.Name = "btnPendingRepairs";
            this.btnPendingRepairs.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnPendingRepairs.Size = new System.Drawing.Size(333, 30);
            this.btnPendingRepairs.TabIndex = 142;
            this.btnPendingRepairs.Text = "999 Pending Repairs";
            this.btnPendingRepairs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPendingRepairs.UseVisualStyleBackColor = false;
            this.btnPendingRepairs.Click += new System.EventHandler(this.BtnPendingRepairs_Click);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Image = global::WirelessPOS.Properties.Resources.icons8_user_30px_1;
            this.button17.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button17.Location = new System.Drawing.Point(154, 293);
            this.button17.Margin = new System.Windows.Forms.Padding(15, 0, 0, 15);
            this.button17.Name = "button17";
            this.button17.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button17.Size = new System.Drawing.Size(127, 57);
            this.button17.TabIndex = 141;
            this.button17.Text = "Customers";
            this.button17.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.Button17_Click);
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Image = global::WirelessPOS.Properties.Resources.icons8_cashflow_30px;
            this.button16.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button16.Location = new System.Drawing.Point(84, 293);
            this.button16.Margin = new System.Windows.Forms.Padding(15, 0, 0, 15);
            this.button16.Name = "button16";
            this.button16.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button16.Size = new System.Drawing.Size(57, 57);
            this.button16.TabIndex = 140;
            this.button16.Text = "Trades";
            this.button16.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Button16_Click);
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Image = global::WirelessPOS.Properties.Resources.icons8_stocks_30px;
            this.button15.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button15.Location = new System.Drawing.Point(16, 293);
            this.button15.Margin = new System.Windows.Forms.Padding(15, 0, 0, 15);
            this.button15.Name = "button15";
            this.button15.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button15.Size = new System.Drawing.Size(57, 57);
            this.button15.TabIndex = 139;
            this.button15.Text = "Stock";
            this.button15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Button15_Click);
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Image = global::WirelessPOS.Properties.Resources.icons8_buy_30px;
            this.button14.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button14.Location = new System.Drawing.Point(14, 88);
            this.button14.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.button14.Name = "button14";
            this.button14.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button14.Size = new System.Drawing.Size(127, 57);
            this.button14.TabIndex = 138;
            this.button14.Text = "Purchase";
            this.button14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Button14_Click);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Image = global::WirelessPOS.Properties.Resources.icons8_verified_account_30px;
            this.button13.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button13.Location = new System.Drawing.Point(154, 88);
            this.button13.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.button13.Name = "button13";
            this.button13.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button13.Size = new System.Drawing.Size(127, 57);
            this.button13.TabIndex = 137;
            this.button13.Text = "New Activation";
            this.button13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Button13_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Image = global::WirelessPOS.Properties.Resources.icons8_ringer_volume_30px;
            this.button12.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button12.Location = new System.Drawing.Point(294, 88);
            this.button12.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.button12.Name = "button12";
            this.button12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button12.Size = new System.Drawing.Size(127, 57);
            this.button12.TabIndex = 136;
            this.button12.Text = "Calling Card";
            this.button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button12_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Image = global::WirelessPOS.Properties.Resources.icons8_unlock_30px;
            this.button11.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button11.Location = new System.Drawing.Point(364, 16);
            this.button11.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.button11.Name = "button11";
            this.button11.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button11.Size = new System.Drawing.Size(57, 57);
            this.button11.TabIndex = 135;
            this.button11.Text = "Unlock";
            this.button11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Image = global::WirelessPOS.Properties.Resources.icons8_merchant_account_30px;
            this.button10.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button10.Location = new System.Drawing.Point(294, 16);
            this.button10.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.button10.Name = "button10";
            this.button10.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button10.Size = new System.Drawing.Size(57, 57);
            this.button10.TabIndex = 134;
            this.button10.Text = "Layaway";
            this.button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Image = global::WirelessPOS.Properties.Resources.icons8_bank_30px;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button9.Location = new System.Drawing.Point(224, 15);
            this.button9.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.button9.Name = "button9";
            this.button9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button9.Size = new System.Drawing.Size(57, 57);
            this.button9.TabIndex = 133;
            this.button9.Text = "Payment";
            this.button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Image = global::WirelessPOS.Properties.Resources.icons8_cellular_network_30px;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button8.Location = new System.Drawing.Point(154, 16);
            this.button8.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button8.Size = new System.Drawing.Size(57, 57);
            this.button8.TabIndex = 132;
            this.button8.Text = "Portin";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = global::WirelessPOS.Properties.Resources.icons8_maintenance_30px;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button7.Location = new System.Drawing.Point(84, 16);
            this.button7.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button7.Size = new System.Drawing.Size(57, 57);
            this.button7.TabIndex = 131;
            this.button7.Text = "Repair";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = global::WirelessPOS.Properties.Resources.icons8_checkout_30px_2;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button6.Location = new System.Drawing.Point(14, 16);
            this.button6.Margin = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.button6.Size = new System.Drawing.Size(57, 57);
            this.button6.TabIndex = 130;
            this.button6.Text = "Sale";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Image = global::WirelessPOS.Properties.Resources.icons8_view_details_20px;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.Width = 70;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitle.Image = global::WirelessPOS.Properties.Resources.icons8_control_panel_25px;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(1, 1);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblTitle.Size = new System.Drawing.Size(1065, 40);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "         Control Panel";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.LblTitle_Click);
            // 
            // OperatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1087, 625);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OperatorView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OperatorView_FormClosing);
            this.Load += new System.EventHandler(this.OperatorView_Load);
            this.Shown += new System.EventHandler(this.OperatorView_Shown);
            this.SizeChanged += new System.EventHandler(this.OperatorView_SizeChanged);
            this.panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTransactionableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MaskedTextBox txtTradeSearch;
        private System.Windows.Forms.Button btnFindTrade;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.BindingSource iTransactionableBindingSource;
        private System.Windows.Forms.BindingSource operatorBindingSource;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblCashin;
        private System.Windows.Forms.Label lblOpening;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblCashout;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblClosing;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button btnExpiredLayaways;
        private System.Windows.Forms.Button btnPendingRepairs;
        private Button btnPendingPayments;
    }
}