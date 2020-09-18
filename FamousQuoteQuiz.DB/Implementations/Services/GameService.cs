using AutoMapper;
using FamousQuoteQuiz.BL;
using FamousQuoteQuiz.BL.Dtos.AuthorDtos;
using FamousQuoteQuiz.BL.Dtos.GameDtos;
using FamousQuoteQuiz.BL.Dtos.QuestionDto;
using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamousQuoteQuiz.DB.Implementations.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper, IQuestionService questionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _questionService = questionService;
        }   

        public GetGameDto GenerateGame(GameSettings settings)
        {
            GetGameDto game;
            List<GetQuestionDto> gameQuestions;

            gameQuestions = settings.GameMode == GameMode.Binary ? 
                _questionService.GenerateBinaryQuestions(settings.QuestionsCount).ToList() : 
                _questionService.GenerateMultipleChoiseQuestions(settings.QuestionsCount, settings.EstimatedAnswersCount).ToList();        

            game = new GetGameDto
            {
                GameQuestions = gameQuestions,
                Mode = settings.GameMode,
                UserId = 1,
            };
 
            return game;

        }

        public QuestionResult AnswerToQuestion(int QuestionId, int authorId)
        {
            QuestionResult res = new QuestionResult();
            var question = _unitOfWork.QuestionRepository.Get(QuestionId);
            if (question.AnswerId == authorId)
            {
                res.IsCorrect = true;
            }
            res.IsCorrect = false;
            res.Author = _mapper.Map<GetAuthorDto>(question.Quote.Author);
            return res;

        }

        public GetQuestionDto GetGameNextQuestion(int GameId)
        {
            var game = _unitOfWork.GameRepositiry.Get(GameId);
            var nextQuestion = game.GameQuestions.FirstOrDefault(x => x.Question.AnswerId != 0).Question;
            return _mapper.Map<GetQuestionDto>(nextQuestion);
        }
    }
}
