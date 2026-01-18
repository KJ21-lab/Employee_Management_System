using BusinessRules.Employees.Interfaces;

using DependencyInjectors;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class EmployeeController : BaseApiController {

   public EmployeeController(IBusinessRulesInjector businessRulesInjector, IConfiguration configuration)
        : base(businessRulesInjector, configuration) {
   }

   [HttpGet]
   [Route("api/Employee/GetEmployees")]
   public async Task<IActionResult> GetEmployees() {
      try {

         IEnumerable<IEmployeeEntity> employees =
             await _businessRulesInjector
             .EmployeeBusinessRules()
             .Reader()
             .ReadAll();

         return Ok(employees);
      } catch (Exception ex) {
         return StatusCode(500, ex.Message);
      }
   }

}