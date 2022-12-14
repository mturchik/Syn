namespace Syn.Shared.Helpers;
public struct CacheAccess
{
	public const string DefaultPrefix = "DefaultCache";

	public static string GetKey(CacheKey key) => $"{DefaultPrefix}.{key}";
	public static string GetKey(CacheKey key, string prefix) => $"{prefix ?? DefaultPrefix}.{key}";
}

public enum CacheKey
{
	FEEDS_SUBSCRIPTIONS = 1
}