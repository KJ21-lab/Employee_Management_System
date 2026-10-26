using DependencyInjectors;

using Microsoft.AspNetCore.Mvc;

public abstract class BaseApiController : ControllerBase {
    protected readonly IBusinessRulesInjector _businessRulesInjector;
    protected readonly IConfiguration _configuration;

    public BaseApiController(IBusinessRulesInjector businessRulesInjector,
        IConfiguration configuration) {
        _businessRulesInjector = businessRulesInjector;
        _configuration = configuration;
    }

   protected IActionResult MapError(ResultTypes resultType, string message) {
      return resultType switch {
         ResultTypes.NotFound    => NotFound(message),
         _ => ServerError()
      };
   }
   protected IActionResult ServerError() => StatusCode(500, "An unexpected internal server error occurred.");
}