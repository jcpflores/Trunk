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
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (System.IO.File.Exists(@"C:\Temp\AttendanceDb.sqlite"))
                System.IO.File.Delete(@"C:\Temp\AttendanceDb.sqlite");

        }

        // [TestMethod]
        public void TestDatabaseFileExist()
        {
            Assert.IsTrue(System.IO.File.Exists(@"C:\Temp\AttendanceDb.sqlite"));
        }



        #region --------------------------------------------------Test_Create

       //   [TestMethod]
        public void Test_CreateContract()
        {
            _context.Set<Client>().Add(
                new Client
                {
                    ClientName = "Coca cola",
                    Active = true,
                    EmployeeRefId = 1,
                    ClientContract = new List<ClientContract>
                    {
                        new ClientContract
                        {
                           ContractReference = "247 Intl 22112",
                           Project = new List<Project>
                           {
                                new Project
                                {
                                    ProjectName = "Project A" ,
                                    Active = true,
                                }
                           }
                        }
                    }
                });
            _context.SaveChanges();

            Assert.IsNotNull(_context.Set<Client>());
        }
        
       //    [TestMethod]
        public void Test_CreateWorkLocation()
        {
            _context.Set<WorkLocation>().Add(new WorkLocation
            {
                Description = "Paseo center ",
                Active = true,
                EmployeeRefId = 1
            });
            _context.SaveChanges();

            Assert.IsNotNull(_context.Set<WorkLocation>());
        }

        // [TestMethod]
        public void Test_CreateProject()
        {

            _context.Set<Project>().Add(new Project
            {
                ProjectName = "BPI1234112",
                Active = true,
                ClientContractRefId = 2
            });

            _context.SaveChanges();

            Assert.IsNotNull(_context.Set<Project>());
        }

       //     [TestMethod]
        public void Test_CreateUser()
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

        // [TestMethod]
        public void Test_CreateTechnical()
        {
            string expectedTechnical = "Team Leader";

            _context.Set<TechnicalRole>().Add(new TechnicalRole
            {
                TechRole = "Team Leader",
                Active = true,
                EmployeeRefId =1
            });

            _context.SaveChanges();

            var actualTechnical = _context.Set<TechnicalRole>()
                .Where(t => t.Id == 1).First();

            Assert.AreEqual(expectedTechnical, actualTechnical.TechRole);
        }

       //   [TestMethod]
        public void Test_CreateSkill()
        {
            _context.Set<SkillLevel>().Add(new SkillLevel
            {
                SkillName = ".Net",
                Active = true,
                EmployeeRefId =1
            });
            _context.SaveChanges();
            
        }

      //   [TestMethod]
        public void Test_CreateHoliday()
        {

            DateTime ExpectedHoliday = DateTime.Now;

            _context.Set<Holiday>().Add(new Holiday
            {
                HolidayDate = DateTime.Now,
                Description = "Independence Day",
                Active = true
            });

            _context.SaveChanges();

            var _holiday = _context.Set<Holiday>()
                .Where(t => t.Id == 1)
                .First();

            Assert.AreEqual(ExpectedHoliday.ToString(), _holiday.HolidayDate.ToString());
        }

      //  [TestMethod]
        public void Test_CreateAuditTrail()
        {
            _context.Set<AuditTrail>().Add(new AuditTrail
            {
                Username = "JCabugao",
                DateTime = DateTime.Now,
                Module = "Dtr Upload Form",
                Actions = "Uploading Excel File"                
            });
        }


      // [TestMethod]
        public void Test_CreateWorkSched()
        {
            _context.Set<WorkSchedule>().Add(new WorkSchedule
            {
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now,
                Offset = true,
                Flexi = true
            });

            Assert.IsNotNull(_context.Set<WorkSchedule>());
        }

        //[TestMethod]
        public void Test_CreateDailyTimeRecord()
        {
            _context.Set<DailyTimeRecord>().Add(new DailyTimeRecord
            {
                DateIn = DateTime.Now,
                DateOut = DateTime.Now,
                Notes = "dsadasda",
                Late = 100,
                Overtime = 200 ,
                TimeOffReason = new List <TimeoffReason>
                {
                    new TimeoffReason
                    {
                        Description = "Half Day"
                    }
                }
            });

            _context.SaveChanges();
        }

    //    [TestMethod]
        public void Test_CreateEmployee()
        {
            _context.Set<Employee>().Add(new Employee
            {
                Name = "Johncabugao 2",
                Initial = "JCabugao 2",
                Gender = true,
                AttendanceSummary = new List <AttendanceSummary>
                {
                    new AttendanceSummary
                    {
                        TotalEl =1,
                        TotalMinutesLate = 100,
                        TotalSl = 2
                    }
                },
                Skills = new List<SkillLevel>
                {
                    new SkillLevel
                    {
                        SkillName = "Sharepoint Dev",
                        Active = true                      

                    }
                },

                Client = new List<Client>
                {
                    new Client
                    {
                        ClientName = "Unilab",
                        Active = true                       
                    }
                },

                ProcessRole = new List<ProcessRole>
                {
                    new ProcessRole
                    {
                        RoleName = "Team Member",
                        Active = true
                    }
                },

                TechnicalRole = new List<TechnicalRole>
                {
                    new TechnicalRole
                    {
                        TechRole = ".Net",
                        Active = true
                    }
                },

                WorkLocation = new List<WorkLocation>
                {
                    new WorkLocation
                    {
                        Description = "Makati",
                        Active = true
                    }
                },

                WorkSchedule = new List<WorkSchedule>
                {
                    new WorkSchedule
                    {
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now,
                        Offset = true,
                        Flexi = true                        
                    }
                }             

            });

            _context.SaveChanges();
        }

        #endregion Test_Create


        #region --------------------------------------------------Test_Update
        
        // [TestMethod]
        public void Test_UpdateWorkLocation()
        {
            var _originalWorkLoc = _context.Set<WorkLocation>()
                .Where(t => t.Id == 1).First();

            string originalWorkLoc = _originalWorkLoc.Description.ToString();

            _context.Set<WorkLocation>()
                .Where(u => u.Id == 1).First()
                .Description = "Net Lima BGC";

            _context.SaveChanges();

            var _updatedWorkLoc = _context.Set<WorkLocation>()
                .Where(u => u.Id == 1).First();

            string UpdatedWorkLoc = _updatedWorkLoc.Description;

            Assert.AreNotEqual(originalWorkLoc, UpdatedWorkLoc);
        }

        // [TestMethod]
        public void Test_UpdateHoliday()
        {
            var _originalHoliday = _context.Set<Holiday>()
                .Where(t => t.Id == 10)
                .First();

            string originalholiday = _originalHoliday.HolidayDate.ToString();

            _context.Set<Holiday>()
                .Where(t => t.Id == 10)
                .First()
                .HolidayDate = DateTime.Now.AddDays(1);

            _context.SaveChanges();

            var _updatedHoliday = _context.Set<Holiday>()
                .Where(t => t.Id == 10)
                .First();

            string UpdatedHoliday = _updatedHoliday.HolidayDate.ToString();

            Assert.AreNotEqual(originalholiday, UpdatedHoliday);
        }

        // [TestMethod]
        public void Test_UpdateProject()
        {
            var _originalproject = _context.Set<Project>()
                .Where(t => t.Id == 2)
                .First();

            string originalproject = _originalproject.ProjectName;

            _context.Set<Project>()
            .Where(t => t.Id == 2).First()
            .ProjectName = "Project B";

            _context.SaveChanges();

            var _UpdatedProject = _context.Set<Project>()
                 .Where(t => t.Id == 2).First();

            Assert.AreNotEqual(originalproject, _UpdatedProject.ProjectName);

        }

        //[TestMethod]
        public void Test_UpdatClient()
        {
            var _originalclient = _context.Set<Client>()
                  .Where(t => t.Id.Equals(1))
                  .First();

            string original = _originalclient.ClientName;

            _context.Set<Client>()
                .Where(c => c.Id.Equals(1))
                .First()
                .ClientName = "Coca Cola XXXXX";

            _context.SaveChanges();

            var _UpdatedClient = _context.Set<Client>()
                .Where(u => u.Id.Equals(1))
                .First();

            string Updated = _UpdatedClient.ClientName;

            Assert.AreNotEqual(original, Updated);

        }


        //  [TestMethod]
        public void Test_UpdatUser()
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

        //  [TestMethod]
        public void Test_UpdateTechRole()
        {

            var _originalTechRole = _context.Set<TechnicalRole>()
                .Where(t => t.Id == 1).First();

            string originalTechRole = _originalTechRole.TechRole;

            _context.Set<TechnicalRole>()
                .Where(t => t.Id == 1).First()
                .TechRole = "Team Leader";
            _context.SaveChanges();

            var _UpdatedTechRole = _context.Set<TechnicalRole>()
                .Where(t => t.Id == 1).First();

            string UpdatedTechRole = _UpdatedTechRole.TechRole;

            Assert.AreNotEqual(originalTechRole, UpdatedTechRole);
        }


        // [TestMethod]
        public void Test_UpdateSkills()
        {
            var _originalskills = _context.Set<SkillLevel>()
                .Where(t => t.Id == 1).First();

            string OriginalSkills = _originalskills.SkillName;


            _context.Set<SkillLevel>()
                   .Where(t => t.Id == 1).First()
                   .SkillName = "Abap";

            _context.SaveChanges();

            var _UpdatedSkills = _context.Set<SkillLevel>()
                .Where(t => t.Id == 1).First();

            Assert.AreNotEqual(OriginalSkills, _UpdatedSkills.SkillName);

        }

      //  [TestMethod]
        public void Test_UpdateWorkSched()
        {
            var _originialWorkSched = _context.Set<WorkSchedule>()
                .Where(t => t.Id == 1).First();

            string OriginalDateFrom = _originialWorkSched.DateFrom.ToString();
            string OriginalDateTo = _originialWorkSched.DateTo.ToString();

            _context.Set<WorkSchedule>()
                .Where(t => t.Id == 1).First()
                .DateTo = DateTime.Now.AddDays(1);
            //.DateFrom = DateTime.Now.AddDays(1);
            _context.SaveChanges();

            var _UpdateWorkSched = _context.Set<WorkSchedule>()
                .Where(s => s.Id == 1).First();

            Assert.AreNotEqual(OriginalDateTo, _UpdateWorkSched.DateTo.ToString());
            
        }

      //  [TestMethod]
        public void Test_UpdateDailytime()
        {
            var _originalDtr = _context.Set<DailyTimeRecord>()
                .Where(t => t.Id == 1).First();

            string OriginalDateIn = _originalDtr.DateIn.ToString();
            string OriginalDateOut = _originalDtr.DateOut.ToString();

            _context.Set<DailyTimeRecord>()
                .Where(t => t.Id == 1).First()
                .DateIn = DateTime.Now.AddDays(1);

            _context.SaveChanges();

            var _UpdatedDtr = _context.Set<DailyTimeRecord>()
                .Where(t => t.Id == 1).First();

            Assert.AreNotEqual(OriginalDateIn, _UpdatedDtr.DateIn.ToString());
                


        }

        #endregion

        #region --------------------------------------------------Test_Delete

        // [TestMethod]
        public void Test_DeleteTechRole()
        {

            var del = _context.Set<TechnicalRole>()
                   .Where(d => d.Id == 1).First();

            _context.Set<TechnicalRole>().Remove(del);
            _context.SaveChanges();

            var ExistId = _context.Set<TechnicalRole>()
                .Where(d => d.Id == 1).First();

            Assert.IsNull(_context.Set<TechnicalRole>());

        }

        //[TestMethod]
        public void Test_DeleteProject()
        {

            var del = _context.Set<Project>()
                .Where(t => t.Id == 2).First();

            _context.Set<Project>().Remove(del);
            _context.SaveChanges();

            var ExistId = _context.Set<Project>()
                .Where(d => d.Id == 2).First();

            Assert.IsNull(_context.Set<Project>());
        }

        //   [TestMethod]
        public void Test_DeleteSkills()
        {
            var del = _context.Set<SkillLevel>()
            .Where(d => d.Id == 1).First();

            _context.Set<SkillLevel>().Remove(del);
            _context.SaveChanges();

            var ExistId = _context.Set<Holiday>()
                .Where(d => d.Id == 1).First();

            Assert.IsNull(_context.Set<SkillLevel>());
        }

        //  [TestMethod]
        public void Test_DeleteHoliday()
        {
            var del = _context.Set<Holiday>()
                .Where(t => t.Id == 2).First();

            _context.Set<Holiday>().Remove(del);
            _context.SaveChanges();

            var ExistId = _context.Set<Holiday>()
                .Where(d => d.Id == 2).First();

            Assert.IsNull(_context.Set<Holiday>());
        }

        //[TestMethod]       
        public void Test_DeleteUser()
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


        //   [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void Test_DeleteContract()
        {

            var del = _context.Set<Client>()
                            .Where(t => t.Id == 1).First();

            _context.Set<Client>().Remove(del);
            _context.SaveChanges();


            var ExistId = _context.Set<Client>()
            .Where(d => d.Id.Equals("2"))
            .First();

            Assert.IsNull(_context.Set<Client>());

        }


        //  [TestMethod]
        public void Test_DeleteWorkLoc()
        {
            var del = _context.Set<WorkLocation>()
                .Where(t => t.Id == 1).First();

            _context.Set<WorkLocation>().Remove(del);
            _context.SaveChanges();

            var ExistId = _context.Set<WorkLocation>()
                .Where(d => d.Id == 1).First();

            Assert.IsNull(_context.Set<WorkLocation>());

        }

       // [TestMethod]
        public void Test_DeleteWorkSched()
        {
            var del = _context.Set<WorkSchedule>()
                .Where(t => t.Id == 2).First();

            _context.Set<WorkSchedule>().Remove(del);
            _context.SaveChanges();

            var ExistId = _context.Set<WorkSchedule>()
                .Where(d => d.Id == 2).First();

            Assert.IsNull(_context.Set<WorkSchedule>());
        }

     //   [TestMethod]
        public void Test_DeleteDtr()
        {
            var del = _context.Set<DailyTimeRecord>()
                .Where(t => t.Id == 1).First();

            _context.Set<DailyTimeRecord>().Remove(del);
            _context.SaveChanges();
        }

       // [TestMethod]
        public void Test_DeleteTimeofReason()
        {
            var del = _context.Set<TimeoffReason>()
                .Where(t => t.Id == 2).First();

            _context.Set<TimeoffReason>().Remove(del);
            _context.SaveChanges();
        }

       // [TestMethod]
        public void Test_DeleteEmployee()
        {
            var del = _context.Set<Employee>()
              .Where(t => t.Id == 1).First();

            _context.Set<Employee>().Remove(del);
            _context.SaveChanges();
        }

        #endregion

    }
}
