using Task1_Backup.Backup.Application.Interfaces;
using Task1_Backup.Backup.Domain.Entities;
using Task1_Backup.Backup.Domain.Interfaces;

namespace Task1_Backup.Backup.Application.Services;

public class BackupService(IFileService fileService, ILogger logLevel) : IBackupService
{
    private readonly ILogger _logLevel = logLevel;
    private readonly IFileService _fileService = fileService;

    public void RunBackUp(Settings settings)
    {
        string timestamp = DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss");
        bool multipleSourceDirs = settings.SourceDirectories.Count > 1;
    
        foreach (var dir in settings.SourceDirectories)
        {
            string targetPath;
            if (multipleSourceDirs)
            {
                var sourceDirName = new DirectoryInfo(dir).Name;
                targetPath = Path.Combine(settings.TargetDirectory, $"{timestamp}_{sourceDirName}");
            }
            else
            {
                targetPath = Path.Combine(settings.TargetDirectory, timestamp);
            }
        
            Directory.CreateDirectory(targetPath);
            try
            {
                _logLevel.Log($"Working on {dir}", LogLevel.Info);
                _fileService.FileCopy(dir, targetPath);
                _logLevel.Log($"Successfully copied {dir}", LogLevel.Info);
                if (settings.ZipCompression)
                {
                    _fileService.CreateZip(targetPath, targetPath);
                }
            }
            catch (Exception e)
            {
                _logLevel.Log($"Error {e.Message}", LogLevel.Error);
            }
        }
    }


}
