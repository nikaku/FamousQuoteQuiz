using FamousQuoteQuiz.BL.Dtos.QuestionDto;
using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Dtos.GameDtos
{
    public class GetGameDto
    {
        public GetGameDto()
        {
            GameQuestions = new List<GetQuestionDto>();
        }
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public GameMode Mode { get; set; }
        public ICollection<GetQuestionDto> GameQuestions { get; set; }
    }
}
