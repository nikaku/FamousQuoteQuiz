using AutoMapper;
using FamousQuoteQuiz.BL.Dtos.QuoteDtos;
using FamousQuoteQuiz.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.BL.AutoMapperProfiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<CreateQuoteDto, Quote>();
            CreateMap<Quote, GetQuoteDto>();
        }
    }
}
