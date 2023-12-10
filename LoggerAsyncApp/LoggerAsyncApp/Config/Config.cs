using Microsoft.Extensions.Configuration;

namespace LoggerAsyncApp.Config;

public sealed class Config : IConfig
{
    private readonly IConfiguration _config;

    public int BackupAfterEntries =>
        int.TryParse(_config.GetSection("BackupAfterEntries").Value, out var result)
            ? result
            : default;

    public string BackupDir => _config.GetSection("BackupDir").Value;
    public string LogDir => _config.GetSection("LogDir").Value;
    public string FileExtension => _config.GetSection("FileExtension").Value;
    public string ArchiveExtension => _config.GetSection("ArchiveExtension").Value;

    public Config(IConfiguration config)
    {
        _config = config;
    }
}