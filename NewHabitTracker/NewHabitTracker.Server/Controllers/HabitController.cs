using DataAccess.Implementations;
using DataAccess.Interfaces;

using DependencyInjectors;

using Factory;

using HabitBusinessRulesInterfaces;

using HabitClass;

using Microsoft.AspNetCore.Mvc;

using NewHabitTracker.Server.Models.Interfaces;

[ApiController]
public class HabitController : BaseApiController {

    public HabitController(IBusinessRulesInjector businessRulesInjector)
       : base(businessRulesInjector) {
    }

    [HttpGet]
    [Route("api/Habit/GetHabits")]
    public async Task<IActionResult> GetHabits() {
        try {

            IEnumerable<IHabitEntity> habits =
                await _businessRulesInjector
                .HabitBusinessRules()
                .Reader()
                .ReadAll();

            return Ok(habits);
        } catch (Exception ex) {
            return StatusCode(500, ex.Message);
        }
    }

}