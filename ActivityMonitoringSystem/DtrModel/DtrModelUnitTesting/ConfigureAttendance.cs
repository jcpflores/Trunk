using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DtrModel.Entities;
using System.Collections;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;

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
            //if (_context != null)
            //{
            //    _context.Dispose();
            //    _context = null;
            //}

            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            //if (System.IO.File.Exists(@"C:\Temp\AttendanceDb.sqlite"))
            //    System.IO.File.Delete(@"C:\Temp\AttendanceDb.sqlite");

        }

        [TestMethod]
        public void TestDatabaseFileExist()
        {
            //Assert.IsTrue(System.IO.File.Exists(@"C:\Temp\AttendanceDb.sqlite"));
        }

        [TestMethod]
        public void TestAddUser()
        {
            string expectedUsername = "admin1";

            _context.Set<Users>().Add(new Users
            {
                Username = "admin1",
                Password = "pass1",
                Name = "JohnCabugao",
                Active = true
            });

            _context.SaveChanges();

            var _usr = _context.Set<Users>()
                 .Where(t => t.Username.Equals("admin1"))
                 .First();

            Assert.AreEqual(expectedUsername, _usr.Username);

        }

        //  [TestMethod]
        public void TestUpdatedUser()
        {
            var _originalname = _context.Set<Users>()
                 .Where(t => t.Username.Equals("admin1"))
                 .Where(t => t.Password.Equals("pass1"))
                 .First();

            string originalName = _originalname.Name;

            _context.Set<Users>()
              .Where(t => t.Username.Equals("admin1"))
              .Where(t => t.Password.Equals("pass1"))
              .First()
              .Name = "JohnCabugao Updated";

            _context.SaveChanges();

            var _UpdatedName = _context.Set<Users>()
               .Where(t => t.Username.Equals("admin1"))
               .Where(t => t.Password.Equals("pass1"))
               .First();

            string UpdatedName = _UpdatedName.Name;

            Assert.AreNotEqual(originalName, UpdatedName);

        }

        //[TestMethod]
        // [ExpectedException(typeof(ArgumentException),"Error")]
        public void TestDeletedUser()
        {
            //var query = from x in _context.Set<Users>()
            //            where x.Name == "JohnCabugao Updated"
            //            select x;

            var del = _context.Set<Users>()
            .Where(t => t.Id == 4).First();

            _context.Set<Users>().Remove(del);
            _context.SaveChanges();

            Assert.IsNotNull(_context.Set<Users>());

            var ExistsId = _context.Set<Users>()
             .Where(t => t.Id.Equals("4"))
             .First();
            //Assert.Fail();         

        }

        [TestMethod]
        public void TestAddContract()
        {
            _context.Set<Client>().Add(
                new Client
                {
                    ClientName = "Coca cola",
                    Active = true,
                    ClientContract = new List<ClientContract>
                    {
                        new ClientContract
                        {
                            ContractReference = "247 Intl 22112",
                        }
                    }
                });

            _context.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void TestDeleteContract()
        {
            //     var del = _context.Set<Users>()
            //.Where(t => t.Id == 4).First();

            //     _context.Set<Users>().Remove(del);
            //     _context.SaveChanges();

            //     Assert.IsNotNull(_context.Set<Users>());

            //     var ExistsId = _context.Set<Users>()
            //      .Where(t => t.Id.Equals("4"))
            //      .First();


            var del = _context.Set<Client>()
                            .Where(t => t.Id == 2).First();

            _context.Set<Client>().Remove(del);
            _context.SaveChanges();


            var ExistId = _context.Set<Client>()
            .Where(d => d.Id.Equals("2"))
            .First();

            Assert.IsNull(_context.Set<Client>());

        }






    }
}
