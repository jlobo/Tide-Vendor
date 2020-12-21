using System;
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
        private readonly SensitiveService _sensitiveSrv;
        private readonly UserService _userSrv;

        public SensitiveController(UserService service)
        {
            _sensitiveSrv = new SensitiveService();
            _userSrv = service;
        }

        [HttpGet]
        public Task<ActionResult> Get()
        {
            return CheckToken(async usr => {
                var info = await _sensitiveSrv.Get(usr.Id);

                return info != null ? Ok(info) : NotFound() as ActionResult;
            });
        }

        [HttpPost]
        public Task<ActionResult> Update(Sensitive info)
        {
            return CheckToken(async usr =>
            {
                if (usr.Id != info.UserId)
                    return Unauthorized("Invalid token");
                
                await _sensitiveSrv.Update(info);
                return Ok();
            });
        }

        private async Task<ActionResult> CheckToken(Func<User, Task<ActionResult>> fun)
        {
            var token = Request.Headers["Authorization"];
            if (!_userSrv.ValidateVendorToken(token, out var claims)) return Unauthorized("Invalid token");

            var userid = Convert.ToInt32(claims.First(c => c.Type == "id").Value);
            var vuid = claims.First(c => c.Type == "vuid").Value;

            return await fun(new User() { Id = userid, Vuid = vuid });
        }
    }
}