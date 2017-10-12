using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using DtrModel.Entities;

namespace DtrModel
{
 
    public class AttendanceDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<AttendanceSummary> Attendance { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientContract> ClientContract { get; set; }
        public DbSet<ClientHoliday> ClientHoliday { get; set; }
        public DbSet<DailyTimeRecord> DailyTimeRecord { get; set; }
        public DbSet<Holiday> Holiday { get; set; }
        public DbSet<ProcessRole> ProcessRole { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<SkillLevel> SkillLevel { get; set; }
        public DbSet<TechnicalRole> TechnicalRole { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<WorkLocation> WorkLoc { get; set; }
        public DbSet<WorkSchedule> WorkSchedule { get; set; }
        public DbSet<DtrProcessLog>DtrProcessLog { get; set; }
        public DbSet<TempTableDtr> TempTableDtr { get; set; }
        public DbSet<TimeInOut> TimeInOut { get; set; }
        public DbSet<TempTableTimeInOut> TempTableimeInOut { get; set; }


        public AttendanceDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configure();
        }

        public AttendanceDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection , contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new AttendanceDBInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }
    }
}
