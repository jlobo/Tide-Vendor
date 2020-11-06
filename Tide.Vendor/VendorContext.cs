

using Microsoft.EntityFrameworkCore;
using Tide.Vendor.Models;

namespace Tide.Vendor {
    public class VendorContext : DbContext {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite("Data Source=vendor.db");
        }
    }
}