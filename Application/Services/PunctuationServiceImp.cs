using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class PunctuationServiceImp : PunctuationService
    {
        private PunctuationRepository _repository;

        public PunctuationServiceImp(PunctuationRepository repository)
        {
            _repository = repository;
        }

        public void Add(Punctuation punctuation)
        {
            _repository.Add(punctuation);
        }

        public Statistic Details(string player)
        {
            var punctuations = _repository.Details(player);

            Statistic statistic = new Statistic()
            {
                Player = punctuations.First().Player,
                MatchesPlayed = punctuations.Count(),
                AveragePunctuation = punctuations.Average(p => p.Points),
                BiggerPunctuation = punctuations.Max(p => p.Points),
                SmallerPunctuation = punctuations.Min(p => p.Points),
                AmountRecord = CalculateRecord(punctuations),
                PlayingTime = CalculatePlayingTime(punctuations)
            };

            return statistic;
        }

        public List<Punctuation> GetAll()
        {
            var punctuations = _repository.GetAll();

            return punctuations;
        }

        private int CalculateRecord(List<Punctuation> punctuations)
        {
            int record = 0;
            int lastPunctuation = punctuations.First().Points;

            foreach (var item in punctuations)
            {
                if (item.Points > lastPunctuation)
                {
                    record++;
                }
            }

            return record;
        }

        public double CalculatePlayingTime(List<Punctuation> punctuations)
        {
            var firstTime = punctuations.First().DepartureDate;
            var lastTime = punctuations.Last().DepartureDate;

            TimeSpan differenceDate = lastTime - firstTime;

            return differenceDate.TotalDays;
        }
    }
}
