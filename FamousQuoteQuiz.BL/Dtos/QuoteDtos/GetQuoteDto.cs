using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Dtos.QuoteDtos
{
    public class GetQuoteDto
    {
        public int Id { get; set; }
        public string QuoteString { get; set; }
        public int AuthorId { get; set; }
    }
}
