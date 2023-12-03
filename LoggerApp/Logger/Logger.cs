using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Logger;

public sealed class Logger
{
    private Dictionary<Level, Collection<string>> Logs = new();

    public void Write(Level logLevel, string message)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder
            .Append($"{DateTime.Now:MM/dd/yyyy hh:mm:ss.fff tt}: ")
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