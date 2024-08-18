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

            builder.HasData(
                new Place { Id = 1, Name = "Pub Kielich", ContactEmail = "kielich@gmail.com", ContactNumber= "123456789", City= "Gdańsk", Street= "Grunwaldzka 3", PostalCode="80-120" },
                new Place { Id = 2, Name = "Red Pub", ContactEmail = "red@red.com", ContactNumber = "987654321", City = "Wrocław", Street = "Kościuszki 4", PostalCode = "20-120" },
                new Place { Id = 3, Name = "Pobite gary", ContactEmail = "pobite_gary@gmail.com", ContactNumber = "123456789", City = "Bydgoszcz", Street = "Toruńska 5", PostalCode = "10-120" },
                new Place { Id = 4, Name = "Elo Disco", ContactEmail = "elo@disco.com", ContactNumber = "123456789", City = "Toruń", Street = "Jasna 6", PostalCode = "80-130" },
                new Place { Id = 5, Name = "Pub", ContactEmail = "pub@gmail.com", ContactNumber = "987654321", City = "Piaseczno", Street = "Geodetów 8", PostalCode = "50-125" },
                new Place { Id = 6, Name = "Dart pub", ContactEmail = "dart_pub@gmail.com", ContactNumber = "123456789", City = "Kowale", Street = "Starowiejska 1", PostalCode = "80-135" },
                new Place { Id = 7, Name = "Pubik", ContactEmail = "Pubik@Pubik.com", ContactNumber = "666888999", City = "Wejherowo", Street = "Kaszubska 8", PostalCode = "00-110" },
                new Place { Id = 8, Name = "Melina", ContactEmail = "melina@gmail.com", ContactNumber = "123456789", City = "Malbork", Street = "Tczewska 3", PostalCode = "10-120" },
                new Place { Id = 9, Name = "PTarasy", ContactEmail = "tarasy@gmail.com'", ContactNumber = "123456789", City = "Warszawa", Street = "Fajna 666", PostalCode = "30-320" },
                new Place { Id = 10, Name = "Pub Pod Kozłami", ContactEmail = "pod.kozłami@gmail.com", ContactNumber = "666888999", City = "Poznań", Street = "Pyry 3", PostalCode = "10-000" },
                new Place { Id = 11, Name = "Pod krasnalem", ContactEmail = "podkrasnalem@gmail.com", ContactNumber = "123456789", City = "Katowice", Street = "Krakowska 3", PostalCode = "50-420" }

                );

        }
    }
}
