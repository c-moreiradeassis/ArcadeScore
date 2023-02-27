using Data.Mappings;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Punctuation> Punctuations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PunctuationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
