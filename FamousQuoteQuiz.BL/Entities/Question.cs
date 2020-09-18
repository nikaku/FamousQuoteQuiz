using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Entities
{
    public class Question
    {
        public Question()
        {
            QuestionsGames = new List<GameQuestions>();
            EstimatedAnswers = new List<QuestionAuthors>();
        }

        public int Id { get; set; }
        public Quote Quote { get; set; }
        public int QuoteId { get; set; }
        public Author Answer { get; set; }
        public int AnswerId { get; set; }
        public ICollection<GameQuestions> QuestionsGames { get; set; }   
        public ICollection<QuestionAuthors> EstimatedAnswers { get; set; }

    }
}
