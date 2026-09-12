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

   protected IActionResult ServerError(string message) => StatusCode(500, message);
}