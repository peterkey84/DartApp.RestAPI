namespace DartsApp.RestAPI.DTOs
{
    public class PlayerTournamentDto
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TournamentId { get; set; }
        public string PlayerStatistics { get; set; }
        public int PlayerPoints { get; set; }

    }

    public class PlayerTournamentStatisticsDto
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string PlayerStatistics { get; set; }

    }
}
