using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Entities
{
    public class GameQuestions
    {        
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
