namespace Syn.Client.Services;
public interface IWebApiService
{
	Task<string> Get(string url);
	Task<T?> Get<T>(string url);
}