using Domain.Models;

namespace Application.Interfaces
{
    public interface PunctuationService
    {
        void Add(Punctuation punctuation);
        Statistic Details(string player);
        List<Punctuation> GetAll();
    }
}
