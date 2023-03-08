using Microsoft.EntityFrameworkCore;
using WpfAppDataBase.MVVM.Models.Enteties;

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
            if (optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //modells if they need dubble keys
        }
        #endregion


        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<CommentEntity> Comments { get; set; } = null!;
        public DbSet<CaseEntity> Cases { get; set; } = null!;
    }
}
