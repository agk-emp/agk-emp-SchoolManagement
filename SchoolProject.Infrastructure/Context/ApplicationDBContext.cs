﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Data.Entities.TabledFunctions;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.Context.DbFunctions;

namespace SchoolProject.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public DbSet<ClaimSpec> Claims { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Subjects> Subjectss { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        //Views
        public DbSet<StudentsCountPerDepartmentView> StudentsCountPerDepartmentView { get; set; }

        //Procedures
        public DbSet<GETStudentsCountForDepartmentProcedure> GETStudentsCountForDepartmentProcedure { get; set; }

        //tabled functions
        public DbSet<GetInstructorsDetailsFunction> GetInstructorsDetailsFunction { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.HasDbFunction(typeof(UserDefinedFunctions).GetMethod(nameof(UserDefinedFunctions.GetInstructorsTotalSalaries)))
                    .HasName("GetInstructorsTotalSalaries")
                    .HasSchema("dbo");

            modelBuilder.HasDbFunction(typeof(ApplicationDbContext).GetMethod(nameof(GetInstructorsDetails)))
                .HasName("GetInstructorsDetails")
                    .HasSchema("dbo");
        }

        public IQueryable<GetInstructorsDetailsFunction> GetInstructorsDetails()
        => FromExpression(() => GetInstructorsDetails());
    }
}
