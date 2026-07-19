namespace No1.asp.NET.Commons.Exceptions;

[System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1128:Put constructor initializers on their own line", Justification = "Will be fixed in .editorconfig")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Skip")]
public class ConfigurationException<T>() : Exception($"Configuration of type {typeof(T).Name} could not be found. Please add a key named `{typeof(T).Name}` in `app.settings.json` or `app.settings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json` file.");