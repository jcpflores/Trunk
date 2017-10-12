using System.Collections.Generic;
using DtrDelegates;
using DtrCommon;

namespace DtrInterfaces
{
    public interface IView
    {
        event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;

        event GetFilesFromRemoteEventHandler GetFilesFromRemoteEvent;

        event ParseFilesEventHandler ParseFilesEvent;

        event GetDtrDetailsEventHandler GetDtrDetailsEvent;

        event SaveDtrInfoEventHandler SaveDtrInfoEvent;

        void ShowFiles(ICollection<string> discoveredFiles);

        void ShowProcessedResources(ICollection<ProcessedResource> processed);

        void ShowDtrInfo(DtrInfo info);

        void ShowMessage(string message);
    }
}
