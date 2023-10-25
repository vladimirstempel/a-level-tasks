using System;
using Logger;

namespace HomeWorkLogger;

public static class Starter
{
    public static void Run()
    {
        Logger.Logger logger = Logger.Logger.Instance;
        var runTimes = 100;
        var random = new Random();
        var randomMin = 1;
        var randomMax = 4;
        var errorMessage = "Action failed by a reason: ";

        for (var i = 0; i < runTimes; i++)
        {
            var randomNumber = random.Next(randomMin, randomMax);
            Result result = new Result();

            switch ((ActionMethod)randomNumber)
            {
                case ActionMethod.Info:
                    result = Actions.LogInfo();
                    break;
                case ActionMethod.Warning:
                    result = Actions.LogWarning();
                    break;
                case ActionMethod.Error:
                    result = Actions.ThrowError();
                    break;
            }

            if (!result.Status)
            {
                logger.Write(Level.Error, result.Error);
            }
        }
        
        logger.WriteToFile(Level.Info);
        logger.WriteToFile(Level.Warning);
        logger.WriteToFile(Level.Error);
    }
}