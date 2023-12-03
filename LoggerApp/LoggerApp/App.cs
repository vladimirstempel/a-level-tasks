using System;
using System.Linq;
using Logger;
using LoggerApp.Exceptions;

namespace LoggerApp;

public sealed class App
{
    private Logger.Logger _logger;
    private Actions _actions;
    private FileService _fileService;

    public App(Logger.Logger logger, Actions actions, FileService fileService)
    {
        _logger = logger;
        _actions = actions;
        _fileService = fileService;
    }
    
    public void Run()
    {
        var actionList = new[]
        {
            _actions.LogInfo,
            _actions.LogWarning,
            _actions.ThrowError
        };
        
        var runTimes = 100;
        var random = new Random();
        var shuffled = actionList
            .Select(method => Tuple.Create(random.Next(), method))
            .OrderBy(tuple => tuple.Item1)
            .Select(tuple => tuple.Item2);

        for (var i = 0; i < runTimes; i++)
        {
            try
            {
                shuffled.First().Invoke();
            }
            catch (BusinessException e)
            {
                _logger.Write(Level.Warning, $"Action got this custom Exception : {e.Message}");
            }
            catch (Exception e)
            {
                _logger.Write(Level.Error, $"Action failed by reason: {e}");
            }
        }
        
        _fileService.WriteLogsToFile(Level.Info, _logger.GetLogsAsText(Level.Info));
        _fileService.WriteLogsToFile(Level.Warning, _logger.GetLogsAsText(Level.Warning));
        _fileService.WriteLogsToFile(Level.Error, _logger.GetLogsAsText(Level.Error));
    }
}