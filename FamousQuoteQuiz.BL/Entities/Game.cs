using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Entities
{
    public class Game
    {
        public Game()
        {
            GameQuestions = new List<GameQuestions>();
        }
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public GameMode Mode { get; set; }
        public ICollection<GameQuestions> GameQuestions { get; set; }

    }
}
