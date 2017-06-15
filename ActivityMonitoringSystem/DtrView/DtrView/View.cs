using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrInterfaces;
using DtrDelegates;
using DtrCommon;

namespace DtrView
{
    class View : IView
    {
        public event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;
        public event GetFilesFromRemoteEventHandler GetFilesFromRemoteEvent;
        public event ParseFilesEventHandler ParseFilesEvent;
        public event GetDtrDetailsEventHandler GetDtrDetailsEvent;
        public event SaveDtrInfoEventHandler SaveDtrInfoEvent;
        public View()
        {
            Main mainForm = new Main();

            mainForm.Show();
            mainForm.GetFilesFromLocalEvent += GetFilesFromLocal;

        }

        public void ShowFiles(string[] discoveredFiles)
        {
        }

        public void ShowProcessedResources(List<ProcessedResource> processed)
        {
        }

        public void ShowDtrInfo(DtrInfo info)
        {
        }

        public void ShowMessage(string message)
        {
        }

        private void GetFilesFromLocal(string localPath)
        {
            if (GetFilesFromLocalEvent != null)
            {
                GetFilesFromLocalEvent(localPath);
            }
        }

        private void GetFilesFromRemote(string remotePath)
        {
            if (GetFilesFromRemoteEvent != null)
            {
                GetFilesFromRemoteEvent(remotePath);
            }
        }

        private void ParseFiles(string[] filesToProcess)
        {
            if (ParseFilesEvent != null)
            {
                ParseFilesEvent(filesToProcess);
            }
        }

        private void GetDtrDetails(string resourceId)
        {
            if (GetDtrDetailsEvent != null)
            {
                GetDtrDetailsEvent(resourceId);
            }
        }

        private void SaveDtrInfo(DtrInfo info)
        {
            if (SaveDtrInfoEvent != null)
            {
                SaveDtrInfoEvent(info);
            }
        }
    }
}
