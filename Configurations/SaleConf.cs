using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_COLO.Models;

namespace PJATK_APBD_COLO.Configurations;

public class SaleConf : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.IdSale);
        builder.Property(s => s.IdSale).ValueGeneratedOnAdd();
        
        builder.Property(s => s.CreatedAt);
        
        builder.HasOne(s => s.ClientNavigator)
            .WithMany(c => c.Sales)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.SubscriptionNavigator)
            .WithMany(s => s.Sales)
            .HasForeignKey(p => p.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}