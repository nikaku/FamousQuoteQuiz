using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
