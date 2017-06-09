using DtrModel.Entities;
using System.Linq;
using DtrInterfaces;

namespace DtrModel
{
    public class Model : IModel
    {
        private static AttendanceDbContext _attendanceDb;

        public static AttendanceDbContext GetAttendanceDbContext
        {
            get
            {
                if (_attendanceDb == null)
                {
                    _attendanceDb = new AttendanceDbContext("AttendanceDb");

                    Create(_attendanceDb);
                }
                return _attendanceDb;
            }
        }

        private static void Create(AttendanceDbContext context)
        {
            //if (context.Set<SkillLevel>().Count() != 0)
            //{
            //    return;
            //}
        }
    }
}
