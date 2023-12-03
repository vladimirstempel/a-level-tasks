using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger;

public class FileService
{
    private readonly string _logsDir;
    private readonly string _fileExtension;

    private const int MaxFiles = 3;

    public FileService(string logsDir = ".\\Logs\\", string fileExtension = ".txt")
    {
        _logsDir = logsDir;
        _fileExtension = fileExtension;
    }

    public void WriteLogsToFile(Level level, string logs)
    {
        var stringBuilder = new StringBuilder();

        var dirPath = stringBuilder
            .Append(_logsDir)
            .Append($"\\{level.ToString()}\\")
            .ToString();

        var filePath = stringBuilder
            .Append($"{DateTime.Now:MM/dd/yyyy_hh.mm.ss.fff}")
            .Append(_fileExtension)
            .ToString();

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        File.WriteAllText(filePath, logs);
        ProcessOldFiles(dirPath);
    }

    private void ProcessOldFiles(string dirPath)
    {
        if (Directory.Exists(dirPath))
        {
            var files = Directory.GetFiles(dirPath);

            if (files.Length > 3)
            {
                var sortedFiles = files.OrderBy(x => File.GetCreationTime(x)).ToArray();
                for (var i = 0; i < sortedFiles.Length; i++)
                {
                    if (i >= files.Length - 3)
                    {
                        break;
                    }

                    File.Delete(files[i]);
                }
            }
        }
    }
}