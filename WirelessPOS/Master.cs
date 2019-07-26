
using BarcodeStandard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using WirelessPOS.Properties;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class Master : Form
    {

        public Validator Validator { get; } = new Validator();
        public Master()
        {
            InitializeComponent();
        }

        public static Master Instance { get; set; }
        public Form OperatorView;
        public async void ToggleLogin()
        {
            if (Auth.IsLoggedIn())
            {
                btnLogin.Image = Resources.icons8_import_20px;
                btnLogin.Text = "Signout";
            }
            else
            {
                btnLogin.Image = Resources.icons8_enter_2_20px;
                btnLogin.Text = "Signin";
            }
        }




        private async void NewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<ItemEditView, int, Form>(0, this);
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DbSettingsView(this);
        }

        private void ContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            ToggleLogin();
        }

        private async void SaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<SaleEditView, int, Form>(0, this);
        }



        private async void RepairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<RepairEditView, int, Form>(0, this);
        }

        private void PrintToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new PrintSettingsView(this);
        }

        private async void LayawayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<LayawayEditView, int, Form>(0, this);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            menu.Visible = !menu.Visible;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Message.Question("Are you sure you want to exit WPOS Application?") == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private async void ToolStripButton5_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<NewActivationEditView, int, Form>(0, this);
        }

        private async void ToolStripButton1_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<LayawayEditView, int, Form>(0, this);
        }

        private async void CutToolStripButton_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<RepairEditView, int, Form>(0, this);
        }

        private async void PasteToolStripButton_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PurchaseEditView, int, Form>(0, this);
        }

        private async void PrintToolStripButton_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<SaleEditView, int, Form>(0, this);
        }

        private async void CustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<CustomerListView, Form>(this);
        }

        private async void ToolStripButton3_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PortinEditView, int, Form>(0, this);
        }

        private async void PortinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PortinEditView, int, Form>(0, this);
        }

        private async void ToolStripButton4_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<CallingCardEditView, int, Form>(0, this);
        }

        private async void ToolStripButton2_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<UnlockEditView, int, Form>(0, this);
        }

        private async void CopyToolStripButton_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PaymentEditView, int, Form>(0, this);
        }

        private async void CreateNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PolicyEditView, int, Form>(0, this);
        }

        private async void NewActivationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<NewActivationEditView, int, Form>(0, this);
        }

        private async void PaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PaymentEditView, int, Form>(0, this);
        }

        private async void UnlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<UnlockEditView, int, Form>(0, this);
        }

        private async void CallingCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<CallingCardEditView, int, Form>(0, this);
        }

        private void VideoLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            if (Auth.IsLoggedIn())
            {
                Auth.Logout();
            }
            else
            {
                await Auth.Login();
            }
        }


        public void ToggleAdminTools()
        {
            if (Auth.IsLoggedIn() && Auth.GetOperator().Role == Role.Administrator)
            {
                databaeToolStripMenuItem.Visible = true;
                listToolStripMenuItem1.Visible = true;
                policiesToolStripMenuItem.Visible = true;
            }
            else
            {
                databaeToolStripMenuItem.Visible = false;
                listToolStripMenuItem1.Visible = false;
                policiesToolStripMenuItem.Visible = false;
            }
        }

        private void LicnseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LicenseView().ShowDialog(this);
        }

        private async void NewToolStripButton_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<StockView, Form>(this);
        }

        private async void ViewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<StockView, Form>(this);
        }

        private async void PurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PurchaseEditView, int, Form>(0, this);
        }

        private async void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PolicyListView, Form>(this);
        }

        private async void StockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<StockView, Form>(this);
        }

        private async void SupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<SupplierListView, Form>(this);
        }

        private async void TradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<TradeListView, Form>(this);
        }

        private async void OperatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Auth.IsLoggedIn())
            {
                if (Auth.Role() == Role.Administrator)
                {
                    await Adapter.Resolve<OperatorListView, Form>(this);
                }
                else
                {
                    Message.Error("Access denied. You must logged in from Administrator account to access operator list");
                }
            }
            else
            {
                Message.Error("Access denied. You must logged in from Administrator account to access operator list");
            }

        }

        private void SearchToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private async void ItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<ItemListView, Form>(this);
        }

        private async void TradeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            await Adapter.Resolve<TradeListView, Form>(this);
        }

        private async void PoliciesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<PolicyListView, Form>(this);
        }

        private async void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<CustomerListView, Form>(this);
        }

        private async void SupplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<SupplierListView, Form>(this);
        }

        private async void TradeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            await Adapter.Resolve<TradeListView, Form>(this);
        }

        private void SendPromoMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Message.Error("Base-Url is missing in Bulk Message AP Interface. ");
        }

        private void CustomTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Message.Error("Base-Url is missing in Bulk Message AP Interface. ");
        }

        private void DatabaeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TaxToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new TaxSettingsView(this).ShowDialog();
        }
    }
}
