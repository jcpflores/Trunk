using System.Collections.Generic;
using DtrCommon;
using DtrDelegates;

namespace DtrInterfaces
{
    public interface IController
    {
        void SetView(IView view);

        void ReadDtrInformation(string path);

        void GetResourceInformation(List<UnprocessedResource> unprocessed);

        void GetResourceInformation(UnprocessedResource unprocessed);

        void UpdateResource(DtrInfo info);

    }
}
