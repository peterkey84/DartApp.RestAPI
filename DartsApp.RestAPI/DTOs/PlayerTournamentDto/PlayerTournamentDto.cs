namespace DartsApp.RestAPI.DTOs.PlayerTournamentDto
{
    public class PlayerTournamentDto
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TournamentId { get; set; }
        public string PlayerStatistics { get; set; }
        public int PlayerPoints { get; set; }

    }


}
