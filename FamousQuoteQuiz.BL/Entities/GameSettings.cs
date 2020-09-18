using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Entities
{
    public class GameSettings
    {
        public GameMode GameMode { get; set; } = GameMode.Binary;
        public int QuestionsCount { get; set; }
        public int EstimatedAnswersCount { get; set; }
    }
}
