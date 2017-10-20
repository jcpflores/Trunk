using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SQLite.CodeFirst;
using DtrModel.Entities;

namespace DtrModel
{
    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureAttendanceEntity(modelBuilder);
         
        }

        private static void ConfigureAttendanceEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<AttendanceSummary>();
            modelBuilder.Entity<Client>();
            modelBuilder.Entity<ClientContract>();
            modelBuilder.Entity<ClientHoliday>();
            
            modelBuilder.Entity<Holiday>();
            modelBuilder.Entity<ProcessRole>();
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<SkillLevel>();
            modelBuilder.Entity<TechnicalRole>();
            modelBuilder.Entity<WorkLocation>();
            modelBuilder.Entity<WorkSchedule>();
            modelBuilder.Entity<Users>();
            modelBuilder.Entity<DtrProcessLog>();
            modelBuilder.Entity<AuditTrail>();

            modelBuilder.Entity<DailyTimeRecord>();
            modelBuilder.Entity<TimeInOut>();

            modelBuilder.Entity<DtrCommon.DtrInfo>();
            modelBuilder.Entity<DtrCommon.DtrInOut>();
        }  

       
      
    }
}
