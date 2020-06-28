using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        {
        }

        public DbSet<CalculatorMapping> CalculatorMappings { get; set; }        
        public DbSet<TaxValue> TaxValues { get; set; }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<CalculatorMapping>().ToTable("calculatormapping");
            modelBuilder.Entity<TaxValue>().ToTable("taxvalue");                
        }   
    }
}