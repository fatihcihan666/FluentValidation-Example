using FluentValidation_Example.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentValidation_Example.Context
{
    public class EfContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=FluentDb;Uid=sa;Password=1");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
