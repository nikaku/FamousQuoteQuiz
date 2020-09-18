using FamousQuoteQuiz.BL.Dtos.QuoteDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Dtos.AuthorDtos
{
    public class GetAuthorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
    }
}
