using DartsApp.RestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DartsApp.RestAPI.Entities_Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {

            builder.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.BirthdayDate)
                .IsRequired();

            builder.Property(e => e.ContactEmail)
                .IsRequired(true)
                .HasMaxLength(60);

            builder.HasIndex(d => d.ContactEmail)
                .IsUnique();

            builder.Property(p => p.ContactNumber)
                .IsRequired()
                .HasMaxLength(12);

            builder.HasIndex(d => d.ContactNumber)
                .IsUnique();



        }
    }
}
