using System.IO.Compression;
using Task1_Backup.Backup.Domain.Entities;
namespace Task1_Backup.Backup.Infrastructure.Services;
using Backup.Domain.Interfaces;

public class FileService(ILogger logger) : IFileService
{
    public void FileCopy(string sourceFolderDir, string backupDir)
    {
        try
        {
            foreach (var fileP in Directory.GetFiles(sourceFolderDir))
            {
                try
                {
                    var file = new FileInfo(fileP);
                    logger.Log($"Saving {file.Name}", LogLevel.Debug);
                    var fPath = Path.Combine(backupDir, file.Name);
                    file.CopyTo(fPath);
                    logger.Log($"Saved {file.Name}", LogLevel.Debug);
                }
                catch (Exception e)
                {
                    logger.Log(e.Message, LogLevel.Error);
                }
            }
        
            foreach (var dirP in Directory.GetDirectories(sourceFolderDir))
            {
                try
                {
                    var dir = new DirectoryInfo(dirP);
                    logger.Log($"Copying subdirectory {dir.FullName}", LogLevel.Debug);
                    var dPath = Path.Combine(backupDir, dir.Name);
                    Directory.CreateDirectory(dPath);
                    FileCopy(dir.FullName, dPath);
                    logger.Log($"Copied subdirectory {dir.FullName} to {dPath}", LogLevel.Debug);
                }
                catch (Exception e)
                {
                    logger.Log($"Error copying subdirectory {dirP}: {e.Message}", LogLevel.Error);
                }
            }
        }
        catch (Exception e)
        {
            logger.Log(e.Message,LogLevel.Error);
        }
        
    }

    public void CreateZip(string sourceFolderDir, string backupDir)
    {
        try
        {
            logger.Log($"Creating zip file from {sourceFolderDir}", LogLevel.Info);
            ZipFile.CreateFromDirectory(sourceFolderDir, sourceFolderDir+".zip");
            Directory.Delete(sourceFolderDir,true);
            logger.Log($"Created zip file from {sourceFolderDir}", LogLevel.Info);
        }
        catch (Exception e)
        {
            logger.Log($"Error creating zip file: {e.Message}",LogLevel.Error);
            Console.WriteLine(e.Message);
            
        }
        
    }
    

}