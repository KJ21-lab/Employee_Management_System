using DependencyInjectors;

using EmployeeMangementSystem.Server;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class AuthController : BaseApiController {

   public AuthController(IBusinessRulesInjector businessRulesInjector, IConfiguration configuration)
       : base(businessRulesInjector, configuration) {
   }

   [HttpPost("api/login")]
   [AllowAnonymous]
   public async Task<IActionResult> Login([FromBody] LoginRequest_Model model, [FromServices] ITokenService tokenService) {

      // 1. Validate the incoming request format
      if (!ModelState.IsValid) return BadRequest(ModelState);

      // 2. Verify user credentials against business rules/database
      var result = await _businessRulesInjector
         .LoginPageBusinessRules()
         .Reader()
         .Login(model.Username, model.Password);

      if (!result.Succeeded || result.Account is null)
         return Unauthorized("Invalid credentials.");

      var tokenString = tokenService.GetToken(model.Username);

      return Ok(new { token = tokenString });
   }

   public class LoginRequest_Model {
       public string Username { get; set; } = string.Empty;
       public string Password { get; set; } = string.Empty;
   }
}