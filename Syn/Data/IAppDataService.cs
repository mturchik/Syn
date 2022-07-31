namespace Syn.Data;

public interface IAppDataService
{
    Task<int> Delete<T>(T entity) where T : BaseEntity;
    IEnumerable<T> Get<T>() where T : BaseEntity;
    Task<int> Insert<T>(T entity) where T : BaseEntity;
    Task<int> Update<T>(T entity) where T : BaseEntity;
}