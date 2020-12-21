using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tide.Vendor.Models;

namespace Tide.Vendor.Classes {
    public class SensitiveService {
        public async Task<Sensitive> Get(int id) {
            using (var db = new VendorContext()) {
                return await db.Sensitives.AsNoTracking()
                    .FirstOrDefaultAsync(itm => itm.UserId == id);
            }
        }

        public async Task Update(Sensitive info) {
            using (var db = new VendorContext()) {
                db.Sensitives.Update(info);
                await db.SaveChangesAsync();
            }
        }
    }
}