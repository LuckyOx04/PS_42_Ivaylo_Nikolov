using System;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Database;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   
        string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string databaseFile = "welcome.db";
        string databasePath = Path.Combine(solutionFolder, databaseFile);
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

        // Create a user
        var user = new DatabaseUser()
        {
            Id = 1,
            Names = "John Doe",
            Password = "1234",
            Role = Welcome.Others.UserRolesEnum.ADMIN,
            Expires = DateTime.Now.AddYears(10),
            Email = null,
            FacultyNumber = null
        };

        var user2 = new DatabaseUser()
        {
            Id = 2,
            Names = "Ivan Petrov",
            Password = "123123",
            Role = Welcome.Others.UserRolesEnum.STUDENT,
            Expires = DateTime.Now.AddYears(4),
            Email = null,
            FacultyNumber = null
        };

        var user3 = new DatabaseUser()
        {
            Id = 3,
            Names = "Georgi Hristov",
            Password = "123456",
            Role = Welcome.Others.UserRolesEnum.PROFESSOR,
            Expires = DateTime.Now.AddYears(7),
            Email = null,
            FacultyNumber = null
        };

        modelBuilder.Entity<DatabaseUser>()
            .HasData(user, user2, user3);
    }

    public DbSet<DatabaseUser> Users { get; set; }
}
