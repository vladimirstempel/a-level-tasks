using System.Collections.ObjectModel;
using System.Text;
using Microsoft.VisualBasic;

namespace Logger;

public sealed class Logger
{
    private static Logger _instance = null;
    private readonly string _logsDir = ".\\logs\\";
    private readonly string _fileExtension = ".txt";
    private Dictionary<Level, Collection<string>> Logs = new Dictionary<Level, Collection<string>>();

    private Logger()
    {
    }

    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }

            return _instance;
        }
    }

    public void Write(Level logLevel, string message)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder
            .Append($"{DateTime.Now:yyyy-MM-dd hh:mm:ss}: ")
            .Append($"{(Level)logLevel}: ")
            .Append(message)
            .AppendLine();

        Console.Write(stringBuilder.ToString());

        this.SaveLog(logLevel, stringBuilder.ToString());
    }

    public Dictionary<Level, Collection<string>> GetLogs()
    {
        return this.Logs;
    }

    public string GetLogsAsText(Level level)
    {
        if (this.Logs.TryGetValue(level, out var logs))
        {
            return string.Join("", logs);
        }
        
        return "";
    }

    public void WriteToFile(Level level)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder
            .Append(this._logsDir)
            .Append($"{level}")
            .Append(this._fileExtension);

        if (!Directory.Exists(this._logsDir))
        {
            Directory.CreateDirectory(this._logsDir);
        }
        
        File.WriteAllText(stringBuilder.ToString(), this.GetLogsAsText(level));
    }

    private void SaveLog(Level logLevel, string log)
    {
        if (this.Logs.TryGetValue(logLevel, out var logs))
        {
            logs.Add(log);
            
            this.Logs.TryAdd(logLevel, logs);
        }
        else
        {
            var initialLogs = new Collection<string>();
            
            initialLogs.Add(log);
            
            this.Logs.Add(logLevel, initialLogs);
        }
    }
}