using AutoMapper;
using FamousQuoteQuiz.BL.Dtos.AuthorDtos;
using FamousQuoteQuiz.BL.Dtos.QuestionDto;
using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.AutoMapperProfiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<GetQuestionDto, Question>();
            CreateMap<GetAuthorDto, QuestionAuthors>()
                .ForMember(x=>x.AuthorId, opt=>opt.MapFrom(x=>x.Id));
        }
    }
}
