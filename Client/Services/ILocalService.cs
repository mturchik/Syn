namespace Syn.Client.Services;

public interface ILocalService
{
	ValueTask<T> Get<T>(string key);
	ValueTask Remove(string key);
	ValueTask Set<T>(string key, T data);
}
