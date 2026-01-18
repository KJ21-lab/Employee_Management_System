using BusinessRules.Employees.Interfaces;
using BusinessRules.LoginPage;

using DependencyInjectors;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class AccountController : BaseApiController {
   public AccountController(IBusinessRulesInjector businessRulesInjector, IConfiguration configuration)
     : base(businessRulesInjector, configuration) {
   }

   [HttpGet]
   [Route("api/Accounts/GetAccounts")]
   public async Task<IActionResult> GetAccounts() {
      try {
         IEnumerable<IAccountEntity> accounts =
            await _businessRulesInjector
               .AccountBusinessRules()
               .Reader()
               .ReadAll();

         return Ok(accounts);
      } catch (Exception ex) {
         return StatusCode(500, ex.Message);
      }
   }
}
