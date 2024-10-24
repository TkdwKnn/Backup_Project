using Task1_Backup.Backup.Domain.Entities;

namespace Task1_Backup.Backup.Domain.Interfaces
{
    public interface ILogger
    {
        void Log(string message, LogLevel level);
    }
}