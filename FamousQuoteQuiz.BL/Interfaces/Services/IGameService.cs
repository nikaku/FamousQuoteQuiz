using FamousQuoteQuiz.BL.Dtos.AuthorDtos;
using FamousQuoteQuiz.BL.Dtos.GameDtos;
using FamousQuoteQuiz.BL.Dtos.QuestionDto;
using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.Interfaces.Services
{
    public interface IGameService
    {
        GetGameDto GenerateGame(GameSettings settings);
        GetQuestionDto GetGameNextQuestion(int GameId);
        QuestionResult AnswerToQuestion(int QuestionId, int authorId);
    }
}
