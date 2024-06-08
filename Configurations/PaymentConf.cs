using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_COLO.Models;

namespace PJATK_APBD_COLO.Configurations;

public class PaymentConf : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.IdPayment);
        builder.Property(p => p.IdPayment).ValueGeneratedOnAdd();
        
        builder.Property(p => p.Date);

        builder.HasOne(p => p.ClientNavigator)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.SubscriptionNavigator)
            .WithMany(s => s.Payments)
            .HasForeignKey(p => p.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}