using System.Text.Json;
using Entities;

namespace Repository
{
    public class UserRepository
    {
        static string FilePath = "D:\\שנה ב\\WEB-API\\WebAPI\\Repository\\User.txt";

        public IEnumerable<string> Get()
        {
            return new string[] { "Shifrah", "Tamar" };
        }

        public User Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return user;
                }
            }
            return null;
        }

        public User Post(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson +
            Environment.NewLine);
            return user;
        }

        public User Login(UserLogin loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserEmail == loginUser.UserLogEmail && user.Password ==
                    loginUser.LogPassword)
                        return user;
                }
            }

            return null;
        }

        public void Put(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(FilePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
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
                string text = System.IO.File.ReadAllText(FilePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(FilePath, text);
            }
        }

        public void Delete(int id)
        {
        }
    }
}
