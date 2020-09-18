using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamousQuoteQuiz.BL.Dtos;
using FamousQuoteQuiz.BL.Dtos.AuthorDtos;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorService _authorService;

        public AuthorsController(IUnitOfWork unitOfWork, IAuthorService authorService)
        {
            _unitOfWork = unitOfWork;
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult Create(CreateAuthorDto author)
        {
            var templateInDb = _unitOfWork.AuthorRepository.Find(x => x.FirstName == author.FirstName && x.LastName == author.LastName);
            if (templateInDb != null)
            {
                return Conflict($"Author : {author.FirstName} {author.LastName} Already Exists ");
            }
            var result = _authorService.Create(author);
            _unitOfWork.SaveChanges();
            return Ok(result.Id);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var author = _authorService.Get(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = _authorService.GetAll();
            return Ok(authors);
        }
    }
}
