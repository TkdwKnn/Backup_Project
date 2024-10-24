using Task1_Backup.Backup.Application.Services;
using Task1_Backup.Backup.Infrastructure.Services;
using Task1_Backup.Backup.Infrastructure.Utilities;
namespace Task1_Backup.Backup.Presentation;

public class Backup
{
    static void Main()
    {
        var appDir = Path.GetDirectoryName(AppContext.BaseDirectory);
        var settings = JsonSettingLoader.LoadSetting(appDir);
        var logger = new Logger(appDir,settings.LogLevel);
        var fs = new FileService(logger);
        BackupService bs = new BackupService(fs, logger);
        bs.RunBackUp(settings);

      
    }

}