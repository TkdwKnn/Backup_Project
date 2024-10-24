# Backup_Project
# Backup Project

## Overview

**Task1_Backup** is a simple backup utility designed to copy files from one or more source directories to a target directory, with optional zip compression. It also includes a logging system to track the progress and status of the backup process.

## Features

- **Multi-directory backup**: Supports backing up multiple source directories.
- **File and directory copying**: Recursively copies files and directories from the source to the target.
- **Optional compression**: Compresses the copied data into a ZIP archive.
- **Logging**: Provides detailed logs about the backup process with three log levels: `Debug`, `Info`, and `Error`.

## Project Structure

```plaintext
Task1_Backup/
│
├── Application/
│   └── Interfaces/            # Interfaces for application-level services
│   └── Services/              # BackupService responsible for running the backup logic
│
├── Domain/
│   └── Entities/              # Domain entities like Settings and LogLevel enum
│   └── Interfaces/            # IBackupService, IFileService, and ILogger interfaces
│
├── Infrastructure/
│   └── Serialization/         # JSON serialization settings for configuration
│   └── Services/              # FileService and Logger implementations
│   └── Utilities/             # JSON loader utility
│
└── Presentation/
    └── Program.cs             # Main entry point for the application
```

## Getting Started

### Prerequisites

- .NET 8.0
- Access to directories you want to back up

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/TkdwKnn/Backup_Project/
   cd Backup_Project
   ```

2. Build the project:

   ```bash
   dotnet build
   ```

3. Edit the configuration file (`settings.json`) to specify your source and target directories, logging level, and whether you want ZIP compression.

   Example `settings.json`:
   ```json
   {
     "sourceDirectories": [
       "C:\\Users\\YourName\\Documents"
     ],
     "targetDirectory": "C:\\Backup\\Documents",
     "logLevel": "Info",
     "zipCompression": true
   }
   ```

### Usage

Run the application:

```bash
dotnet run
```

The backup process will copy all files and subdirectories from the `sourceDirectories` to the `targetDirectory`. If `zipCompression` is set to `true`, the backup will be compressed into a ZIP file.

### Logs

Logs are saved in the target directory with a timestamp. The logging level can be adjusted by setting the `logLevel` value in `settings.json`:

- `Error`: Only logs errors.
- `Info`: Logs general information and errors.
- `Debug`: Logs detailed debug information.
