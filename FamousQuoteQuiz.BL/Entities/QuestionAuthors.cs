using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Entities
{
    public class QuestionAuthors
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
