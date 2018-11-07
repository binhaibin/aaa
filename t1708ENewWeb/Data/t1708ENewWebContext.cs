using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace t1708ENewWeb.Models
{
    public class t1708ENewWebContext : DbContext
    {
        public t1708ENewWebContext (DbContextOptions<t1708ENewWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Mark>(s => s.Marks)
                .WithOne(m => m.Students)
                .HasForeignKey(x => x.SubjectRollNumber)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    RollNumber = "123",
                    FirstName = "hai",
                    LastName = "hai",
                    Email = "binhaibin123@gmail.com",
                },
                new Student()
                {
                    RollNumber = "124",
                    FirstName = "anh",
                    LastName = "anh",
                    Email = "anhanh@gmail.com",
                }
            );
            modelBuilder.Entity<Mark>().HasData(
                new Mark()
                {
                    Id = 1,
                    SubjectName = "php",
                    SubjectMark = 100,
                    SubjectRollNumber = "123"
                },
                new Mark()
                {
                    Id = 2,
                    SubjectName = "Asp.net",
                    SubjectMark = 100,
                    SubjectRollNumber = "123"
                }
            );
            
        }

        public DbSet<t1708ENewWeb.Models.Student> Student { get; set; }
        public DbSet<t1708ENewWeb.Models.Mark> Marks { get; set; }
    }
}
