using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Entities
{
    public class Quote
    {
        public int Id { get; set; }
        public string QuoteString { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
