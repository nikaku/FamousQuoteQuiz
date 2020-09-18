using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string username);
    }

}
