using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WirelessPOS.Utility;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public class Adapter
    {
        public Repository Repository { get; private set; }

        public async static Task<T> Resolve<T>()
        {
            var adapter = await CreateInstance();
            if (adapter == null) return default;
            if (!Auth.IsLoggedIn()) await Auth.Login();
            if (Auth.IsLoggedIn()) return (T)Activator.CreateInstance(typeof(T), adapter);
            return default;
        }

        public async static Task<T> Resolve<T, TParam1>(TParam1 param1)
        {

            var adapter = await CreateInstance();
            if (adapter == null) return default;
            if (!Auth.IsLoggedIn()) await Auth.Login();
            if (Auth.IsLoggedIn()) return (T)Activator.CreateInstance(typeof(T), adapter, param1);
            return default;
        }

        public async static Task<T> Resolve<T, TParam1, TParam2>(TParam1 param1, TParam2 param2)
        {

            var adapter = await CreateInstance();
            if (adapter == null) return default;
            if (!Auth.IsLoggedIn()) await Auth.Login();
            if (Auth.IsLoggedIn()) return (T)Activator.CreateInstance(typeof(T), adapter, param1, param2);
            return default;
        }

        public async static Task<T> Resolve<T, TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3)
        {
           
            var adapter = await CreateInstance();
            if (adapter == null) return default;
            if (!Auth.IsLoggedIn())  await Auth.Login();
            if (Auth.IsLoggedIn()) return (T)Activator.CreateInstance(typeof(T), adapter, param1, param2,param3);
            return default;
        }

        public async static Task<T> ResolveWithoutMiddleWare<T, TParam1>(TParam1 param1)
        {
            var adapter = await CreateInstance();
            if (adapter == null) return default;
            return (T)Activator.CreateInstance(typeof(T), adapter, param1);
        }

       


        public async static Task<Adapter> CreateInstance(string connection = null, string message = "Inititalizing Database Services")
        {
          
            var wait = new WaitWin(message);
            wait.Show();
            if (connection == null) connection = MySqlConnection.GetCurrentConnection();

            var adapter = await Task.Run(() => new Adapter(connection));

            if (adapter.Repository == null)
            {
                adapter = null;
            }

            wait.Close();

            return adapter;
        }

        public Adapter(string connection)
        {
            Repository = new Repository(connection, out Error error);
            if (error != null)
            {
                Repository = null;
                Message.Error(error.Message);
            }
        }

        public async Task<int> Save<T>(T entity, string successMsg = null)
        {

            Error error = null;

            if ((entity as BaseEntity).HasErrors(out string errors))
            {
                error = new Error("Some errors found while updating records.\n" + errors, null);
                return 0;
            }

            var changes = await Task.Run(() => Repository.Save<T>(entity, out error));
            if (error != null)
            {
                Message.Error(error.Message);
                changes = 0;
            }
            if (changes > 0 && successMsg != null) Message.Success(successMsg);
            return changes;
        }

        public async Task<int> Save<T>(IEnumerable<T> entities, string successMsg = null)
        {
            Error error = null;

            foreach (var entity in entities)
            {
                if ((entity as BaseEntity).HasErrors(out string errors))
                {
                    error = new Error("Some errors found while updating record(s).\n" + errors, null);
                    return 0;
                }
            }

            var changes = await Task.Run(() => Repository.Save<T>(entities, out error));
            if (error != null)
            {
                Message.Error(error.Message);
                changes = 0;
            }
            if (changes > 0 && successMsg != null) Message.Success(successMsg);
            return changes;
        }

        public async Task<int> Remove<T>(T entity, bool safeDelete = true, string successMsg = null)
        {
            Error error = null;
            var changes = await Task.Run(() => Repository.Remove(entity, out error, safeDelete));
            if (error != null)
            {
                Message.Error(error.Message);
                changes = 0;
            }
            if (changes > 0 && successMsg != null) Message.Success(successMsg);
            return changes;
        }

        public async Task<T> Retrive<T>(int id, bool withRelatedData = false)
        {
            Error error = null;
            var entity = await Task.Run(() => Repository.Retrive<T>(id, out error, withRelatedData));
            if (error != null)
            {
                Message.Error(error.Message);
                entity = default;
            }
            return entity;
        }
        public async Task<IEnumerable<T>> Retrive<T>(Predicate<T> predicate, bool withRelatedData = false)
        {
            Error error = null;
            var entities = await Task.Run(() => Repository.Retrive<T>(predicate, out error, withRelatedData));
            if (error != null)
            {
                Message.Error(error.Message);
                entities = default;
            }
            return entities;
        }

        public async Task<IEnumerable<T>> Retrive<T>(bool withRelatedData = false, bool activeOnly = true)
        {
            Error error = null;
            var entities = await Task.Run(() => Repository.Retrive<T>(out error, withRelatedData, activeOnly));
            if (error != null)
            {
                Message.Error(error.Message);
                entities = default;
            }
            return entities;
        }

        public async Task LoadRelatedData<T>(T entity)
        {
            Error error = null;
            await Task.Run(() => Repository.LoadRelatedData<T>(entity, out error));
            if (error != null)
            {
                Message.Error(error.Message);
            }
        }

        public async Task LoadReference<T>(T entity, string reference)
        {
            Error error = null;
            await Task.Run(() => Repository.LoadRefrence<T>(entity, reference, out error));
            if (error != null)
            {
                Message.Error(error.Message);
            }
        }

        public async Task LoadCollection<T>(T entity, string collection)
        {
            Error error = null;
            await Task.Run(() => Repository.LoadCollection<T>(entity, collection, out error));
            if (error != null)
            {
                Message.Error(error.Message);
            }
        }
    }
}
