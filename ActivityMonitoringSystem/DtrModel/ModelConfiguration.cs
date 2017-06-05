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
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<Client>();
            modelBuilder.Entity<ProcessRole>();
            modelBuilder.Entity<SkillLevel>();
            modelBuilder.Entity<WorkLocation>();
            modelBuilder.Entity<WorkSchedule>();
            modelBuilder.Entity<TechnicalRole>();
            modelBuilder.Entity<AttendanceSummary>();
            modelBuilder.Entity<ClientContract>();
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<DailyTimeRecord>();
            modelBuilder.Entity<Holiday>();
            modelBuilder.Entity<Users>();
            modelBuilder.Entity<TimeoffReason>();
            modelBuilder.Entity<ClientHoliday>();

         
        }  

       
      
    }
}
