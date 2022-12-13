using UserAPI.Domain;

namespace UserAPI.Application.Interface;

public interface IRoleRepository
{
    Task AddAsync(Role role);
    Task<List<Role>> AllAsync();
    Task DeleteAsync(Role role);
    Task UpdateAsync(Role role);
}