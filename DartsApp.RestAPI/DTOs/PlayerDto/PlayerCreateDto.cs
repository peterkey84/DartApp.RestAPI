namespace DartsApp.RestAPI.DTOs.PlayerDto
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
}
