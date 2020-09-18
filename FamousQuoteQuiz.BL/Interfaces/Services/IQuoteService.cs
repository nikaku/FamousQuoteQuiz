using FamousQuoteQuiz.BL.Dtos.QuoteDtos;
using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Interfaces.Services
{
    public interface IQuoteService
    {
        Quote Create(CreateQuoteDto createQuoteDto);
        Quote Update(UpdateQuoteDto createQuoteDto);
        Quote Get(int id);
        IEnumerable<Quote> GetAll(QuoteFilter filter);
        IEnumerable<Quote> GetRandomQuotes(int count);
    }
}
