using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WirelessPOS.Properties;

namespace WirelessPOS.Utility
{
    public class MySqlConnection
    {
        public string Server
        {
            get => Settings.Default.Server;
            set => Settings.Default.Server = value;
        }

        public string Database
        {
            get => Settings.Default.Database;
            set => Settings.Default.Database = value;
        }
        public string User
        {
            get => Settings.Default.User;
            set => Settings.Default.User = value;
        }
        public string Password
        {
            get => Settings.Default.Password;
            set => Settings.Default.Password = value;
        }

        public void Save()
        {
            Settings.Default.Save();
        }

        public static string CreateConnection(string server,
            string database, string user, string password)
        {
            return
            "server=" + server + ";" +
            "database=" + database + ";" +
            "user=" + user + ";" +
            "password=" + password;
        }

        public static string GetCurrentConnection()
        {
            var connection = new MySqlConnection();
            return
            "server=" + connection.Server + ";" +
            "database=" + connection.Database + ";" +
            "user=" + connection.User + ";" +
            "password=" + connection.Password;
        }

    }
}
