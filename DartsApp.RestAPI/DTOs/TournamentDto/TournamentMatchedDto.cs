namespace DartsApp.RestAPI.DTOs.TournamentDto
{
    public class TournamentMatchedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FormattedTournamentDate { get; set; }
        public string City { get; set; }
    }
}
