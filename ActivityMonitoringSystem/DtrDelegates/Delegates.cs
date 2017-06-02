using DtrCommon;

namespace DtrDelegates
{
    public delegate void GetFilesFromLocalEventHandler(string localPath);

    public delegate void GetFilesFromRemoteEventHandler(string remotePath);

    public delegate void ParseFilesEventHandler(string[] filesToProcess);

    public delegate void GetDtrDetailsEventHandler(string resourceId);

    public delegate void SaveDtrInfoEventHandler(DtrInfo info);
}