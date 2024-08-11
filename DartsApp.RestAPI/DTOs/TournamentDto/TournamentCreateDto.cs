namespace DartsApp.RestAPI.DTOs.TournamentDto
{
    public class TournamentCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TournamentDate { get; set; }
        public int PlaceId { get; set; }


    }
}
