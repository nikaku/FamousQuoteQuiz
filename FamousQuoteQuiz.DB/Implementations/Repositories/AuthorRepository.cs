using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamousQuoteQuiz.DB.Implementations.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DataContext context) : base(context)
        {

        }

        public new Author Get(int id)
        {
            return AuthorContext.Authors.Include(x => x.Quotes).FirstOrDefault(x=>x.Id == id);
        }
        public new IEnumerable<Author> GetAll()
        {
            return AuthorContext.Authors.Include(x => x.Quotes);
        }

        private DataContext AuthorContext => Context as DataContext;
    }
}
