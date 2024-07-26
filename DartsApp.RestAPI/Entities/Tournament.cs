namespace DartsApp.RestAPI.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TournamentDate { get; set; }
        public ICollection<PlayerTournament>? PlayerTournaments { get; set; }
        public ICollection<Board>? Boards { get; set; }
        public int PlaceId { get; set; }
        public virtual Place? Place { get; set; }


    }
}
