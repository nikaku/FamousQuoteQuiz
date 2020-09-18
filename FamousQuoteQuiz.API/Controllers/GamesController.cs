using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameService _gameService;

        public GamesController(IUnitOfWork unitOfWork, IGameService gameService)
        {
            _unitOfWork = unitOfWork;
            _gameService = gameService;
        }

        [HttpPost]
        public IActionResult CreateGame([FromQuery] GameSettings settings)
        {
            var game = _gameService.GenerateGame(settings);
            return Ok(game);
        }

    }
}
