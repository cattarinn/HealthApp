using ConsoleApp9.Initializer;
using ConsoleApp9.Models.Activity;
using ConsoleApp9.Models.Product;
using ConsoleApp9.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Sockets;

namespace ConsoleApp9.Models.EF
{
    public class ActivityDatabase: DbContext
    {
        public DbSet<Walking> Walkings { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<PullUps> PullUps { get; set; }
        public DbSet<BaseActivity> BaseActivities { get; set; }
        public DbSet<MyProduct> Products { get; set; }
        public DbSet<TrainingUnit> TrainingUnits { get; set; }
        public DbSet<UserProfile> Users { get; set; }

        public ActivityDatabase()
        {
                Database.EnsureCreated();
                MyProductInitializer.Initialize(this);
                SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=database1.db");
        }
    }
}
