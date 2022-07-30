using Syn.Data.Entities;

namespace Syn.Data;

public class AppRepository : IAppRepository
{
    private readonly ApplicationDbContext _context;

    public AppRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Feed> Feeds => _context.Feeds;

    #region CRUD

    public ValueTask<T?> Get<T>(int id) where T : BaseEntityWithIntId
        => _context.Set<T>().FindAsync(id);

    public async Task<int> Insert<T>(T entity) where T : BaseEntity
    {
        await _context.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update<T>(T entity) where T : BaseEntity
    {
        _context.Update(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete<T>(T entity) where T : BaseEntity
    {
        _context.Remove(entity);
        return await _context.SaveChangesAsync();
    }

    #endregion
}
