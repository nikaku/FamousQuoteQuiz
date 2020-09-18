using AutoMapper;
using FamousQuoteQuiz.BL.Dtos;
using FamousQuoteQuiz.BL.Dtos.AuthorDtos;
using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamousQuoteQuiz.DB.Implementations.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Author Create(CreateAuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            var authorAdded = _unitOfWork.AuthorRepository.Add(author);
            return authorAdded;
        }

        public GetAuthorDto Get(int id)
        {
            var author = _unitOfWork.AuthorRepository.Get(id);
            GetAuthorDto getAuthorDto = _mapper.Map<GetAuthorDto>(author);
            return getAuthorDto;
        }

        public IEnumerable<GetAuthorDto> GetAll()
        {
            var authors = _unitOfWork.AuthorRepository.GetAll();
            var getAuthors = _mapper.Map<IList<GetAuthorDto>>(authors);
            return getAuthors;
        }

        public IEnumerable<GetAuthorDto> GetRandomAuthors(int count)
        {
            var reandomAuthors = _unitOfWork.AuthorRepository.GetAll().OrderBy(r => Guid.NewGuid()).Take(count);
            return _mapper.Map<IList<GetAuthorDto>>(reandomAuthors);
        }
    }
}
