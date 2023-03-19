using Microsoft.EntityFrameworkCore;
using System;
using WpfAppDataBase.MVVM.Models.Entities;

namespace WpfAppDataBase.Context
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sagam\Documents\Utbildning\Datalagring\DataBase\ComplaintManagement\WpfAppDataBase\Context\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors
        public DataContext() 
        {
        }
        public DataContext(DbContextOptions<DataContext> options)  : base(options)
        {
        }
        #endregion

        #region overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //modells if they need dubble keys
        }

        internal void Remove()
        {
            throw new NotImplementedException();
        }
        #endregion


        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<CaseEntity> Cases { get; set; }
    }
}
