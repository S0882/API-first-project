using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        IEnumerable<string> Get();
        Task<User?> GetAsync(int id);
        Task<User> LoginAsync(UserLogin loginUser);
        Task<User> PostAsync(User user);
        Task PutAsync(int id, User userToUpdate);
        Task DeleteAsync(int id);
    }
}