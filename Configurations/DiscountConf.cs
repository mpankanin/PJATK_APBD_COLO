using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_COLO.Models;

namespace PJATK_APBD_COLO.Configurations;

public class DiscountConf : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(d => d.IdDiscount);
        builder.Property(d => d.IdDiscount).ValueGeneratedOnAdd();
        
        builder.Property(d => d.Value);
        
        builder.Property(d => d.DateFrom);
        
        builder.Property(d => d.DateTo);
        
        builder.HasOne(d => d.SubscriptionNavigator)
            .WithMany(s => s.Discounts)
            .HasForeignKey(d => d.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}