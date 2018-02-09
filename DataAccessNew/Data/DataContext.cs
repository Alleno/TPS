using TPS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessNew.Data
{
    public class DataContextNew : DbContext
    {
        public DataContextNew(DbContextOptions<DataContextNew> options) : base(options)
        {
        }

        // Real models
        public DbSet<TPS.Core.Models.Contract> Contracts { get; set; }
        public DbSet<TPS.Core.Models.TaskOrder> TaskOrders { get; set; }
        public DbSet<TPS.Core.Models.Amendment> Amendments { get; set; }
        public DbSet<TPS.Core.Models.TaskBaseClass> TasksBase { get; set; }
        public DbSet<TPS.Core.Models.Task> Tasks { get; set; }
        public DbSet<TPS.Core.Models.SubTask> SubTasks { get; set; }
        public DbSet<TPS.Core.Models.Employee> Employees { get; set; }
        public DbSet<TPS.Core.Models.Division> Divisions { get; set; }
        public DbSet<TPS.Core.Models.Deliverable> Deliverables { get; set; }
        public DbSet<TPS.Core.Models.Publication> Publications { get; set; }
        public DbSet<TPS.Core.Models.Sponsor> Sponsors { get; set; }
        public DbSet<TPS.Core.Models.LaborCharge> LaborCharges { get; set; }
        public DbSet<TPS.Core.Models.NonLaborCharge> NonLaborCharges { get; set; }
        public DbSet<TPS.Core.Models.PayPeriod> PayPeriods { get; set; }

        // Lookup tables for select boxes
        public DbSet<TPS.Core.Models.FundingCategory> FundingCategories { get; set; }
        public DbSet<TPS.Core.Models.AnticipatedAudience> AnticipatedAudiences { get; set; }
        public DbSet<TPS.Core.Models.VisibilityLevel> VisibilityLevels { get; set; }
        public DbSet<TPS.Core.Models.ApprovalStatus> ApprovalStatuses { get; set; }
        public DbSet<TPS.Core.Models.Format> Formats { get; set; }
        public DbSet<TPS.Core.Models.EmployeeType> EmployeeTypes { get; set; }
        public DbSet<TPS.Core.Models.ProductType> ProductTypes { get; set; }
        public DbSet<TPS.Core.Models.SFRDProgramArea> SFRDProgramAreas { get; set; }
        public DbSet<TPS.Core.Models.CRPCategory> CRPCategories { get; set; }
        public DbSet<TPS.Core.Models.IDACoreArea> IDACoreAreas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TPS.Core.Models.TaskOrder>()
                .HasOne(a => a.Task)
                .WithOne(b => b.TaskOrder)
                .HasForeignKey<Task>(a => a.TaskOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TPS.Core.Models.Amendment>()
                .HasOne(a => a.TaskOrder)
                .WithMany(t => t.Amendments)
                .HasForeignKey(t => t.TaskOrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<TPS.Core.Models.SubTask>()
                .HasOne(t => t.Task)
                .WithMany(s => s.SubTasks)
                .HasForeignKey(t => t.TaskId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Deliverable>()
                .Property(d => d.CurrentStatus)
                .HasField("_currentStatus");

            modelBuilder.Entity<Deliverable>()
                .Property(d => d.CurrentStatusAsOf)
                .HasField("_currentStatusAsOf");
        }
    }
}
