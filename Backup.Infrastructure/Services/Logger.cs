namespace Task1_Backup.Backup.Infrastructure.Services;
using Backup.Domain.Interfaces;
using Backup.Domain.Entities;

public class Logger : ILogger
{
    private readonly string _logFilePath;
    private readonly LogLevel _logLevel;

    public Logger(string logFilePath, LogLevel logLevel)
    {
        _logFilePath =  Path.Combine(logFilePath, DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss-fff") + "log.txt"); 
        _logLevel = logLevel;
    }

    public void Log(string message, LogLevel level)
    {
        if (level <= _logLevel)
        {
            File.AppendAllText(_logFilePath, $"{DateTime.Now} : {level} - {message}{Environment.NewLine}");   
        }

    }

}