using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace ServiceSampleAndroid.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbFileName = "SmsSampleApp.db3";
            string fullDbPath = dbFileName;

            if (Device.OS == TargetPlatform.Android)
            {
                fullDbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbFileName");
            }

            optionsBuilder.UseSqlite($"Filename={fullDbPath}");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
