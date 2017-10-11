using DtrCommon;
using System.Collections.Generic;

namespace DtrDelegates
{
    public delegate void GetFilesFromLocalEventHandler(string localPath);

    public delegate void GetFilesFromRemoteEventHandler(string remotePath);

    public delegate void ParseFilesEventHandler(ICollection<string> filesToProcess);

    public delegate void GetDtrDetailsEventHandler(string resourceId);

    public delegate void SaveDtrInfoEventHandler(string empId);
}