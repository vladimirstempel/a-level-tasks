using System;
using System.Threading.Tasks;
using LoggerAsyncApp.Logger;
using Utils;

namespace LoggerAsyncApp;

public sealed class App
{
    private readonly ILogger _logger;

    public App(ILogger logger)
    {
        _logger = logger;
    }

    public async Task Start()
    {
        try
        {
            _logger.OnLogBackup += OnLogBackup;

            await GenerateLogs();
            await GenerateAnother50Logs();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occured: {0}", e);
        }
    }

    private void OnLogBackup(string backupName)
    {
        Console.WriteLine("Backup has been created. Backup name is: {0}", backupName);
    }

    private async Task GenerateLogs()
    {
        var runTimes = 50;

        for (int i = 0; i < runTimes; i++)
        {
            await _logger.WriteLog(TextGenerator.GenerateText(5, 10, 1, 2, 1));
        }
    }

    private async Task GenerateAnother50Logs()
    {
        var runTimes = 50;

        for (int i = 0; i < runTimes; i++)
        {
            await _logger.WriteLog(TextGenerator.GenerateText(5, 10, 1, 2, 1));
        }
    }

    
}