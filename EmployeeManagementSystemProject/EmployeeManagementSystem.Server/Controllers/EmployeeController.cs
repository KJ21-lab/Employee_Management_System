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
         return ServerError(ex.Message);
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
         return ServerError(ex.Message);
      }
   }
   [HttpPost]
   [Route("api/Employee/CreateEmployee")]
   public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequestModel model) {
      try {

         await _businessRulesInjector
             .EmployeeBusinessRules()
             .Writer()
             .Upsert((config) => {
                config.Name       = model.employee_name;
                config.JobTitle   = model.employee_job_title;
                config.HireDate   = DateTime.Parse(model.employee_hire_date);
                config.EmployeeID = int.Parse(model.employee_id);
             });

         return Ok();
      } catch (Exception ex) {
         return ServerError(ex.Message);
      }
   }

   public class CreateEmployeeRequestModel {
      public string employee_name       { get; set; } = string.Empty;

      public string employee_job_title { get; set; } = string.Empty;
      
      public string employee_hire_date { get; set; } = string.Empty;
      
      public string employee_id        { get; set; } = string.Empty;
   }

}