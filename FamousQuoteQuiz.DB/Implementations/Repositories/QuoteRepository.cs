using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.DB.Implementations.Repositories
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        public QuoteRepository(DataContext context) : base(context)
        {
        }

        private DataContext QuoteContext => Context as DataContext;
    }
}
