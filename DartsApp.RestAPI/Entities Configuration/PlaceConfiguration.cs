using DartsApp.RestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DartsApp.RestAPI.Entities_Configuration
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasMany(c => c.Tournament)
                .WithOne(p => p.Place)
                .HasForeignKey(p => p.PlaceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.ContactEmail)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(e => e.ContactEmail)
                .IsUnique();

            builder.Property(f => f.ContactNumber)
                .IsRequired()
                .HasMaxLength(12);    

        }
    }
}
