using DtrModel.Entities;
using System.Linq;
using DtrInterfaces;

namespace DtrModel
{
    public delegate void ChangesSavedEventHandler();
    public class Model : IModel
    {
        private static AttendanceDbContext _attendanceDb;
        public static event ChangesSavedEventHandler ChangesSavedEvent;
        public static AttendanceDbContext GetAttendanceDbContext
        {
            get
            {
                if (_attendanceDb == null)
                {
                    _attendanceDb = new AttendanceDbContext("AttendanceDb");

                    var objectContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)_attendanceDb).ObjectContext;
                    objectContext.SavingChanges += ObjectContext_SavingChanges;

                    Create(_attendanceDb);
                }
                return _attendanceDb;
            }
        }

        private static void ObjectContext_SavingChanges(object sender, System.EventArgs e)
        {
            ChangesSavedEvent?.Invoke();
        }

        private static void Create(AttendanceDbContext context)
        {
            if (context.Set<SkillLevel>().Count() != 0)
            {
                return;
            }
        }
    }
}
