namespace Syn.Services
{
    public interface ICacheService
    {
        T GetOrCreate<T>(string key, Func<T> factory);
        void Remove(string key);
    }
}