using System;
using Logger;

namespace HomeWorkLogger;

public static class Actions
{
    private static readonly Logger.Logger Logger = global::Logger.Logger.Instance;
    
    public static Result LogInfo()
    {
        var result = new Result();
        
        result.Status = true;
        
        Logger.Write(Level.Info, $"Start method CallInfo: {result.Status}");
        
        return result;
    }
    
    public static Result LogWarning()
    {
        var result = new Result();
        
        result.Status = true;
        
        Logger.Write(Level.Warning, $"Skipped logic in method CallWarning: {result.Status}");
        
        return result;
    }
    
    public static Result ThrowError()
    {
        var result = new Result();
        
        result.Status = false;
        
        result.Error = "I broke a logic";
        
        return result;
    }
}