using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using DtrModel;

namespace DtrModel
{
    public class AttendanceDbContext : DbContext
    {
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
