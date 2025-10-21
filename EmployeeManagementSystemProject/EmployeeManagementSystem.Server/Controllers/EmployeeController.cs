using BusinessRules.Employees.Interfaces;

using DependencyInjectors;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class EmployeeController : BaseApiController {

    public EmployeeController(IBusinessRulesInjector businessRulesInjector)
       : base(businessRulesInjector) {
    }

    [HttpGet]
    [Route("api/Employee/GetEmployees")]
    public async Task<IActionResult> GetEmployees() {
        try {

            IEnumerable<IEmployeeEntity> habits =
                await _businessRulesInjector
                .EmployeeBusinessRules()
                .Reader()
                .ReadAll();

            return Ok(habits);
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

}