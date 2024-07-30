namespace DartsApp.RestAPI.DTOs
{
    public class TournamentCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TournamentDate { get; set; }
        public int PlaceId { get; set; }


    }

    public class TournamentViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FormattedTournamentDate { get; set; }
    }

    public class TournamentMatchedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FormattedTournamentDate { get; set; }
        public string City { get; set; }
    }



}
