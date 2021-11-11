using System.Reflection;

namespace BlazorBeast.Shared.Versioning;

public record AppVersion
{
    public string Version { get; }

    public AppVersion(string? version)
    {
        Version = version ?? "Unknown"; 
    }
    public AppVersion() : this("Unknown") { }
    
    public static AppVersion FromEntryAssembly()
    {
        return new AppVersion(Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version);
    }
}