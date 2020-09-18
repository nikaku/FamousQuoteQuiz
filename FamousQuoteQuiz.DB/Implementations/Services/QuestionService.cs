using AutoMapper;
using FamousQuoteQuiz.BL.Dtos.AuthorDtos;
using FamousQuoteQuiz.BL.Dtos.QuestionDto;
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
    public class QuestionService : IQuestionService
    {

        private readonly IQuoteService _quoteService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper, IQuoteService quoteService, IAuthorService authorService)
        {
            _quoteService = quoteService;
            _authorService = authorService;
            _mapper = mapper;
        }
        public IEnumerable<GetQuestionDto> GenerateMultipleChoiseQuestions(int questionsCount, int estimatedAnswersCount)
        {
            var randomAuthorsList = _authorService.GetRandomAuthors(questionsCount * estimatedAnswersCount);
            var randomQuotesList = _quoteService.GetRandomQuotes(questionsCount);

            var randomQuotes = new Stack<Quote>(randomQuotesList);
            var randomAuthors = new Stack<GetAuthorDto>(randomAuthorsList);

            var binaryQuestions = new List<GetQuestionDto>();


            while (randomQuotes.Count > 0)
            {
                var quote = randomQuotes.Pop();
                GetQuestionDto question = new GetQuestionDto
                {
                    QuoteId = quote.Id
                };

                for (int i = 0; i < estimatedAnswersCount; i++)
                {
                    var author = randomAuthors.Pop();
                    question.EstimatedAnswers.Add(author);
                }

                binaryQuestions.Add(question);
            }
            return binaryQuestions;
        }

        public IEnumerable<GetQuestionDto> GenerateBinaryQuestions(int questionsCount)
        {
            var randomAuthorsList = _authorService.GetRandomAuthors(questionsCount);
            var randomQuotesList = _quoteService.GetRandomQuotes(questionsCount);

            var randomQuotes = new Stack<Quote>(randomQuotesList);
            var randomAuthors = new Stack<GetAuthorDto>(randomAuthorsList);

            var binaryQuestions = new List<GetQuestionDto>();


            while (randomQuotes.Count > 0)
            {
                var quote = randomQuotes.Pop();
                GetQuestionDto question = new GetQuestionDto
                {
                    QuoteId = quote.Id
                };
                var author = randomAuthors.Pop();
                question.EstimatedAnswers.Add(author);
                binaryQuestions.Add(question);
            }
            return binaryQuestions;
        }


    }
}
