using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Filters
{
    public class QuoteFilter
    {
        public QuoteFilter()
        {
            PageSize = 50;
        }

        public int? Id { get; set; }
        public string? QuoteString { get; set; }
        public int? AuthorId { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
