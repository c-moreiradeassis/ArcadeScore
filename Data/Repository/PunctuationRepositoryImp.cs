using Data.Context;
using Domain.Interfaces;
using Domain.Models;

namespace Data.Repository
{
    public class PunctuationRepositoryImp : PunctuationRepository
    {
        private DataContext _context;

        public PunctuationRepositoryImp(DataContext context)
        {
            _context = context;
        }

        public void Add(Punctuation punctuation)
        {
            _context.Add(punctuation);
            _context.SaveChanges();
        }

        public List<Punctuation> Details(string player)
        {
            var punctuation = _context.Punctuations.Where(c => c.Player == player).OrderBy(c => c.Points).ToList();

            return punctuation;
        }

        public List<Punctuation> GetAll()
        {
            var punctuations = _context.Punctuations.Take(10).OrderByDescending(c => c.Points).ToList();

            return punctuations;
        }
    }
}
