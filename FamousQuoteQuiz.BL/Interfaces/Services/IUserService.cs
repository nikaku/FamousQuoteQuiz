using FamousQuoteQuiz.BL.Dtos.UserDtos;
using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Interfaces.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        GetUserDto Create(CreateUserDto user);
        GetUserDto Get(int id);
        IEnumerable<GetUserDto> GetAll();
        User Disable(int id);
        void Update(UpdateUserDto userParam, string password = null);
    }
}
