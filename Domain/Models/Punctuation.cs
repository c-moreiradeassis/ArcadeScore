namespace Domain.Models
{
    public class Punctuation
    {
        public int Id { get; set; }
        public string? Player { get; set; }
        public int Points { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
