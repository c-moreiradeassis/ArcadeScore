namespace Domain.Models
{
    public class Statistic
    {
        public string? Player { get; set; }
        public int MatchesPlayed { get; set; }
        public double AveragePunctuation { get; set; }
        public int BiggerPunctuation { get; set; }
        public int SmallerPunctuation { get; set; }
        public int AmountRecord { get; set; }
        public double PlayingTime { get; set; }
    }
}
