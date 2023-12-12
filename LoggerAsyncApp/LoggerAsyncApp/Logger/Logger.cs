using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using LoggerAsyncApp.Config;

namespace LoggerAsyncApp.Logger;

public sealed class Logger : ILogger
{
    private readonly IConfig _config;
    private string LogName => $"{DateTime.Now:ddMMyyyy_hhmmss_fffff}{_config.FileExtension}";
    private string BackupName => $"Backup_{DateTime.Now:ddMMyyyy_hhmmss_fffff}{_config.ArchiveExtension}";

    public event Action<string> OnLogBackup;

    public Logger(IConfig config)
    {
        _config = config;
    }

    public async Task WriteLog(string log)
    {
        if (!Directory.Exists(_config.LogDir))
        {
            Directory.CreateDirectory(_config.LogDir);
        }

        await File.WriteAllTextAsync($"{_config.LogDir}{LogName}", log);

        var logsCount = Directory.GetFiles(_config.LogDir).Length;

        if (logsCount > 0 && logsCount % _config.BackupAfterEntries == 0)
        {
            await BackupLogs(BackupName);
        }
    }

    private async Task BackupLogs(string backupName)
    {
        OnLogBackup?.Invoke(backupName);

        if (!Directory.Exists(_config.BackupDir))
        {
            Directory.CreateDirectory(_config.BackupDir);
        }

        var files = Directory.GetFiles(_config.LogDir);

        await Task.Run(() =>
        {
            using ZipArchive zip = ZipFile.Open($"{_config.BackupDir}{backupName}", ZipArchiveMode.Create);
            foreach (var file in files)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        });
    }
}