using Source.Models;
using System;
using System.Linq;

namespace Source.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;


        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            var maxRadomInt = _context.Quotes.Count();

            return _context.Quotes.ToList()[_randomService.RandomInteger(maxRadomInt)];
        }

        public Quote GetAnyQuote(string actor)
        {
            var quotes = _context.Quotes.Where(x => x.Actor.Equals(actor)).ToList();

            if (quotes.Count == 0) return null;

            return quotes[_randomService.RandomInteger(quotes.Count)];
        }
    }
}
