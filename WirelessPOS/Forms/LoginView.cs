using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WirelessPOS.Utility;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class LoginView : Form
    {
        public Adapter Adapter { get; }

        public LoginView(Adapter adapter, object owner = null)
        {
            Owner = owner as Form;
            Adapter = adapter;
            InitializeComponent();
            Inititalize();
        }


        private async void Inititalize()
        {

            var operators = await Adapter.Retrive<Operator>();
            if (operators == null || operators.Count() <= 0)
            {
                await Adapter.Save(new Operator
                {
                    User = "Admin",
                    Role = Role.Administrator,
                    Password = Security.GetSHA1("secret")
                });

                await Adapter.Save(new RepairStatus
                {
                   Status = "Pending"
                });

                await Adapter.Save(new RepairStatus
                {
                    Status = "Closed"
                });

                await Adapter.Save(new PolicyType
                {
                    Name = "Repair"
                });

                await Adapter.Save(new PolicyType
                {
                    Name = "Layaway"
                });

                await Adapter.Save(new PolicyType
                {
                    Name = "Payment"
                });

                await Adapter.Save(new PolicyType
                {
                    Name = "CallingCard"
                });

                await Adapter.Save(new PolicyType
                {
                    Name = "Unlock"
                });
                await Adapter.Save(new PolicyType
                {
                    Name = "NewActivation"
                });

                await Adapter.Save(new PolicyType
                {
                    Name = "Sale"
                });

                await Adapter.Save(new PolicyType
                {
                    Name = "Purchase"
                });

                await Adapter.Save(new PolicyType
                {
                    Name = "Portin"
                });
            }

            BindEntity();
            Show(Owner);
        }

        private void BindEntity()
        {
            ddlRole.Items.Clear();
            ddlRole.Items.Add(Role.Administrator.ToString());
            ddlRole.Items.Add(Role.StandardUser.ToString());

            ddlRole.SelectedIndex = 0;

        }

        private void Show(Form owner)
        {
            if (owner == null) return;
            this.ShowDialog(owner);
        }

        private async void BtnSaveClose_Click(object sender, EventArgs e)
        {

            if (btnSave.IsBusy()) return;
            if (!float.TryParse(txtOpening.Text,out float r))
            {
                Message.Error("Opening balance is invalid");
                return;
            }

            btnSave.MarkBusy(out Image image, out Color color);
            var @operator = (await Adapter.Retrive<Operator>())?.ToList()
                .Find(x =>
                {
                    return
                    XString.Equal(x.User, txtUser.Text) &&
                    XString.Equal(x.Role.ToString(), ddlRole.Text) &&
                    XString.Equal(x.Password, Security.GetSHA1(txtPassword.Text));
                });
            btnSave.MarkFree(image, color);
            if (@operator != null)
            {
               
                @operator.Shifts = @operator.Shifts ?? new List<Shift>();
                @operator.Shifts.Add(new Shift { OpeningBalance = float.TryParse(txtOpening.Text.ToString(), out float opening) ? opening : 0 });
                await Adapter.Save(@operator);
                Auth.Login(@operator);
                DialogResult = DialogResult.OK;
            }
            else
            {
                Message.Error("Invalid user or password.");
            }
        }

    }
}
