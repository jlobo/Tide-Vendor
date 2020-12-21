using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<SensitiveController> _logger;

        public SensitiveController(UserService service, ILogger<SensitiveController> logger)
        {
            _sensitiveSrv = new SensitiveService();
            _userSrv = service;
            _logger = logger;
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
                if (usr.Id != info.UserId) {
                    _logger.LogInformation("Denied update of user {0} with account {1}", info.UserId, usr.Id);
                    return Unauthorized("Invalid token");
                }
                
                await _sensitiveSrv.Update(info);
                _logger.LogInformation("User {0} was updated", usr.Id);
                return Ok();
            });
        }

        private async Task<ActionResult> CheckToken(Func<User, Task<ActionResult>> fun)
        {
            var token = Request.Headers["Authorization"];
            if (!_userSrv.ValidateVendorToken(token, out var claims)) {
                var action = ControllerContext.RouteData.Values["action"];
                _logger.LogInformation($"Invalid token for action {action}: {{0}}", token);
                return Unauthorized("Invalid token");
            }

            var userid = Convert.ToInt32(claims.First(c => c.Type == "id").Value);
            var vuid = claims.First(c => c.Type == "vuid").Value;

            return await fun(new User() { Id = userid, Vuid = vuid });
        }
    }
}