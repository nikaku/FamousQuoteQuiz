using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Dtos.QuoteDtos
{
    public class UpdateQuoteDto
    {
        public int Id { get; set; }
        public string QuoteString { get; set; }
        public int AuthorId { get; set; }
    }
}
