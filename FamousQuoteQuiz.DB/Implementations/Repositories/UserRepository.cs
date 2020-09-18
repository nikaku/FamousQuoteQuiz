
using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamousQuoteQuiz.DB.Implementations.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public User GetByUserName(string username)
        {
            return UserContext.Users.FirstOrDefault(x => x.UserName == username);
        }
        private DataContext UserContext => Context as DataContext;
    }
}
