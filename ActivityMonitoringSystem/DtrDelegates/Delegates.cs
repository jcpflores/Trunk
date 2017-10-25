using DtrCommon;
using System.Collections.Generic;

namespace DtrDelegates
{
    public delegate void GetFilesFromLocalEventHandler(string localPath);

    public delegate void GetFilesFromRemoteEventHandler(string remotePath);

    public delegate void ParseFilesEventHandler(ICollection<string> filesToProcess);

    public delegate void GetDtrDetailsEventHandler(string resourceId);

    public delegate void SaveDtrInfoEventHandler(string empId);

    public delegate void EditDtrInOutEventHandler(DtrInOut inOut);

    public delegate void DoneParsingFilesEventHandler();

    public delegate void DataChangeEventHandler();

    public delegate void GetExcelFilesProgressEventHandler(int progressCount, int filesToProcess);

    public delegate void GetExcelErrorFileEventHandler();

    public delegate void GetErrorFileListEventHandler(ICollection<string> errorFileList);


}