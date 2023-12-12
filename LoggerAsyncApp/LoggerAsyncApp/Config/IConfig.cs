namespace LoggerAsyncApp.Config;

public interface IConfig
{
    public int BackupAfterEntries { get; }
    public string BackupDir { get; }
    public string LogDir { get; }
    public string FileExtension { get; }
    public string ArchiveExtension { get; }
}