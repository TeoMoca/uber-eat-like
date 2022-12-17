using Microsoft.EntityFrameworkCore;
using UserAPI.Application.Interface;
using UserAPI.Domain;

namespace UserAPI.Infrastructure.Repository;

public class GenderRepository : IGenderRepository
{
    private readonly UberEatContext _uberEatContext;

    public GenderRepository(UberEatContext uberEatContext)
    {
        _uberEatContext = uberEatContext;
    }

    public async Task<bool> AddAsync(Gender gender)
    {
        await _uberEatContext.Genders.AddAsync(gender);
        await _uberEatContext.SaveChangesAsync();

        return true;
    }

    public async Task UpdateAsync(Gender genderUpdated)
    {
        var gender = await _uberEatContext.Genders.FirstOrDefaultAsync(p => p.Id == genderUpdated.Id);
        gender = genderUpdated;
        _uberEatContext.Entry(gender).State = EntityState.Modified;
        await _uberEatContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int genderId)
    {
        var gender = await _uberEatContext.Genders.Where(p => p.Id == genderId).FirstOrDefaultAsync();
        _uberEatContext.Genders.Remove(gender);
        await _uberEatContext.SaveChangesAsync();
    }
}