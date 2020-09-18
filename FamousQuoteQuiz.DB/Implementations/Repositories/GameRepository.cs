using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.DB.Implementations.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepositiry
    {
        public GameRepository(DataContext context) : base(context)
        {

        }

        private DataContext GameContext => Context as DataContext;

    }
}
