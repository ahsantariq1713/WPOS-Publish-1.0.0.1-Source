//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPos.Domain;

namespace WPos.DataContext
{
    public class WPosContext : DbContext
    {
        public string Connection { get; }
        public WPosContext(string connection)
        {
            Connection = connection;
        }
        public DbSet<Item> Item { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<PurchaseItem> PurchaseItem { get; set; }
        public DbSet<StockItem> StockItem { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Repair> Repair { get; set; }
        public DbSet<Unlock> Unlock { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<NewActivation> NewActivation { get; set; }
        public DbSet<CallingCard> CallingCard { get; set; }
        public DbSet<Portin> Portin { get; set; }
        public DbSet<Layaway> Layaway { get; set; }
        public DbSet<SaleItem> SaleItem { get; set; }
        public DbSet<Policy> Policy { get; set; }
        public DbSet<PolicyType> PolicyType { get; set; }
        public DbSet<RepairStatus> RepairStatus { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Operator> Operator { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<AirTimePlan> AirTimePlan { get; set; }
        public DbSet <MonthlyPlan> MonthlyPlan { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SQLitePCL.Batteries.Init();
            // optionsBuilder.UseMySQL(Connection);
            
            optionsBuilder.UseSqlite("Data Source=wpos.db");

            //base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(bool))
                    {
                        property.SetValueConverter(new BoolToIntConverter());
                    }
                }
            }
        }


        public int Commit(out Error error)
        {

            try
            {
                error = null;
                return SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                error = new Error("Database operation failed. See error log for further details.", ex);
            }
            catch (DbUpdateException ex)
            {
                error = new Error("Database operation failed. See error log for further details.", ex);
            }
            return default;
        }
    }
}
