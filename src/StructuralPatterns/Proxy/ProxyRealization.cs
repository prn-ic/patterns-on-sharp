namespace Proxy;

public class User 
{
    public string? Name { get; set; }
    public string? Password { get; set; }
    public override string ToString()
    {
        return string.Format("Name: {0}; Password: {1}", Name, Password);
    }
}

public class UserTempData
{
    public List<User> Users { get; set; } = new List<User>();
}

public interface IUserSubject
{
    public User GetByName(string name);
    public bool Add(User user);
} 

public class UserRepository : IUserSubject
{
    UserTempData tempData;
    public UserRepository(UserTempData userTempData) =>
        tempData = userTempData;
    public User GetByName(string name)
    {
        return tempData.Users.FirstOrDefault(x => x.Name == name) ?? new User() { Name = "None", Password = "None"};
    }
    public bool Add(User user)
    {
        if (tempData.Users.FirstOrDefault(x => x.Name == user.Name) is not null)
            return false;

        tempData.Users.Add(user);

        return true;
    }
}

public class UserProxy : IUserSubject
{
    List<User> users = new List<User>(); // имитируем кеш
    UserRepository userRepository;
    public UserProxy(UserTempData tempData) =>
        userRepository = new UserRepository(tempData);
    public User GetByName(string name)
    {
        User user = users.FirstOrDefault(x => x.Name == name);
        if (user is null)
        {
            user = userRepository.GetByName(name);
            users.Add(user);
        }

        User tempUser = new User() { Name = user.Name, Password = user.Password };
        tempUser.Password = "******"; // "сокрываем" данные

        return tempUser;
    }
    public bool Add(User user)
    {
        return userRepository.Add(user);
    }
}