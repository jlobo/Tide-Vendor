

using Microsoft.EntityFrameworkCore;
using Tide.Vendor.Models;
using Tide.Vendor.Seeds;

namespace Tide.Vendor {
    public class VendorContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<SensitiveInfo> SensitiveInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite("Data Source=vendor.db");
        }

        #if DEBUG
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        #endif
    }
}