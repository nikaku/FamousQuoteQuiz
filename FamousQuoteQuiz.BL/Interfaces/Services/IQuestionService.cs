using FamousQuoteQuiz.BL.Dtos.QuestionDto;
using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Interfaces.Services
{
    public interface IQuestionService
    {
        public IEnumerable<GetQuestionDto> GenerateBinaryQuestions(int questionsCount);
        public IEnumerable<GetQuestionDto> GenerateMultipleChoiseQuestions(int questionsCount, int estimatedAnswersCount);
    }
}
