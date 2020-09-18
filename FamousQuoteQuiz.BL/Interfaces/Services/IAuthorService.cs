using FamousQuoteQuiz.BL.Dtos;
using FamousQuoteQuiz.BL.Dtos.AuthorDtos;
using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Interfaces.Services
{
    public interface IAuthorService
    {
        Author Create(CreateAuthorDto authorDto);
        GetAuthorDto Get(int id);
        IEnumerable<GetAuthorDto> GetAll();
        IEnumerable<GetAuthorDto> GetRandomAuthors(int count);
    }
}
