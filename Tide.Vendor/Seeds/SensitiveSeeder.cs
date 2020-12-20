using Microsoft.EntityFrameworkCore;
using Tide.Vendor.Models;

namespace Tide.Vendor.Seeds
{
    public static class SensitiveSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var user = new User
            {
                Id = 1,
                Name = "admin",
                Vuid = "89e11152-ebfe-b0db-6653-db438e078cde",
                PublicKey = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA5DIkl8PmSn/QDpHCTOYYuk/eAoDXF8gHCyR3ToaOvwTpJQ2Kf0CPAa/VrEl/VJTiWHNdvwNrCLBB98DPXm73"
            };

            modelBuilder.Entity<Sensitive>().HasData(new Sensitive
            {
                User = user,
                DLN = "AYHI8gs0rj12B0JTP8BLgJD1RgiLFK7hOZcNjPXJuP46jXR7+nzEiv09YbE0UXy965ad7PwGVFbrl9Sg2kfSUuxBlBI20dK8P5NKvFks06rPQYJziAoKT0oJbytcibVVroOIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAZfqOhaQWK90J2szqHB1EA6Kpe9GQiK+hEgUrM6BoHsAijowh+xDqMGaxL6fMdAYFY4uvTP8JEegOD322OuR1s=",
                TFN = "AYHITDQRDGliTFDjWZzr5+n7Vy+S2iUvZXf3mqy5U9Eidepi8EzXpX5CDzyD9DuzCffhZpXS8lecsayyHZy4t5+QKhdbwxcUdKmW/AZ9iTrOUMD/D3wg5ibTuTS4Qkkxe+DIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAVhX4+pDKBY0zyAkY9BqT+zYQVxdJekSxrq5dYxFpyBBZJRF60N3sEGXV4tdKZKY/lg7lxGQYt+ErU2y28LL9E=",
                Salary = "AYHIlBwT1ULwzYoax9c2Uiye1pcmVyTxuEPM2KBvKG9joCRGLThJGOPI3EMYmE+gYkqX5FXkxvVueRd0U22yx8hikGeNONFt2iXHp6AUh9otrd7jiAYq7ultvYqAjK7lDHYuAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA4WczjfgUU45nyvV1D8Kc6t/EVKMpSA3evLUHaMBlbWCLiqP8TJCEG2jYu1dqIulHQYI9P8x9FJ9JqX8oLYY7A=",
                Religion = "AYHI7dKIWFwSIGI5ALWUagLbgEY4mhovZodLm8wA/VHGdDckv8B5Ao1n5H9CZUsM4kiFll52nzoUX1ZoxfAZPScmmW8BO1sDdICs0FVepHUuYP6V6txMrsErJFlLOVRTdGPXAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/uGE9qbo9XsPdtnGVWACHXL+sF3obCZOrN/nHOOkKDAqe44PTeoo3V/JlIvw/TJpV6wSpvpKl0DIkY0LcQ9A4=",
                PoliticalParty = "AYHIqUu64/l8JRK24vRWHjHE9wkiR0sqH0pKQ9/vbPzitBlBaD/y03zv2pqVnEq4C64or0OJq8r8ZQ7yp+5qCEo96xhGkPTvFrpoCXhzCeKpX58ESh8sM9BMCgUN0/Io2Xg/AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAJ/NCORJ/kDG2JoDSb4wURbiAf8IsVTlbHA+UJz04EiCChLqT9t3aeV6SVyYLUSUTC6NH4cr+h6H43VVyPOk9k="
            });
        }
    }
}
