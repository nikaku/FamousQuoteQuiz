using FamousQuoteQuiz.BL.Dtos.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Entities
{
    public class QuestionResult
    {
        public bool IsCorrect { get; set; }
        public GetAuthorDto Author { get; set; }
        public int AuthorId { get; set; }
    }
}
