using Microsoft.EntityFrameworkCore;
using Company_WebApp.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Company_WebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.Department)
                      .WithMany(e => e.Employees)
                      .HasForeignKey(e => e.DepartmentId);
            });




            modelBuilder.Entity<Department>(entity =>
            {


            });
            


            modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Food", Description = "Providing all food services!" },
            new Department { Id = 2, Name = "Cleaning", Description = "Providing all Cleaning related services!" },
            new Department { Id = 3, Name = "Technical", Description = "Providing all Technical related services!" }
            );


        modelBuilder.Entity<Employee>().HasData(
        new Employee
        {
            Id = 1,
            Name = "Arpan Parajuli",
            Email = "arpan123@company.com",
            Phone = "9811111111",
            Address = "Butwal",
            DepartmentId = 1
        },
        new Employee
        {
            Id = 2,
            Name = "Naman Singh",
            Email = "naman@company.com",
            Phone = "9822222222",
            Address = "Pokhara",
            DepartmentId = 2
        }
    );



        }









    }
}