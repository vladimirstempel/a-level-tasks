using System;
using Logger;
using LoggerApp.Exceptions;

namespace LoggerApp;

public class Actions
{
    private readonly Logger.Logger _logger;
    
    public Actions(Logger.Logger logger)
    {
        _logger = logger;
    }
    
    public void LogInfo()
    {
        _logger.Write(Level.Info, $"Start method LogInfo");
    }
    
    public void LogWarning()
    {
        throw new BusinessException("Skipped logic in method");
    }
    
    public void ThrowError()
    {
        throw new Exception("I broke a logic");
    }
}