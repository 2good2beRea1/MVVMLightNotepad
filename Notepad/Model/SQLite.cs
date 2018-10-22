using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using Notepad.Model;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using System.Data.SQLite;
using Notepad.ViewModel;

namespace Notepad.EF
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("SQLite")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
        public DbSet<Note> Notes { get; set; }
    }
}
