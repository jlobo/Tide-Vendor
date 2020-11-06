using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Tide.Models;
using Tide.Vendor.Models;

namespace Tide.Vendor.Classes {
    public class UserService {
        // Never store sensitive information in the clear like this. This is done for simplicity of the demo
        private const string Bearer = "v3DpAiBzk7sq3EAfn#3^Tj2oH4memXBc!#L@Sjb%l5wI%H#Y#YkNDPtpqErKQ&O7iU";

        public void HandleTideAuthenticationResult(HttpContext context, AuthRequest authRequest) {
            if (!authRequest.Success) context.Response.StatusCode = 401;
            else {
                context.Response.Headers.Add("Access-Control-Expose-Headers", "*");
                context.Response.Headers["Authorization"] = LoginOrRegister(authRequest);
            }
        }

        private string LoginOrRegister(AuthRequest request) {
            using (var db = new VendorContext()) {
                var user = db.Users.FirstOrDefault(u => u.Vuid == request.Vuid);
                if (user == null) {
                    user = new User {PublicKey = request.PublicKey, Vuid = request.Vuid, Name = "New Player"};
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                return GenerateVendorToken(user);
            }
        }

        public bool ValidateVendorToken(string token,out List<Claim> claims) {
         claims = new List<Claim>();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Bearer));

            var tokenHandler = new JwtSecurityTokenHandler();

            try {
                tokenHandler.ValidateToken(token, new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key
                }, out var validatedToken);

                var securityToken = new JwtSecurityToken(token);
                claims = securityToken.Claims.ToList();
            }
            catch (Exception e) {
                return false;
            }

            return true;
        }

        private string GenerateVendorToken(User user) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Bearer);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", user.Name),
                    new Claim("vuid", user.Vuid)
                }),
                Expires = DateTime.Now.AddDays(14),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                IssuedAt = DateTime.Now
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}