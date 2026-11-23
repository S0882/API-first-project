using Entities;
using Repository;
using System.Text.Json;


namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> Get()
        {
            return _userRepository.Get();
        }

        public async Task<User?> GetAsync(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<User> PostAsync(User user)
        {
            return await _userRepository.PostAsync(user);
        }

        public async Task<User> LoginAsync(UserLogin loginUser)
        {
            return await _userRepository.LoginAsync(loginUser);
        }

        public async Task PutAsync(int id, User userToUpdate)
        {
            await _userRepository.PutAsync(id, userToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
