using System;
using Template.Common.Exceptions;
using Template.Entities.DbModels;
using Template.Repositories.Repositories;

namespace Template.Services.Services
{
    public interface IUserService
    {
        int Add(string firstName, string surname);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Add(string firstName, string surname)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(surname))
            {
                throw new TemplateException(ExceptionCode.User.EmptyNameOrSurname);
            }

            var dbUser = _userRepository.GetByNameAndSurname(firstName, surname);

            if (dbUser != null)
            {
                throw new TemplateException(ExceptionCode.User.DuplicateUser);
            }

            var userEntry = new User() {
                Name = firstName,
                Surname = surname
            };

            var result = _userRepository.Add(userEntry);

            return result;
        }
    }
}