using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPos.Domain;

namespace WirelessPOS
{
   public  class Auth
    {
        private static Operator op;
        public static async Task Login()
        {

            //if (new Validator().ValidateLicense()!=true)
            //{
            //    return;
            //}

            var adapter = await Adapter.CreateInstance();
            if (adapter != null)
            {
                var view = new LoginView(adapter);
                if(view.ShowDialog() == DialogResult.OK)
                {
                    Master.Instance.OperatorView = await Adapter.ResolveWithoutMiddleWare<OperatorView, Form>(Master.Instance);
                    Master.Instance.ToggleLogin();
                }
            }

            Master.Instance.ToggleAdminTools();

        }

        public static void Login(Operator @operator)
        {
            op = @operator;
        }

        public static Operator GetOperator()
        {
            return op;
        }

        public static string Name()
        {
            return op.User;
        }

        public static string Operator()
        {
            return op.Id+ "-"+op.User;
        }

        public static int Id()
        {
            return op.Id;
        }

        public static Role Role()
        {
            return op.Role;
        }

        public static void Logout(bool autoLogout = false)
        {
            if (autoLogout == false && Message.Question("You are going to logging off WPOS terminal. Are you sure?") == DialogResult.No)
            {
                return;
            }

            op = null;
            foreach (var form in Master.Instance.MdiChildren)
            {
                form.Close();
            }
            Master.Instance.OperatorView.Close();
            Master.Instance.OperatorView = null;
            Master.Instance.ToggleLogin();
            Master.Instance.ToggleAdminTools();
        }

        public static bool IsLoggedIn()
        {
            return op != null;
        }
    }
}
