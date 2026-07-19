using Microsoft.Extensions.Configuration;
using No1.asp.NET.Commons.Exceptions;
using No1.asp.NET.Commons.Utility;
using No1.Commons.Extensions;

namespace No1.asp.NET.Commons.Extensions;

public static class ConfigurationExtensions
{
	public static T? GetOptionalConfig<T>(this IConfiguration? configuration) => (configuration ?? ConfigurationUtility.Configurations).GetSection(typeof(T).Name).Get<T>();

	public static T GetNeededConfig<T>(this IConfiguration? configuration) => configuration.GetOptionalConfig<T>() ?? throw new ConfigurationException<T>();

	public static string[] ReadStringArray(this IConfigurationSection? section) {
		if (section == null || !section.Exists()) {
			return [];
		}

		var children = section.GetChildren().Select(c => c.Value).Where(v => !string.IsNullOrEmpty(v)).ToArray();
		if (children.Length > 0) {
			return children!;
		} else if (section.Value.IsUsable()) {
			// single value provided as string; allow comma-separated list
			return [.. section.Value.Split([','], StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).Where(s => s.Length > 0)];
		} else {
			return [];
		}
	}
}