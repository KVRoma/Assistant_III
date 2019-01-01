using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant_III.Models
{
    public class AssistantContext : DbContext
    {
        public AssistantContext() : base("ConStr") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Example> Examples { get; set; }
       

        //Без цього метода та установки "SQLite.CodeFirst"
        //неможливо створити таблиці в БД, постійно вилазить помилка,
        //просидів із - за неї три дні !!! (от такий маленький глюк !!!)

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<AssistantContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}
