using Entities;
using Repository;
using System.Text.Json;


namespace Services
{
    public class UserService
    {
        UserRepository _userRepository = new UserRepository();

        public IEnumerable<string> Get()
        {
            return _userRepository.Get();
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public User Post(User user)
        {
            return _userRepository.Post(user);
        }

        public User Login(UserLogin loginUser)
        {
            return _userRepository.Login(loginUser);
        }

        public void Put(int id, User userToUpdate)
        {
            _userRepository.Put(id, userToUpdate);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
