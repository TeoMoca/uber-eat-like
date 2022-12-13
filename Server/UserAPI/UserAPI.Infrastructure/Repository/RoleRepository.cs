using Microsoft.EntityFrameworkCore;
using UserAPI.Application.Interface;
using UserAPI.Domain;

namespace UserAPI.Infrastructure.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly UberEatContext _context;

    public RoleRepository(UberEatContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Role role)
    {
        _context.Remove(role);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Role>> AllAsync()
    {
        var roles = await _context.Roles.ToListAsync();

        return roles;
    }

    public async Task UpdateAsync(Role roleUpdated)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(p => p.Id == roleUpdated.Id);
        role = roleUpdated;
        _context.Entry(role).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}