using Entities;

namespace Services
{
    public interface IUserService
    {
        Task DeleteAsync(int id);
        IEnumerable<string> Get();
        Task<User?> GetAsync(int id);
        Task<User> LoginAsync(UserLogin loginUser);
        Task<User> PostAsync(User user);
        Task PutAsync(int id, User userToUpdate);
    }
}