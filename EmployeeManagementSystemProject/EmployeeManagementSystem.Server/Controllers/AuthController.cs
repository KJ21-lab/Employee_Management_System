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

   [HttpPost("api/login")]
   [AllowAnonymous]
   public async Task<IActionResult> Login([FromBody] LoginRequest_Model model) {

      // 1. Validate the incoming request format
      if (!ModelState.IsValid) return BadRequest(ModelState);

      // 2. Verify user credentials against business rules/database
      var result = await _businessRulesInjector
         .LoginPageBusinessRules()
         .Reader()
         .Login(model.Username, model.Password);

      if (!result.Succeeded || result.Account is null)
         return Unauthorized("Invalid credentials.");

      // 3. Retrieve the JWT secret from configuration
      var jwtSettings = _configuration.GetSection("JwtSettings");
      var secretKey = jwtSettings["SecretKey"];

      if (string.IsNullOrEmpty(secretKey))
         throw new InvalidOperationException("JWT Secret Key is missing from appsettings.json");

      // 4. Set up the cryptographic signature
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      // 5. Define the token payload (Claims)
      var claims = new[] {
         new Claim(JwtRegisteredClaimNames.Sub, "123"),
         new Claim(JwtRegisteredClaimNames.UniqueName, model.Username)
};

      // 6. Assemble the final JWT object
      var token = new JwtSecurityToken(
          claims: claims,
          expires: DateTime.UtcNow.AddMinutes(30),
          signingCredentials: creds
      );

      // 7. Serialize the token to a string and return it to the client
      return Ok(new {
         token = new JwtSecurityTokenHandler().WriteToken(token)
      });
   }

   public class LoginRequest_Model {
       public string Username { get; set; } = string.Empty;
       public string Password { get; set; } = string.Empty;
   }
}