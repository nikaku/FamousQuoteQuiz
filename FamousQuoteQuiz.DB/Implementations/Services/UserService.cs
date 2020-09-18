using AutoMapper;
using FamousQuoteQuiz.BL.Dtos.UserDtos;
using FamousQuoteQuiz.BL.Entities;
using FamousQuoteQuiz.BL.Interfaces;
using FamousQuoteQuiz.BL.Interfaces.Repositories;
using FamousQuoteQuiz.BL.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace FamousQuoteQuiz.DB.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _unitOfWork.UserRepository.GetByUserName(username);

            // check if username exists
            if (user == null)
                return null;

            //check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public GetUserDto Create(CreateUserDto createuserDto)
        {
            if (string.IsNullOrWhiteSpace(createuserDto.password))
                throw new Exception("Password Is Required");

            if (_unitOfWork.UserRepository.GetByUserName(createuserDto.UserName) != null)
                throw new Exception(@$"User {createuserDto.UserName} Already Exists");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(createuserDto.password, out passwordHash, out passwordSalt);

            var user = _mapper.Map<User>(createuserDto);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var userAdded = _unitOfWork.UserRepository.Add(user);
            var getUserDto = _mapper.Map<GetUserDto>(userAdded);
            _unitOfWork.SaveChanges();
            return getUserDto;
        }

        public GetUserDto Get(int id)
        {
            var user = _unitOfWork.UserRepository.Get(id);
            return _mapper.Map<GetUserDto>(user);
        }

        public IEnumerable<GetUserDto> GetAll()
        {
            var user = _unitOfWork.UserRepository.GetAll();
            return _mapper.Map<IList<GetUserDto>>(user);
        }

        public void Update(UpdateUserDto userParam, string password = null)
        {
            User user = _unitOfWork.UserRepository.Get(userParam.Id);
            if (user == null)
                throw new Exception("Not Found");

            if (userParam.UserName != user.UserName)
            {
                // username has changed so check if the new username is already taken
                if (_unitOfWork.UserRepository.Find(x => x.UserName == userParam.UserName) != null)
                    throw new Exception("User " + userParam.UserName + " Aldready Exists");
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.UserName = userParam.UserName;
            user.Email = userParam.Email;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            var res = _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();

        }

        public User Disable(int id)
        {
            var userToDisable = _unitOfWork.UserRepository.Get(id);
            if (userToDisable == null)
                throw new Exception("Not Found");
            userToDisable.IsActive = false;
            _unitOfWork.UserRepository.Update(userToDisable);
            _unitOfWork.SaveChanges();
            return userToDisable;
        }

     
    }
}
