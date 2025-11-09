using Microsoft.EntityFrameworkCore;
using RankenClassSchedule.Models.Configuration;
using RankenClassSchedule.Models.DomainModels;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Claims;

namespace RankenClassSchedule.Models.DataLayer
{
    public class ClassScheduleContext : DbContext
    {
        public ClassScheduleContext(DbContextOptions<ClassScheduleContext> options) : base(options) { }

        public DbSet<Day> Days { get; set; }
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Class> classes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DayConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new ClassConfig());
        }
    }
}

