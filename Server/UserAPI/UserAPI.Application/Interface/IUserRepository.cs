using UserAPI.Domain;

namespace UserAPI.Application.Interface;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<List<User>> AllAsync();
    Task DeleteAsync(User user);
    Task UpdateAsync(User UserUpdated);
}