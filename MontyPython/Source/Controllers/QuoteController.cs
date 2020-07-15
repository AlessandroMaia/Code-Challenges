using Microsoft.AspNetCore.Mvc;
using Source.Models;
using Source.Services;

namespace Source.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            var aux = _service.GetAnyQuote();
            return new QuoteView
            {
                Id = aux.Id,
                Actor = aux.Actor,
                Detail = aux.Detail
            };
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            var aux = _service.GetAnyQuote(actor);

            if (aux == null) return NotFound();

            return new QuoteView
            {
                Id = aux.Id,
                Actor = aux.Actor,
                Detail = aux.Detail
            };
        }

    }
}

