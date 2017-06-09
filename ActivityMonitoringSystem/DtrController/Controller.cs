using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrInterfaces;
using DtrDelegates;
using DtrController.Tools.DtrFileReader;

namespace DtrController
{
    public class Controller : IController
    {
        IView _view;

        public void SetView(IView view)
        {
            _view = view;
            view.GetFilesFromLocalEvent += View_GetFilesFromLocalEvent;
            //view.ShowProcessedResources();
        }

        private void View_GetFilesFromLocalEvent(string localPath)
        {
            DtrFileReader dfr = new DtrFileReader();
            dfr.ReadDtrFileFromFolder(localPath);
        }
    }
}
