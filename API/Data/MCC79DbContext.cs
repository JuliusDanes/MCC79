using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class MCC79DbContext : DbContext
    {
        public MCC79DbContext(DbContextOptions<MCC79DbContext> options) : base(options)
        { 
        
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Constraints Unique
            modelBuilder.Entity<Employee>()
                .HasIndex(employee => new
                {
                    employee.Nik,
                    employee.Email,
                    employee.PhoneNumber
                }).IsUnique();

            //Relationship 
            //Relation between University and Education (Many to 1)
            modelBuilder.Entity<University>()
                .HasMany(university => university.Educations)
                .WithOne(education => education.University)
                .HasForeignKey(education => education.UniversityGuid);

            //Relation between Education and Employee (1 to 1)
            modelBuilder.Entity<Education>()
                .HasOne(education => education.Employee)
                .WithOne(employee => employee.Education)
                .HasForeignKey<Education>(education => education.Guid);

            //Relation between Employee and Booking (Many to 1)
            modelBuilder.Entity<Employee>()
                .HasMany(employee => employee.Bookings)
                .WithOne(booking => booking.Employee)
                .HasForeignKey(booking => booking.EmployeeGuid);

            //Relation between Booking and Room (1 to Many)
            modelBuilder.Entity<Booking>()
                .HasOne(booking => booking.Room)
                .WithMany(room => room.Bookings)
                .HasForeignKey(room => room.RoomGuid);

            //Relation between Employee and Account (1 to 1)
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Account)
                .WithOne(account => account.Employee)
                .HasForeignKey<Account>(account => account.Guid);

            //Relation between Account and AccountRole (Many to 1)
            modelBuilder.Entity<Account>()
                .HasMany(account => account.AccountRoles)
                .WithOne(accountRole => accountRole.Account)
                .HasForeignKey(accountRole => accountRole.AccountGuid);

            //Relation between AccountRole and Role (1 to Many)
            modelBuilder.Entity<AccountRole>()
                .HasOne(account_role => account_role.Role)
                .WithMany(role => role.AccountRoles)
                .HasForeignKey(role => role.RoleGuid);
        }
    }
}
