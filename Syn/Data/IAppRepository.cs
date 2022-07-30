using Syn.Data.Entities;

namespace Syn.Data;

public interface IAppRepository
{
    IQueryable<Feed> Feeds { get; }

    ValueTask<T?> Get<T>(int id) where T : BaseEntityWithIntId;
    Task<int> Insert<T>(T entity) where T : BaseEntity;
    Task<int> Update<T>(T entity) where T : BaseEntity;
    Task<int> Delete<T>(T entity) where T : BaseEntity;
}