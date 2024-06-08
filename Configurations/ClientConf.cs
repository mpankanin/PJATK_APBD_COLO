using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_COLO.Models;

namespace PJATK_APBD_COLO.Configurations;

public class ClientConf : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.IdClient);
        builder.Property(c => c.IdClient).ValueGeneratedOnAdd();

        builder.Property(c => c.FirstName).HasMaxLength(100);
        
        builder.Property(c => c.LastName).HasMaxLength(100);
        
        builder.Property(c => c.Email).HasMaxLength(100);

        builder.Property(c => c.Phone).HasMaxLength(100);
    }
}