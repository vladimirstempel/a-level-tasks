using System;
using System.Threading.Tasks;

namespace LoggerAsyncApp.Logger;

public interface ILogger
{
    public event Action<string> OnLogBackup;
    public Task WriteLog(string log);
}