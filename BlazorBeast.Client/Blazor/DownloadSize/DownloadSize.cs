namespace BlazorBeast.Client.Blazor.DownloadSize;

public record DownloadSize(string TimeZones, string Dlls, string BlazorWebAssemblyJs, string DotnetJs, string DotnetWasm, string IcudtEfigsDat, string Total);

public record AllDownloadSizes(DownloadSize ReleasePublish, DownloadSize DisableTimeZoneSupport, DownloadSize InvariantGlobalization, DownloadSize ILLinker);