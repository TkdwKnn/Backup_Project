using Task1_Backup.Backup.Domain.Entities;

namespace Task1_Backup.Backup.Application.Interfaces;

public interface IBackupService
{
    void RunBackUp(Settings settings);
    
}