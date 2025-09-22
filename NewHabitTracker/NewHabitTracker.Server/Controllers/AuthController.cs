using BusinessRules.Employees.Interfaces;

using DependencyInjectors;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
public class AuthController : BaseApiController {

    public AuthController(IBusinessRulesInjector businessRulesInjector)
       : base(businessRulesInjector) {
    }

    //[HttpPost]
    //[Route("api/Employee/login")]
    //public async Task<IActionResult> Login(LoginRequest_Model request) {
    //    var userManager = // Get UserManager from DI
    //    var signInManager = // Get SignInManager from DI

    //    var result = await signInManager.PasswordSignInAsync(
    //        request.Username,
    //        request.Password,
    //        isPersistent: false,
    //        lockoutOnFailure: false);

    //    if (result.Succeeded) {
    //        var user = await userManager.FindByNameAsync(request.Username);
    //        var token = GenerateJwtToken(user);
    //        return Ok(new { Token = token });
    //    }

    //    return Unauthorized();
    //}

    //private string GenerateJwtToken(IEmployeeEntity user) {
    //    var claims = new List<Claim> {
    //    new Claim(JwtRegisteredClaimNames.Sub, user.EmployeeID),
    //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //    new Claim(ClaimTypes.NameIdentifier, user.Id),
    //    new Claim(ClaimTypes.Name, user.UserName),
    //    // Add more claims as needed, like roles
    //};

    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_that_is_at_least_32_characters_long")); // Store securely in app settings
    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //    var expires = DateTime.Now.AddDays(7);

    //    var token = new JwtSecurityToken(
    //        issuer: "your_api_issuer",
    //        audience: "your_api_audience",
    //        claims: claims,
    //        expires: expires,
    //        signingCredentials: creds
    //    );

    //    return new JwtSecurityTokenHandler().WriteToken(token);
    //}

    public class LoginRequest_Model {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}