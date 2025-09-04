using HabitBusinessRulesInterfaces;
using Microsoft.AspNetCore.Mvc;

public abstract class BaseApiController : ControllerBase {
    protected readonly IBusinessRulesInjector _businessRulesInjector;

    // The constructor injects the dependency and makes it available to all
    // child controllers. The 'protected' access modifier allows child classes
    // to access this field.
    public BaseApiController(IBusinessRulesInjector businessRulesInjector) {
        _businessRulesInjector = businessRulesInjector;
    }
}