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
        }
    }
}
