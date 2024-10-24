namespace Task1_Backup.Backup.Domain.Entities;


public class Settings
{
    public List<string> SourceDirectories { get; set; }
    public string TargetDirectory { get; set; }
    public LogLevel LogLevel { get; set; }
    public bool ZipCompression { get; set; }
}