using System;
using Logger;

namespace HomeWorkLogger;

public static class Starter
{
    public static void Run()
    {
        Logger.Logger logger = Logger.Logger.Instance;
        var actionList = new[]
        {
            Actions.LogInfo,
            Actions.LogWarning,
            Actions.ThrowError
        };
        
        var runTimes = 100;
        var random = new Random();
        var shuffled = actionList
            .Select(method => Tuple.Create(random.Next(), method))
            .OrderBy(tuple => tuple.Item1)
            .Select(tuple => tuple.Item2);
        
        var errorMessage = "Action failed by a reason:";

        for (var i = 0; i < runTimes; i++)
        {
            Result result = new Result();

            result = shuffled.First().Invoke();

            if (!result.Status)
            {
                logger.Write(Level.Error, $"{errorMessage} {result.Error}");
            }
        }
        
        logger.WriteLogsToFile(Level.Info);
        logger.WriteLogsToFile(Level.Warning);
        logger.WriteLogsToFile(Level.Error);
    }
}