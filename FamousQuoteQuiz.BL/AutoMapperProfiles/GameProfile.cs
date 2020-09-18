using AutoMapper;
using FamousQuoteQuiz.BL.Dtos.GameDtos;
using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.AutoMapperProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GetGameDto, Game>();
            CreateMap<Game, GetGameDto>();
        }
    }
}
