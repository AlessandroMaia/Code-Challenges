using Source.Models;

namespace Source.Services
{
    public interface IQuoteService
    {
        Quote GetAnyQuote();
        Quote GetAnyQuote(string actor);
    }
}
