using AppDev.Domain;

namespace AppDev.Applications.Interface;

public interface IUserRepository
{
    Task<List<User>> AllUserAsync();
    Task<Guid> AddUserAsync(User user);
}