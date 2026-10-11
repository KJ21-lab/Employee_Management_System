using BusinessRules.Employees.Interfaces;

using DependencyInjectors;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class EmployeeController : BaseApiController {

   public EmployeeController(IBusinessRulesInjector businessRulesInjector, IConfiguration configuration)
        : base(businessRulesInjector, configuration) {
   }

   [HttpGet("api/Employee/GetEmployees")]
   public async Task<IActionResult> GetEmployees() {

      IEnumerable<IEmployeeEntity> employees =
          await _businessRulesInjector
          .EmployeeBusinessRules()
          .Reader()
          .ReadAll();

      return Ok(employees);
   }

   [HttpGet("api/Employee/GetEmployee/{employee_uid}")]
   public async Task<IActionResult> GetEmployees(string employee_uid) {

         IEmployeeEntity employees =
              await _businessRulesInjector
             .EmployeeBusinessRules()
             .Reader()
             .Read(Guid.Parse(employee_uid));

         return Ok(employees);
   }

   [HttpPost("api/Employee/CreateEmployee")]
   public async Task<IActionResult> CreateEmployee([FromBody] UpsertEmployeeRequestModel model) {

      await _businessRulesInjector
          .EmployeeBusinessRules()
          .Writer()
          .UpsertEmployee((config) => {
             config.Name       = model.employee_name;
             config.JobTitle   = model.employee_job_title;
             config.HireDate   = DateTime.Parse(model.employee_hire_date);
             config.EmployeeID = int.Parse(model.employee_id);
          });

      return Ok();
   }

   [HttpPut("api/Employee/UpdateEmployee")]
   public async Task<IActionResult> UpdateEmployee([FromBody] UpsertEmployeeRequestModel model) {

      await _businessRulesInjector
          .EmployeeBusinessRules()
          .Writer()
          .UpsertEmployee(
              employeeUID: Guid.Parse(model.employee_uid),
              (config) => {
                  config.Name       = model.employee_name;
                  config.JobTitle   = model.employee_job_title;
                  config.HireDate   = DateTime.Parse(model.employee_hire_date);
                  config.EmployeeID = int.Parse(model.employee_id);
          });

      return Ok();
   }
   public class UpsertEmployeeRequestModel {
      public string employee_uid { get; set; } = string.Empty;
      public string employee_name { get; set; } = string.Empty;

      public string employee_job_title { get; set; } = string.Empty;

      public string employee_hire_date { get; set; } = string.Empty;

      public string employee_id { get; set; } = string.Empty;
   }

   [HttpDelete("api/Employee/DeleteEmployee/{employee_uid}")]
   public async Task<IActionResult> DeleteEmployee([FromRoute] string employee_uid) {

      await _businessRulesInjector
          .EmployeeBusinessRules()
          .Deleter()
          .DeleteEmployee(Guid.Parse(employee_uid));

      return Ok();
   }

   public class DeleteEmployeeRequestModel {
      public string employee_uid { get; set; } = string.Empty;
   }
}