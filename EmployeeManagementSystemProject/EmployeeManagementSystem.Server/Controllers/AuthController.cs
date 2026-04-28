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
      
     if (!ModelState.IsValid) return BadRequest(ModelState);
      
      var result = await _businessRulesInjector
         .LoginPageBusinessRules()
         .Reader()
         .Login(model.Username, model.Password);
      
      if (!result.Succeeded || result.Account is null) 
         return Unauthorized("Invalid credentials.");
   
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a_very_long_secret_key_that_is_32_chars"));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      
      // 3. THE TOKEN DATA (The "Claims")
      var claims = new[] {
          new Claim(JwtRegisteredClaimNames.Sub, "123"),
          new Claim(JwtRegisteredClaimNames.UniqueName, model.Username)
      };
      
      // 4. GENERATE THE TOKEN
      var token = new JwtSecurityToken(
          claims: claims,
          expires: DateTime.UtcNow.AddMinutes(30),
          signingCredentials: creds
      );
      
      // 5. RETURN THE STRING
      return Ok(new { 
          token = new JwtSecurityTokenHandler().WriteToken(token) 
      });
   }

   public class LoginRequest_Model {
       public string Username { get; set; } = string.Empty;
       public string Password { get; set; } = string.Empty;
   }
}