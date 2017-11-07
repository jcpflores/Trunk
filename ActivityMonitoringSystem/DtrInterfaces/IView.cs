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

        event EditDtrInOutEventHandler EditDtrInOutEvent;

        event GetHolidayListEventHandler GetHolidayListEvent;

        event SaveEmployeeRecordsEventHandler SaveEmployeeRecordsEvent;

        event GetEmployeeListEventHandler GetEmployeeListEvent;

        event GetExistEmployeeRecordEventHandler GetExistEmployeeRecordEvent;

        void ShowFiles(ICollection<string> discoveredFiles);

        void ShowProcessedResources(ICollection<ProcessedResource> processed);

        void ShowDtrInfo(DtrInfo info);

        void ShowMessage(string message);
        void ShowProgress(int count, int totalFiles);

        void ShowError(ICollection<string> erroFiles);

        void ShowHolidayList(ICollection<DtrCommon.Holiday> holidayList);

        void ShowEmployeeList(ICollection<DtrCommon.Employee> employeeList);

        void ExistEmployeeRecord(bool existEmployee);
    }
}
