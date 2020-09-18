namespace FamousQuoteQuiz.BL.Dtos.UserDtos
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
