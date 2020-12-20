using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tide.Vendor.Models {
    public class Sensitive {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public string DLN { get; set; }
        public string TFN { get; set; }
        public string Salary { get; set; }
        public string Religion { get; set; }
        public string PoliticalParty { get; set; }

        public virtual User User { get; set; }
    }
}