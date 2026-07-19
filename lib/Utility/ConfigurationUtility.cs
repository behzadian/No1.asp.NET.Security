using Microsoft.Extensions.Configuration;
using No1.asp.NET.Commons.Exceptions;

namespace No1.asp.NET.Commons.Utility;

public static class ConfigurationUtility
{
	public static IConfiguration Configurations { get; } = new ConfigurationBuilder()
		.AddJsonFile("appsettings.json", optional: true)
		.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
		.AddEnvironmentVariables()
		.Build();

	public static T? GetOptionalConfig<T>() => Configurations.GetSection(typeof(T).Name).Get<T>();

	public static T GetNeededConfig<T>() => GetOptionalConfig<T>() ?? throw new ConfigurationException<T>();
}