using TPS.Core.Models;
using DataAccessOld.OriginalModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessOld.Data
{
    public class DataContextOld : DbContext
    {
        public DataContextOld(DbContextOptions<DataContextOld> options) : base(options)
        {
        }


        // Views ported from old database
        public DbSet<DataAccessOld.OriginalModels.CRP> CRPOriginal { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}
