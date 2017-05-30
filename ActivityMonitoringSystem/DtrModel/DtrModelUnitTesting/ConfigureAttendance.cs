using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DtrModel;

namespace DtrModelUnitTesting
{
    [TestClass]
    public class ConfigureAttendance
    {
        DtrModel.AttendanceDbContext _context;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _context = DtrModel.Model.GetAttendanceDbContext;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if( _context != null)
                _context = null;
        }


        [TestMethod]
        public void TestDatabaseFileExist()
        {
            Assert.IsTrue(System.IO.File.Exists(@"C:\Temp\AttendanceDb.sqlite"));
        }
    }
}
