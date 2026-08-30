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

   [HttpGet]
   [Route("api/Employee/GetEmployee")]
   public async Task<IActionResult> GetEmployee(Guid employeeUID) {
      try {

         IEmployeeEntity? employees =
             await _businessRulesInjector
             .EmployeeBusinessRules()
             .Reader()
             .Read(employeeUID);

         return Ok(employees);
      } catch (Exception ex) {
         return StatusCode(500, ex.Message);
      }
   }
   [HttpPost]
   [Route("api/Employee/CreateEmployee")]
   public async Task<IActionResult> CreateEmployee(Guid employeeUID) {
      try {

         IEmployeeEntity? employees =
             await _businessRulesInjector
             .EmployeeBusinessRules()
             .Reader()
             .Read(employeeUID);

         return Ok(employees);
      } catch (Exception ex) {
         return StatusCode(500, ex.Message);
      }
   }

   public class CreateEmployeeRequestModel {
      public string employee_uid         { get; set; }
      public string employee_name        { get; set; }
      public string employee_job_title   { get; set; }
      public string employee_hire_date   { get; set; }
      public string employee_employee_id { get; set; }
   }

}