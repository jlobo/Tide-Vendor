using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tide.Vendor.Classes;

namespace Tide.Vendor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : Controller
    {
        private readonly UserService _service;

        public VendorController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ProtectedRoute()
        {
            var token = Request.Headers["Authorization"];
            if (!_service.ValidateVendorToken(token,out var claims)) return Unauthorized("Invalid token");

            return Ok(claims.First(c=>c.Type == "vuid").Value);
        }
    }
}