namespace DartsApp.RestAPI.DTOs
{
    public class BoardDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int TournamentId { get; set; }

    }
}
