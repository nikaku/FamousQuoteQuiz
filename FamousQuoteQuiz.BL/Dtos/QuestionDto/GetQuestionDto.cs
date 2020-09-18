using FamousQuoteQuiz.BL.Dtos.AuthorDtos;
using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Dtos.QuestionDto
{
    public class GetQuestionDto
    {
        public GetQuestionDto()
        {
            EstimatedAnswers = new List<GetAuthorDto>();
        }
        public int Id { get; set; }
        public int QuoteId { get; set; }
        public int AnswerId { get; set; }
        public ICollection<GetAuthorDto> EstimatedAnswers { get; set; }
    }
}
