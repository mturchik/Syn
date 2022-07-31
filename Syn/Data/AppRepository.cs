namespace Syn.Data;

public class AppRepository : IAppRepository
{
    private readonly ApplicationDbContext _context;

    public AppRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    #region CRUD

    public IEnumerable<T> Get<T>() where T : BaseEntity
        => _context.Set<T>().ToList();

    public async Task<int> Insert<T>(T entity) where T : BaseEntity
    {
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update<T>(T entity) where T : BaseEntity
    {
        _context.Set<T>().Update(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Delete<T>(T entity) where T : BaseEntity
    {
        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync();
    }

    #endregion
}
