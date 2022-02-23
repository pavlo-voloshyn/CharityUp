using DataAccess.Contracts;
using DataAccess.Persistence;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private new readonly AccountDbContext _context;

    public UserRepository(AccountDbContext context) : base(context)
    {
        _context = context;
    }

    public async override Task<List<User>> GetAllAsync()
    {
        return await _context.Set<User>()
            .Include(u => u.Gender)
            .AsNoTracking()
            .ToListAsync();
    }

    public async override Task<User> GetByIdAsync<Guid>(Guid id)
    {
        return await _context.Set<User>()
            .Include(u => u.Gender)
            .FirstOrDefaultAsync(u => u.Id.Equals(id));
    }

    public override IQueryable<User> GetWhere(Func<User, bool> predicate)
    {
        return _context.Set<User>()
            .Include(u => u.Gender)
            .Where(predicate)
            .AsQueryable();
    }
}
