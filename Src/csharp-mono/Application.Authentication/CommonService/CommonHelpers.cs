using Bridge.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.CommonService
{
    class CommonHelpers
    {
        private readonly IConfiguration _configuration;
        public CommonHelpers(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<object> GenerateJwtToken(string email, ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            string test =_configuration["JwtIssuerOptions:JwtKey"]; 

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtIssuerOptions:JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtIssuerOptions:JwtExpireDays"]));
            IdentityModelEventSource.ShowPII = true;

            var token = new JwtSecurityToken(
                _configuration["JwtIssuerOptions:JwtIssuer"],
                _configuration["JwtIssuerOptions:JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
