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
    
            modelBuilder.Entity<Client>()
                .HasMany(t => t.Contract);

            
            modelBuilder.Entity<Employee>();                 
             
            modelBuilder.Entity<SkillLevel>();

            modelBuilder.Entity<TechnicalRole>();

            modelBuilder.Entity<Project>();

            modelBuilder.Entity<ProcessRole>();

            


        }  

    }
}
