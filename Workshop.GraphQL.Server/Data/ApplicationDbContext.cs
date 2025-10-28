using Bogus;
using Microsoft.EntityFrameworkCore;
using Workshop.GraphQL.Server.Data.Entities;

namespace Workshop.GraphQL.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Assignment> Assignments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var departmentNames = new[]
        {
            "Information Technology", "Human Resources", "Finance", "Marketing", "Sales",
            "Research and Development", "Customer Service", "Operations", "Legal", "Public Relations",
            "Quality Assurance", "Product Management", "Business Development", "Administration", "Security",
            "Training and Development", "Logistics", "Communications", "Project Management", "Executive"
        };

        var departments = departmentNames.Select((name, index) => new Department { Id = index + 1, Name = name }).ToList();
        modelBuilder.Entity<Department>().HasData(departments);

        var assignments = new Faker<Assignment>()
            .RuleFor(a => a.Id, f => f.IndexFaker + 1)
            .RuleFor(a => a.Title, f => f.Commerce.ProductName())
            .Generate(20);
        
        modelBuilder.Entity<Assignment>().HasData(assignments);

        var employees = new Faker<Employee>()
            .RuleFor(e => e.Id, f => f.IndexFaker + 1)
            .RuleFor(e => e.Name, f => f.Name.FullName())
            .RuleFor(e => e.DepartmentId, f => f.Random.Number(1, 20))
            .RuleFor(e => e.AssignmentId, f => f.IndexFaker + 1)
            .RuleFor(e => e.Address, f => f.Address.StreetAddress())
            .RuleFor(e => e.Zipcode, f => f.Address.ZipCode())
            .RuleFor(e => e.Country, f => f.Address.Country())
            .RuleFor(e => e.BirthOfPlace, f => f.Address.City())
            .RuleFor(e => e.Telephonenumber, f => f.Phone.PhoneNumber())
            .RuleFor(e => e.Hobbies, f => f.Lorem.Words(3).ToArray())
            .Generate(20);

        modelBuilder.Entity<Employee>().HasData(employees);

        // Employee -> Department (many-to-one)
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Employee -> Assignment (many-to-one)
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Assignment)
            .WithMany(a => a.Employees)
            .HasForeignKey(e => e.AssignmentId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure required properties
        modelBuilder.Entity<Department>()
            .Property(d => d.Name)
            .IsRequired();

        modelBuilder.Entity<Assignment>()
            .Property(a => a.Title)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Name)
            .IsRequired();
    }
}
