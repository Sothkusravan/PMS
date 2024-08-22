using Microsoft.EntityFrameworkCore;
using pharma.Model;
namespace pharma.Data
{
    public class PharmaDbContext : DbContext
    {
        public PharmaDbContext(){}
        public PharmaDbContext(DbContextOptions<PharmaDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> UserDetails { get; set; }
        public DbSet<Suppliers> SuppliersDetails { get; set; }
        public DbSet<DrugDetails> DrugInventory { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<DrugRequest> DrugRequests { get; set; }
        public DbSet<SuppliersInventory> SuppliersInventory{get;set;}
        public DbSet<Sales> SalesDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.UserPassword).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique();
            modelBuilder.Entity<DrugDetails>().Property(d => d.ExpiryDate).HasComputedColumnSql("DATEADD(month, 30, ManufacturedDate)");
            modelBuilder.Entity<DrugRequest>().Property(d => d.RequestedDate).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");       
            modelBuilder.Entity<OrderDetails>().Property(d => d.OrderedDate).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");   
             modelBuilder.Entity<Sales>().Property(d => d.SalesDate).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");      
        }
    }
}
