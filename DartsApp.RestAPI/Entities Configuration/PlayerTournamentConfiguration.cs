using DartsApp.RestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DartsApp.RestAPI.Entities_Configuration
{
    public class PlayerTournamentConfiguration : IEntityTypeConfiguration<PlayerTournament>
    {
        public void Configure(EntityTypeBuilder<PlayerTournament> builder)
        {
            builder.HasOne(p => p.Player)
                .WithMany(t => t.PlayerTournaments)
                .HasForeignKey(k => k.PlayerId);

            builder.HasOne(t => t.Tournament)
                .WithMany(p => p.PlayerTournaments)
                .HasForeignKey(k => k.TournamentId);

            builder.Property(s => s.PlayerStatistics)
                .HasMaxLength(1000);

        }
    }
}
