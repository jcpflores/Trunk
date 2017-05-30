
namespace DtrModel
{
    class Model
    {
        private static AttendanceDbContext _attendanceDb;

        public static AttendanceDbContext GetAttendanceDbContext
        {
            get
            {
                if (_attendanceDb == null)
                {
                    _attendanceDb = new AttendanceDbContext("AttendanceDb");
                }
                return _attendanceDb;
            }
        }
    }
}
