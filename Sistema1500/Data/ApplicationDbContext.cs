using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Sistema1500.Models;
using System.Collections.Generic;
using Project = Sistema1500.Models.Project;


namespace Sistema1500.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Circle> Circles { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Learning> Learnings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<PersonLearning> PersonLearnings { get; set; }
        public DbSet<PersonFeedback> PersonFeedbacks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TypeConsultor> TypeConsultors { get; set; }
        public DbSet<ActualState> ActualStates { get; set; }
        public DbSet<HoursDay> HoursDays { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Captures> Captures { get; set; }
        public DbSet<CostCenter> CostCenter { get; set; }
        public DbSet<Enterprise> Enterprise { get; set; }
        public DbSet<Expense> Expense { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActualState>()
            .HasOne(e => e.Person)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonFeedback>()
            .HasOne(e => e.Person)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonLearning>()
            .HasOne(e => e.Person)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
