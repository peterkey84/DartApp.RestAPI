namespace DartsApp.RestAPI.Entities
{
    public class PlayerTournament
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }

        public string PlayerStatistics { get; set; }
        public int PlayerPoints { get; set; }
    }
}
