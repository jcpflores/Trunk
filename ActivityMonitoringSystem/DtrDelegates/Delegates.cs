

namespace DtrDelegates
{
    public delegate void GetFilesFromLocalEventHandler(string localPath);
    public delegate void GetFilesFromRemoteEventHandler(string remotePath);
    public delegate void ParseFilesEventHandler(string[] filesToProcess);
    
}
