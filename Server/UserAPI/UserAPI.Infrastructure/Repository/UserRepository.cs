using Microsoft.EntityFrameworkCore;
using UserAPI.Application.Interface;
using UserAPI.Domain;

namespace UserAPI.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly UberEatContext _context;

    public UserRepository(UberEatContext context){
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> AllAsync()
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    public async Task DeleteAsync(User user)
    {
         _context.Users.Remove(user);
         await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User UserUpdated)
    {
        var user = await _context.Users.FirstOrDefaultAsync(p => p.Id == UserUpdated.Id);
        user = UserUpdated;
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    
    
}