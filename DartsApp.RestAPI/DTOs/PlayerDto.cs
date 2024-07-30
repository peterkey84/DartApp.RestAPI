namespace DartsApp.RestAPI.DTOs
{
    public class PlayerCreateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Ranking { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public DateTime BirthdayDate { get; set; }


    }

    public class PlayerViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PlayerRankingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ranking { get; set; }
    }
}
