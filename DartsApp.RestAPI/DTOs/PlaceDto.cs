namespace DartsApp.RestAPI.DTOs
{
    public class PlaceCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }


    }

    public class PlaceViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
