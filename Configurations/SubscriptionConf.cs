using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_COLO.Models;

namespace PJATK_APBD_COLO.Configurations;

public class SubscriptionConf : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(s => s.IdSubscription);
        builder.Property(s => s.IdSubscription).ValueGeneratedOnAdd();

        builder.Property(s => s.Name).HasMaxLength(100);
        
        builder.Property(s => s.RenewalPeriod);
        
        builder.Property(s => s.EndTime);
        
        builder.Property(s => s.Price);
    }
}