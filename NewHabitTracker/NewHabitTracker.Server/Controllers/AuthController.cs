using BusinessRules.BusinesRules.Employees.Interfaces;

using DependencyInjectors;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class AuthController : BaseApiController {

    public AuthController(IBusinessRulesInjector businessRulesInjector)
       : base(businessRulesInjector) {
    }

    [HttpPost]
    [Route("api/Employee/login")]
    public async Task<IActionResult> Login() {
        try {
            throw new NotImplementedException();
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

}