using Microsoft.EntityFrameworkCore;
using UniversityDbApp.Models;

namespace UniversityDbApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Teacher> Teachers => Set<Teacher>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>()
            .HasMany(department => department.Teachers)
            .WithOne(teacher => teacher.Department)
            .HasForeignKey(teacher => teacher.DepartmentId)
            .IsRequired();

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Ақпараттық технологиялар кафедрасы" },
            new Department { Id = 2, Name = "Математика кафедрасы" });

        modelBuilder.Entity<Teacher>().HasData(
            new Teacher
            {
                Id = 1,
                FirstName = "Айдана",
                LastName = "Нұрланова",
                Email = "aidana.nurlanova@university.kz",
                DepartmentId = 1
            },
            new Teacher
            {
                Id = 2,
                FirstName = "Ерлан",
                LastName = "Серікұлы",
                Email = "erlan.serikuly@university.kz",
                DepartmentId = 1
            },
            new Teacher
            {
                Id = 3,
                FirstName = "Мадина",
                LastName = "Әлиева",
                Email = "madina.alieva@university.kz",
                DepartmentId = 2
            });
    }
}
