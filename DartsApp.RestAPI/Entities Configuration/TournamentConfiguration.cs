using DartsApp.RestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DartsApp.RestAPI.Entities_Configuration
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {

            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(o => o.TournamentDate)
                .IsRequired();
        }
    }
}
