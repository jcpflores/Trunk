using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SQLite.CodeFirst;
using DtrModel.Entities;


namespace SQLiteExample
{
    public class AttendanceDBInitializer : SqliteDropCreateDatabaseWhenModelChanges<AttendanceDbContext>
    {
        public AttendanceDBInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder, typeof(CustomHistory))
        {

        }

        protected override void Seed(AttendanceDbContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}
