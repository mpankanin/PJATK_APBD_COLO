using Microsoft.EntityFrameworkCore;
using PJATK_APBD_COLO.Configurations;
using PJATK_APBD_COLO.Models;

namespace PJATK_APBD_COLO.Properties.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    
    public AppDbContext() {}
    
    public AppDbContext(DbContextOptions options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConf());
        modelBuilder.ApplyConfiguration(new DiscountConf());
        modelBuilder.ApplyConfiguration(new PaymentConf());
        modelBuilder.ApplyConfiguration(new SaleConf());
        modelBuilder.ApplyConfiguration(new SubscriptionConf());
    }
}
