using Newtonsoft.Json;

namespace Syn.Client.Services;
public class WebApiService : IWebApiService
{
	private readonly HttpClient _http;
	private readonly ILogger<WebApiService> _logger;
	private readonly JsonSerializerSettings _settings = new()
	{
		NullValueHandling = NullValueHandling.Ignore,
	};

	public WebApiService(IHttpClientFactory httpClientFactory, ILogger<WebApiService> logger)
	{
		_http = httpClientFactory.CreateClient("Syn.ServerAPI");
		_logger = logger;
	}

	public async Task<string> Get(string url)
	{
		try
		{
			var response = await _http.GetAsync(url);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
		}
		catch (Exception)
		{
			_logger.LogError("Get Request Failed For {url}", url);
			throw;
		}
	}

	public async Task<T?> Get<T>(string url)
	{
		try
		{
			var response = await _http.GetAsync(url);
			response.EnsureSuccessStatusCode();
			var str = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(str, _settings);
		}
		catch (Exception)
		{
			_logger.LogError("Get<{T}> Request Failed For {url}", nameof(T), url);
			throw;
		}
	}
}
