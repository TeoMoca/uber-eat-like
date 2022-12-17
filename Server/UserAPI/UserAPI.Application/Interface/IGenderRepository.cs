using UserAPI.Domain;

namespace UserAPI.Application.Interface;

public interface IGenderRepository
{
    Task<bool> AddAsync(Gender gender);
    Task UpdateAsync(Gender genderUpdated);
    Task DeleteAsync(int genderId);
}