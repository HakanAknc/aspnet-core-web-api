using UserManagementApi.DTOs;
using UserManagementAPI.Models;
using UserManagementAPI.Repositories;

namespace UserManagementAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<List<GetUserDTO>> GetAllUserAsync()
        {
            var users =await _userRepository.GetAllUsersAsync();
            return users.Select(user => new GetUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Job = user.Job,
                BirthPlace = user.BirthPlace,
                BirthYear = user.BirthYear
            }).ToList();
        }

        public async Task CreateUserAsync(CreateUserDTO userDTO)
        {
            var user = new User
            {
                Tc = userDTO.Tc,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                BirthYear = userDTO.BirthYear,
                BirthPlace = userDTO.BirthPlace,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Job = userDTO.Job,
                Salary = userDTO.Salary,
            };
            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(string id, UpdateUserDTO userDTO)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return;

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Job = userDTO.Job;
            user.Salary = userDTO.Salary;
            
            await _userRepository.UpdateUserAsync(id, user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeletUserAsync(id);
        }
    }
}
