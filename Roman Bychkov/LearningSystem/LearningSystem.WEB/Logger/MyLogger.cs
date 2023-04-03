namespace LearningSystem.WEB.Logger
{
    public static class MyLogger
    {
        public static bool CheckFreeSpaceOnDisk<T>(ILogger<T> logger)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DriveInfo drive = new DriveInfo(Path.GetPathRoot(currentDirectory));
            long requiredSpace = 10L * 1024L * 1024L * 1024L;
            if (drive.AvailableFreeSpace < requiredSpace)
            {
                logger.Log(LogLevel.Warning, "Less free disk space than 10 GB");
                return false;
            }
            return true;
        }
    }
}
