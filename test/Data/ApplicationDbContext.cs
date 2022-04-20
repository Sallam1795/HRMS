using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using test.Models;
using test.ViewModel;

namespace test.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Archiev> Archievs { get; set; }
        public virtual DbSet<Holidays> Holidays { get; set; }
        public virtual DbSet<WeeklyHoliday> WeeklyHolidays { get; set; }
        public virtual DbSet<ExtraAndDiscount> ExtraAndDiscounts { get; set; }
        public DbSet<test.ViewModel.AttendenceViewModel> AttendenceViewModel { get; set; }

    }
}
