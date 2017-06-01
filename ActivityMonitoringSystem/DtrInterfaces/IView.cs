using DtrDelegates;

namespace DtrInterfaces
{
    public interface IView
    {
        event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;

        event GetFilesFromRemoteEventHandler GetFilesFromRemoteEvent;

        event ParseFilesEventHandler ParseFilesEvent;

        void ShowFiles(string[] discoveredFiles);
    }
}
