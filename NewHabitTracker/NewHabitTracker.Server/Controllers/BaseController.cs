using DependencyInjectors;

using Microsoft.AspNetCore.Mvc;

public abstract class BaseApiController : ControllerBase {
    protected readonly IBusinessRulesInjector _businessRulesInjector;

    public BaseApiController(IBusinessRulesInjector businessRulesInjector) {
        _businessRulesInjector = businessRulesInjector;
    }
}