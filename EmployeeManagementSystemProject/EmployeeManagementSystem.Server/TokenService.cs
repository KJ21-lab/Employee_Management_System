using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeMangementSystem.Server {

   public interface ITokenService {
      string GetToken(string userName, string userID = "123");

   }
   public class TokenService(IConfiguration configuration) {
      
      public string GetToken(string userName, string userID = "123") {
         // 3. Retrieve the JWT secret from configuration
         var jwtSettings = configuration.GetSection("JwtSettings");
         var secretKey = jwtSettings["SecretKey"];

         if (string.IsNullOrEmpty(secretKey))
            throw new InvalidOperationException("JWT Secret Key is missing from appsettings.json");

         // 4. Set up the cryptographic signature
         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
         var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

         // 5. Define the token payload (Claims)
         var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userID),
            new Claim(JwtRegisteredClaimNames.UniqueName, userName)
         };

         // Modern, less error-prone way to generate tokens using a Descriptor
         var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = creds
         };

         var tokenHandler = new JwtSecurityTokenHandler();
         var token = tokenHandler.CreateToken(tokenDescriptor);

         return tokenHandler.WriteToken(token);
      }
   }
}
