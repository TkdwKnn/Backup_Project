using Task1_Backup.Backup.Infrastructure.Serialization;
using Task1_Backup.Backup.Infrastructure.Services;

namespace Task1_Backup.Backup.Infrastructure.Utilities;
using Backup.Domain.Entities;
using System.Text.Json;
public static class JsonSettingLoader
{
    public static Settings LoadSetting(string path)
    {
        try
        {

            string fullPath = Path.Combine(path, "AppSettings.json");
            string jsonString = File.ReadAllText(fullPath);
            
          
            
            Settings? settings = JsonSerializer.Deserialize(jsonString, JsonContext.Default.Settings);
            return settings ?? new Settings();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            var loggerE = new Logger(path, LogLevel.Debug);
            loggerE.Log($"{e.Message}", LogLevel.Error);
            Environment.Exit(0);
            return new Settings();
        }

    }


}