using Microsoft.EntityFrameworkCore;

namespace Auth.Repository.Model.Entity
{
    public partial class DBContext : DbContext
    {
        public DBContext(){}
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Corporate_Customer_Tbl> Corporate_Customer_Tbl { get; set; }
        public DbSet<Individual_Customer_Tbl> Individual_Customer_Tbl { get; set; }
        public DbSet<Meeting_Minutes_Details_Tbl> Meeting_Minutes_Details_Tbl { get; set; }
        public DbSet<Meeting_Minutes_Master_Tbl> Meeting_Minutes_Master_Tbl { get; set; }
        public DbSet<Product_Service_Tbl> Product_Service_Tbl { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
