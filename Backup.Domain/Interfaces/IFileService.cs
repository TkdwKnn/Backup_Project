namespace Task1_Backup.Backup.Domain.Interfaces;



public interface IFileService
{
    void FileCopy(string sourceFolderDir, string backupDir);
    void CreateZip(string sourceFolderDir, string backupDir);

}