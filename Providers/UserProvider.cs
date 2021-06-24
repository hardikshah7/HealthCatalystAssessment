using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCatalystAssessment.Data;
using HealthCatalystAssessment.Models;

namespace HealthCatalystAssessment.Providers
{
    public interface IUserProvider
    {
        Task<List<User>> FindUsersByFirstOrLastNameAsync(string searchTerm);
        Task<Guid> CreateUserAsync(UserCreation user);
    }
    public class UserProvider : IUserProvider
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserProvider(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets the list of users that contain first or last names
        /// that match the search term.
        /// </summary>
        /// <param name="searchTerm">First or last name to lookup</param>
        /// <returns>List of users if any, otherwise null.</returns>
        public async Task<List<User>> FindUsersByFirstOrLastNameAsync(string searchTerm)
        {
            var users = await _userRepository.FindByConditionAsync(x => x.FirstName.Contains(searchTerm)
                                                                        || x.LastName.Contains(searchTerm));
            // If no users were found, return null
            if (!users.Any())
            {
                return null;
            }

            return users;
        }

        /// <summary>
        /// Creates a User
        /// </summary>
        /// <param name="user">User object to create</param>
        /// <returns>Id of the new user</returns>
        public async Task<Guid> CreateUserAsync(UserCreation user)
        {
            var userToCreate = _mapper.Map<User>(user);
            await _userRepository.AddAsync(userToCreate);
            return userToCreate.Id;
        }
    }
}
