using Microsoft.EntityFrameworkCore;

namespace apief.Model.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Product> Products {get; set;}

        public DbSet<Category> Categories {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Database=postgres;Username=postgres;Password=postgres");
        }
        
    }
}