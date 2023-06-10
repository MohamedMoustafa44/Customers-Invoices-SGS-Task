using InvoicesTask.CoreLayer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicesTask.DAL;

public class ApplicationDbContext : DbContext
{
    #region CTORs
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    #endregion

    #region Configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server =. ; Database = InvoicesDB; Trusted_Connection = true; Encrypt = false;");
        }
    }
    #endregion

    #region OnModelCreating Method
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ItemsDTL>()
            .Property(IDTL => IDTL.Price)
            .HasPrecision(14, 3);

        builder.Entity<ItemsDTL>()
            .HasKey(IDTL => new { IDTL.InvoiceId, IDTL.ItemCode });


    }
    #endregion

    #region DBTables
    public DbSet<InvoiceHDR> InvoiceHDRs => Set<InvoiceHDR>();
    public DbSet<ItemsDTL> ItemsDTLs => Set<ItemsDTL>();
    #endregion
}
