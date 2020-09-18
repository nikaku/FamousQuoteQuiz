using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamousQuoteQuiz.BL.Dtos.UserDtos;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;


        public UsersController(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }


        [HttpPost]
        public IActionResult Register([FromBody] CreateUserDto userDto)
        {
            try
            {
                var userAdded = _userService.Create(userDto);
                return CreatedAtAction(nameof(Get), new { id = userAdded.Id }, userAdded.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usersDtos = _userService.GetAll();
            Request.HttpContext.Response.Headers.Add("Total-Count", usersDtos.Count().ToString());
            return Ok(usersDtos);
        }



        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                // save
                _userService.Update(updateUserDto, updateUserDto.password);
                return Accepted();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
