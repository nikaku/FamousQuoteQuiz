using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FamousQuoteQuiz.DB.Implementations.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestinRepository
    {
        public QuestionRepository(DataContext context) : base(context)
        {

        }
        private DataContext QuestionContext => Context as DataContext;

    }
}
