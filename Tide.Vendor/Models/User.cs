using Tide.Models;

namespace Tide.Vendor.Models {
    public class User : TideUser {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual SensitiveInfo Info { get; set; }
    }
}