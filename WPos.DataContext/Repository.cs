using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPos.Domain;

namespace WPos.DataContext
{
    public class Repository
    {
        WPosContext Context { get; }
        public Repository(string connection, out Error error)
        {
            error = null;
            try
            {
                Context = new WPosContext(connection);
                Context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                error = new Error("Database connection failed. View error log to see further details." + ex.Message+ex.InnerException?.Message, ex);
                LogException(ex);
            }
        }

        public int Save<T>(T entity, out Error error)
        {
            error = null;

            try
            {

                if ((entity as BaseEntity).IsNew)
                {
                    Context.Add(entity);
                }
                else
                {
                    Context.Update(entity);
                }
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                error = new Error("Database operation failed. View error log to see further details.", ex);
                LogException(ex);
            }
            return default;
        }

        public int Save<T>(IEnumerable<T> entities, out Error error)
        {
            error = null;

            try
            {
                foreach (var entity in entities)
                {
                    if ((entity as BaseEntity).IsNew)
                    {
                        Context.Add(entity);
                    }
                    else
                    {
                        Context.Update(entity);
                    }
                }

                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                error = new Error("Database operation failed. View error log to see further details.", ex);
                LogException(ex);
            }
            return default;
        }


        public int Remove<T>(T entity, out Error error, bool safeDelete)
        {
            error = null;
            try
            {
                if (safeDelete)
                {
                    (entity as BaseEntity).SafeDelete();
                    if ((entity as BaseEntity).IsNew)
                    {
                        Context.Add(entity);
                    }
                    else
                    {
                        Context.Update(entity);
                    }
                }
                else
                {
                    Context.Remove(entity);
                }

                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                error = new Error("Database operation failed. View error log to see further details.", ex);
                LogException(ex);
            }
            return default;
        }

        public T Retrive<T>(int id, out Error error, bool withRelatedData = false)
        {
            error = null;
            try
            {
                var entity = (T)Context.Find(typeof(T), id);
                if (entity == null) return default;
                if (withRelatedData) LoadRelatedData(entity, out error);
                return (entity as BaseEntity).EntitySate == Domain.EntityState.Active ? entity : default;
            }
            catch (Exception ex)
            {
                error = new Error("Database operation failed. View error log to see further details.", ex);
                LogException(ex);
            }
            return default;
        }

        public void LoadCollection<T>(T entity, string collection, out Error error)
        {
            error = null;
            //try
            //{
            Context.Entry(entity).Collection(collection).Load();
            //}
            //catch (Exception ex)
            //{
            //    error = new Error("Database operation failed. View error log to see further details.", ex);
            //    LogException(ex);
            //}
            //return default;
        }

        public void LoadRefrence<T>(T entity, string reference, out Error error)
        {
            error = null;
            //try
            //{
            Context.Entry(entity).Reference(reference).Load();
            //}
            //catch (Exception ex)
            //{
            //    error = new Error("Database operation failed. View error log to see further details.", ex);
            //    LogException(ex);
            //}
            //return default;
        }

        public void LoadRelatedData<T>(T entity, out Error error)
        {
            error = null;
            //try
            //{
            foreach (var refrence in Context.Entry(entity).References)
            {
                refrence.Load();
            }

            foreach (var collection in Context.Entry(entity).Collections)
            {
                collection.Load();
            }
            //}
            //catch (Exception ex)
            //{
            //    error = new Error("Database operation failed. View error log to see further details.", ex);
            //    LogException(ex);
            //}
            //return default;
        }

        public IEnumerable<T> Retrive<T>(Predicate<T> func, out Error error, bool withRelatedData = false)
        {
            error = null;
            //try
            //{

            var entities = Context.GetType().GetProperty(typeof(T).Name).GetValue(Context) as IEnumerable<T>;

            if (entities == null) return default;

            var activeEntities = entities.ToList().FindAll(x => (x as BaseEntity).IsActive)?.FindAll(func);

            if (withRelatedData)
            {
                foreach (var entity in activeEntities)
                {
                    LoadRelatedData(entity, out error);
                }
            }

            return activeEntities;
            //}
            //catch (Exception ex)
            //{
            //    error = new Error("Database operation failed. View error log to see further details.", ex);
            //    LogException(ex);
            //}
            //return default;
        }

        public IEnumerable<T> Retrive<T>(out Error error, bool withRelatedData = false, bool activeOnly = true)
        {
            error = null;
            //try
            //{

            var entities = Context.GetType().GetProperty(typeof(T).Name).GetValue(Context) as IEnumerable<T>;

            if (entities == null) return default;

            var found = activeOnly?entities.ToList().FindAll(x => (x as BaseEntity).IsActive):entities;

            if (withRelatedData)
            {
                foreach (var entity in found)
                {
                    LoadRelatedData(entity, out error);
                }
            }

            return found;
            //}
            //catch (Exception ex)
            //{
            //    error = new Error("Database operation failed. View error log to see further details.", ex);
            //    LogException(ex);
            //}
            //return default;
        }

        private static void LogException(Exception ex)
        {

            if (!File.Exists("Errors.Log")) File.WriteAllText("Errors.Log", "");
            File.AppendAllLines("Errors.Log", new string[] { ex.Message +
                ". " + ex.InnerException?.Message +" : " +DateTime.Now});

        }
    }
}
