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

            builder.Property(r => r.Ranking)
                .HasDefaultValue(0);

            builder.HasData(

                new Player { Id = 1, FirstName = "Adam", LastName = "Nowak", BirthdayDate = new DateTime(2000, 7, 10), ContactEmail = "adam.nowak@example.com", ContactNumber = "888000111" },
                new Player { Id = 2, FirstName = "Ewa", LastName = "Kowalska", BirthdayDate = new DateTime(2002, 7, 10), ContactEmail = "ewa.kowalska@example.com", ContactNumber = "222333444", Ranking = 170 },
                new Player { Id = 3, FirstName = "Paweł", LastName = "Wiśniewski", BirthdayDate = new DateTime(1989, 1, 20), ContactEmail = "pawel.wisniewski@example.com", ContactNumber = "333444555", Ranking = 180 },
                new Player { Id = 4, FirstName = "Magdalena", LastName = "Wójcik", BirthdayDate = new DateTime(1984, 5, 5), ContactEmail = "magdalena.wojcik@example.com", ContactNumber = "444555666", Ranking = 160 },
                new Player { Id = 5, FirstName = "Michał", LastName = "Lewandowski", BirthdayDate = new DateTime(2006, 11, 30), ContactEmail = "michal.lewandowski@example.com", ContactNumber = "555666777", Ranking = 190 },
                new Player { Id = 6, FirstName = "Katarzyna", LastName = "Kamińska", BirthdayDate = new DateTime(1999, 2, 25), ContactEmail = "katarzyna.kaminska@example.com", ContactNumber = "666777888", Ranking = 200 },
                new Player { Id = 7, FirstName = "Jan", LastName = "Zieliński", BirthdayDate = new DateTime(1979, 12, 10), ContactEmail = "jan.zielinski@example.com", ContactNumber = "777888999", Ranking = 140 },
                new Player { Id = 8, FirstName = "Anna", LastName = "Szymańska", BirthdayDate = new DateTime(1994, 4, 18), ContactEmail = "anna.szymanska@example.com", ContactNumber = "888999000", Ranking = 210 },
                new Player { Id = 9, FirstName = "Tomasz", LastName = "Woźniak", BirthdayDate = new DateTime(1969, 9, 9), ContactEmail = "tomasz.wozniak@example.com", ContactNumber = "999000111", Ranking = 130 },
                new Player { Id = 10, FirstName = "Agnieszka", LastName = "Dąbrowska", BirthdayDate = new DateTime(2004, 3, 2), ContactEmail = "agnieszka.dabrowska@example.com", ContactNumber = "000111222", Ranking = 220 }

                );

        }
    }
}
