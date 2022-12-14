namespace Syn.Client.Services;

public class LocalService : ILocalService
{
	private readonly ILocalStorageService _localStorage;

	public LocalService(ILocalStorageService localStorage)
	{
		_localStorage = localStorage;
	}

	public ValueTask<T> Get<T>(string key) => _localStorage.GetItemAsync<T>(key);
	public ValueTask Set<T>(string key, T data) => _localStorage.SetItemAsync(key, data);
	public ValueTask Remove(string key) => _localStorage.RemoveItemAsync(key);
}
