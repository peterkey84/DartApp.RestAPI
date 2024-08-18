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


            builder.HasData(

                new PlayerTournament { Id = 1, PlayerId = 1, TournamentId = 1, PlayerStatistics = "5 wygranych, 3 przegrane", PlayerPoints = 15 },
                new PlayerTournament { Id = 2, PlayerId = 2, TournamentId = 1, PlayerStatistics = "4 wygrane, 4 przegrane", PlayerPoints = 12 },
                new PlayerTournament { Id = 3, PlayerId = 3, TournamentId = 2, PlayerStatistics = "6 wygranych, 2 przegrane", PlayerPoints = 18 },
                new PlayerTournament { Id = 4, PlayerId = 4, TournamentId = 2, PlayerStatistics = "3 wygrane, 5 przegranych", PlayerPoints = 9 },
                new PlayerTournament { Id = 5, PlayerId = 5, TournamentId = 3, PlayerStatistics = "7 wygranych, 1 przegrana", PlayerPoints = 21 },
                new PlayerTournament { Id = 6, PlayerId = 6, TournamentId = 3, PlayerStatistics = "2 wygrane, 6 przegranych", PlayerPoints = 6 },
                new PlayerTournament { Id = 7, PlayerId = 7, TournamentId = 4, PlayerStatistics = "8 wygranych, 0 przegranych", PlayerPoints = 24 },
                new PlayerTournament { Id = 8, PlayerId = 8, TournamentId = 4, PlayerStatistics = "1 wygrana, 7 przegranych", PlayerPoints = 3 },
                new PlayerTournament { Id = 9, PlayerId = 9, TournamentId = 5, PlayerStatistics = "5 wygranych, 3 przegrane", PlayerPoints = 15 },
                new PlayerTournament { Id = 10, PlayerId = 10, TournamentId = 5, PlayerStatistics = "4 wygrane, 4 przegrane", PlayerPoints = 12 }

                );       
        }
    }
}
