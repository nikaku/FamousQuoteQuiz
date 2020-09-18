using FamousQuoteQuiz.BL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public IQuoteRepository QuoteRepository { get; }
        public IGameRepositiry GameRepositiry { get; }
        public IQuestinRepository QuestionRepository { get; }
        void SaveChanges();
        void Dispose();
    }
}
