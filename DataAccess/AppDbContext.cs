using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<LaboratoryEntity> Laboratories { get; set; }
        public DbSet<AssignmentEntity> Assignments { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<SubmissionEntity> Submissions { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=.;Database=LaboratoryActivity_assignment2;Trusted_Connection=True;");
        }
    }
}
