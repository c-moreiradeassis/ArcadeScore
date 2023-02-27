using Domain.Models;

namespace Domain.Interfaces
{
    public interface PunctuationRepository
    {
        void Add(Punctuation punctuation);
        List<Punctuation> Details(string player);
        List<Punctuation> GetAll();
    }
}
