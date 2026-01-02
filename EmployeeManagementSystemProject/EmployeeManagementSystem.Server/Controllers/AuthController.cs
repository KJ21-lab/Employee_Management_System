using DependencyInjectors;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
public class AuthController : BaseApiController {

   public AuthController(IBusinessRulesInjector businessRulesInjector, IConfiguration configuration)
       : base(businessRulesInjector, configuration) {
   }

   [HttpGet("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest_Model model) {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _businessRulesInjector
         .LoginPageBusinessRules()
         .Reader()
         .Login(model.Username, model.Password);

        if (!result.Succeeded || result.Account is null) return Unauthorized("Invalid credentials.");

        var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.Sub, result.Account.AccountID.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, result.Account.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var jwt = _configuration.GetSection("JwtSettings");
        var secret = jwt["SecretKey"] ?? throw new InvalidOperationException("JwtSettings:SecretKey missing.");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddHours(1);

        var token = new JwtSecurityToken(
            issuer: jwt["ValidIssuer"],
            audience: jwt["ValidAudience"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: creds
        );

        return Ok(new {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expires
        });
    }

    public class LoginRequest_Model {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}