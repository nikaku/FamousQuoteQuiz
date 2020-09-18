using AutoMapper;
using FamousQuoteQuiz.BL.Dtos.QuoteDtos;
using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Filters;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamousQuoteQuiz.DB.Implementations.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuoteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Quote Create(CreateQuoteDto createQuoteDto)
        {
            var quote = _mapper.Map<Quote>(createQuoteDto);
            var quoteAdded = _unitOfWork.QuoteRepository.Add(quote);
            return quoteAdded;
        }

        public Quote Get(int id)
        {
            return _unitOfWork.QuoteRepository.Get(id);
        }

        public IEnumerable<Quote> GetAll(QuoteFilter filter)
        {
            return _unitOfWork.QuoteRepository.FindAll(x =>
               (filter.AuthorId == null || x.AuthorId == filter.AuthorId) &&
               (filter.Id == null || x.Id == filter.Id) &&
               (filter.QuoteString == null || x.QuoteString == filter.QuoteString))
               .Skip((filter.CurrentPage - 1) * filter.PageSize)
                .Take(filter.PageSize);

        }

        public IEnumerable<Quote> GetRandomQuotes(int count)
        {
            var reandomQuotes = _unitOfWork.QuoteRepository.GetAll().OrderBy(r => Guid.NewGuid()).Take(count);
            return reandomQuotes;
        }

        public Quote Update(UpdateQuoteDto createQuoteDto)
        {
            var quoteInDb = _unitOfWork.QuoteRepository.Get(createQuoteDto.Id);
            if (quoteInDb == null)
            {
                throw new EntryPointNotFoundException();
            }
            var quote = _mapper.Map<Quote>(createQuoteDto);
            quoteInDb.AuthorId = createQuoteDto.AuthorId;
            quoteInDb.QuoteString = createQuoteDto.QuoteString;
            var quoteAdded = _unitOfWork.QuoteRepository.Update(quote);
            return quoteAdded;
        }
    }
}
