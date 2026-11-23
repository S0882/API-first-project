using System.Text.Json;
using Entities;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        static string FilePath = "..\\Repository\\User.txt";

        public IEnumerable<string> Get()
        {
            return new string[] { "Shifrah", "Tamar" };
        }

        public async Task<User?> GetAsync(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User? user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user != null && user.Id == id)
                        return user;
                }
            }
            return null;
        }

        public async Task<User> PostAsync(User user)
        {
            //int numberOfUsers = await System.IO.File.ReadLinesAsync(FilePath).Count();

            int numberOfUsers = File.Exists(FilePath)
            ? (await File.ReadAllLinesAsync(FilePath)).Length
            : 0;


            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            await System.IO.File.AppendAllTextAsync(FilePath, userJson +
            Environment.NewLine);
            return user;
        }

        public async Task<User> LoginAsync(UserLogin loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User? user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user != null && user.UserEmail == loginUser.UserLogEmail && user.Password ==
                    loginUser.LogPassword)
                        return user;
                }
            }

            return null;
        }

        public async Task PutAsync(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(FilePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                    break;
                }
            }
            if (textToReplace != string.Empty)
            {
                userToUpdate.Id = id;
                string text = await System.IO.File.ReadAllTextAsync(FilePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(FilePath, text);
            }
        }

        public async Task DeleteAsync(int id)
        {
        }
    }
}
