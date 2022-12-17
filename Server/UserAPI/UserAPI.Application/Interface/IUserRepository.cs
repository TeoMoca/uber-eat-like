using UserAPI.Domain;

namespace UserAPI.Application.Interface;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<List<User>> AllAsync();
    Task DeleteAsync(Guid userId);
    Task UpdateAsync(User UserUpdated);
}