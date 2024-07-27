using DartsApp.RestAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DartsApp.RestAPI.Entities_Configuration
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasOne(b => b.Tournament)
                .WithMany(c => c.Boards)
                .HasForeignKey(a => a.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(

                new Board { Id = 1, Brand = "Winmau", Model= "Blade6", Type="sizylowa", TournamentId=1 },
                new Board { Id = 2, Brand = "Winmau", Model = "Blade5", Type = "sizylowa", TournamentId = 1 },
                new Board { Id = 3, Brand = "Winmau", Model = "Blade4", Type = "sizylowa", TournamentId = 2 },
                new Board { Id = 4, Brand = "Winmau", Model = "Blade3", Type = "sizylowa", TournamentId = 3 },
                new Board { Id = 5, Brand = "Koto", Model = "Tournament", Type = "sizylowa", TournamentId = 4 },
                new Board { Id = 6, Brand = "Koto", Model = "King Pro", Type = "sizylowa", TournamentId = 1 },
                new Board { Id = 7, Brand = "Koto", Model = "King Classic", Type = "sizylowa", TournamentId = 2 },
                new Board { Id = 8, Brand = "Unicorn", Model = "Eclipse Pro", Type = "sizylowa", TournamentId = 3 },
                new Board { Id = 9, Brand = "Unicorn", Model = "Contender", Type = "sizylowa", TournamentId = 4 },
                new Board { Id = 10, Brand = "Unicorn", Model = "Eclipse Ultra", Type = "sizylowa", TournamentId = 5 }


                );
        }
    }
}
