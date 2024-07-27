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

            builder.HasData(

                new Tournament { Id = 1, Name = "Turniej Zielony Pub", TournamentDate = new DateTime(2023, 8, 1), PlaceId = 1 },
                new Tournament { Id = 2, Name = "Turniej Kielicha", TournamentDate = new DateTime(2023, 9, 1), PlaceId = 2 },
                new Tournament { Id = 3, Name = "Turniej Czerwony Pub", TournamentDate = new DateTime(2023, 10, 1), PlaceId = 3 },
                new Tournament { Id = 4, Name = "Turniej Pobitych Garów", TournamentDate = new DateTime(2023, 11, 1), PlaceId = 4 },
                new Tournament { Id = 5, Name = "Turniej Disco", TournamentDate = new DateTime(2023, 12, 1), PlaceId = 5 },
                new Tournament { Id = 6, Name = "Turniej Pubu", TournamentDate = new DateTime(2024, 1, 1), PlaceId = 6 },
                new Tournament { Id = 7, Name = "Turniej Dart Pub", TournamentDate = new DateTime(2024, 2, 1), PlaceId = 7 },
                new Tournament { Id = 8, Name = "Turniej Pubiku", TournamentDate = new DateTime(2024, 3, 1), PlaceId = 8 },
                new Tournament { Id = 9, Name = "Turniej Meliny", TournamentDate = new DateTime(2024, 4, 1), PlaceId = 9 },
                new Tournament { Id = 10, Name = "Turniej Tarasów", TournamentDate = new DateTime(2024, 5, 1), PlaceId = 10 },
                new Tournament { Id = 11, Name = "Turniej Krasnala", TournamentDate = new DateTime(2024, 6, 1), PlaceId = 11 },
                new Tournament { Id = 12, Name = "Turniej Zielonego Pubu", TournamentDate = new DateTime(2024, 7, 1), PlaceId = 10 },
                new Tournament { Id = 13, Name = "Turniej Kielicha II", TournamentDate = new DateTime(2024, 8, 1), PlaceId = 2 },
                new Tournament { Id = 14, Name = "Turniej Czerwonego Pubu II", TournamentDate = new DateTime(2024, 9, 1), PlaceId = 3 },
                new Tournament { Id = 15, Name = "Turniej Pobitych Garów II", TournamentDate = new DateTime(2024, 10, 1), PlaceId = 9 }


                );
        }
    }
}
