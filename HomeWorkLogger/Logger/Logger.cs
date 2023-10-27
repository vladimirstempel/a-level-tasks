using System.Collections.ObjectModel;
using System.Text;

namespace Logger;

public sealed class Logger
{
    private static readonly Logger instance = new();

    private readonly string _logsDir = ".\\logs\\";
    private readonly string _fileExtension = ".txt";
    private Dictionary<Level, Collection<string>> Logs = new();

    static Logger()
    {
    }

    private Logger()
    {
    }

    public static Logger Instance => instance;

    public void Write(Level logLevel, string message)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder
            .Append($"{DateTime.Now:yyyy-MM-dd hh:mm:ss}: ")
            .Append($"{(Level)logLevel}: ")
            .Append(message)
            .AppendLine();

        Console.Write(stringBuilder.ToString());

        SaveLog(logLevel, stringBuilder.ToString());
    }

    public Dictionary<Level, Collection<string>> GetLogs()
    {
        return Logs;
    }

    public string GetLogsAsText(Level level)
    {
        if (Logs.TryGetValue(level, out var logs))
        {
            return string.Join("", logs);
        }

        return "";
    }

    public void WriteLogsToFile(Level level)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder
            .Append(_logsDir)
            .Append(level.ToString())
            .Append(_fileExtension);

        if (!Directory.Exists(_logsDir))
        {
            Directory.CreateDirectory(_logsDir);
        }

        File.WriteAllText(stringBuilder.ToString(), GetLogsAsText(level));
    }

    private void SaveLog(Level logLevel, string log)
    {
        if (Logs.TryGetValue(logLevel, out var logs))
        {
            logs.Add(log);

            Logs.TryAdd(logLevel, logs);
        }
        else
        {
            var initialLogs = new Collection<string>();

            initialLogs.Add(log);

            Logs.Add(logLevel, initialLogs);
        }
    }
}