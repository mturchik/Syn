namespace Syn.Data;

public class AppDataService : IAppDataService
{
    private readonly IAppRepository _appRepository;
    private readonly ICacheService _cacheService;

    public AppDataService(IAppRepository appRepository, ICacheService cacheService)
    {
        _appRepository = appRepository;
        _cacheService = cacheService;
    }

    public IEnumerable<T> Get<T>() where T : BaseEntity
        => _cacheService.GetOrCreate(nameof(T), () => _appRepository.Get<T>());

    public Task<int> Insert<T>(T entity) where T : BaseEntity
    {
        _cacheService.Remove(nameof(T));
        return _appRepository.Insert(entity);
    }

    public Task<int> Update<T>(T entity) where T : BaseEntity
    {
        _cacheService.Remove(nameof(T));
        return _appRepository.Update(entity);
    }

    public Task<int> Delete<T>(T entity) where T : BaseEntity
    {
        _cacheService.Remove(nameof(T));
        return _appRepository.Delete(entity);
    }
}
