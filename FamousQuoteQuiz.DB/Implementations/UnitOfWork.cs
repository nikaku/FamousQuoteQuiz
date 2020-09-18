
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Repositories;
using FamousQuoteQuiz.DB.Implementations.Repositories;
using System;


namespace FamousQuoteQuiz.DB.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            UserRepository = new UserRepository(_dataContext);
            AuthorRepository = new AuthorRepository(_dataContext);
            QuoteRepository = new QuoteRepository(_dataContext);
            GameRepositiry = new GameRepository(_dataContext);
            QuestionRepository = new QuestionRepository(_dataContext);
        }
        public IUserRepository UserRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public IQuoteRepository QuoteRepository { get; }
        public IGameRepositiry GameRepositiry { get; }
        public IQuestinRepository QuestionRepository { get; }
        

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
    }
}
