using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamousQuoteQuiz.BL.Dtos.QuoteDtos;
using FamousQuoteQuiz.BL.Filters;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuoteService _quoteService;
        public QuotesController(IUnitOfWork unitOfWork, IQuoteService quoteService)
        {
            _unitOfWork = unitOfWork;
            _quoteService = quoteService;
        }

        [HttpPost]
        public IActionResult Create(CreateQuoteDto quote)
        {
            var quoteInDb = _unitOfWork.QuoteRepository.Find(x => x.QuoteString == quote.QuoteString);
            if (quoteInDb != null)
            {
                return Conflict($"Quote : {quote.QuoteString} Already Exists ");
            }
            var result = _quoteService.Create(quote);
            _unitOfWork.SaveChanges();
            return Ok(result.Id);
        }

        [HttpPut]
        public IActionResult Update(UpdateQuoteDto quote)
        {
            var quoteInDb = _unitOfWork.QuoteRepository.Find(x => x.QuoteString == quote.QuoteString);
            if (quoteInDb == null)
            {
                return NotFound();
            }
            var res = _quoteService.Update(quote);
            _unitOfWork.SaveChanges();
            return Accepted(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quote = _quoteService.Get(id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] QuoteFilter filter)
        {
            var quotes = _quoteService.GetAll(filter);
            return Ok(quotes);
        }
    }
}
