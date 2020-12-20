using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tide.Vendor.Classes;
using Tide.Vendor.Models;

namespace Tide.Vendor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensitiveController : Controller
    {
        private readonly SensitiveService _service;

        public SensitiveController()
        {
            _service = new SensitiveService();
        }

        [HttpGet]
        public async Task<ActionResult<Sensitive>> Get(int id)
        {
            var info = await _service.Get(id);
            return info != null ? Ok(info) :NotFound() as ActionResult;
        }

        [HttpPost]
        public async Task Update(Sensitive info)
        {
            await _service.Update(info);
        }
    }
}