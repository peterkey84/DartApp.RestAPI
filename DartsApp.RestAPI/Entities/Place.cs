namespace DartsApp.RestAPI.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode  { get; set; }
        public ICollection<Tournament> Tournament { get; set; }


    }
}
