using Microsoft.AspNetCore.Mvc;
using HabitClass;
using Factory;

[ApiController] 
public class habitController : ControllerBase {

    [HttpGet]
    [Route("api/Habit/GetHabits")]
    public async Task<IActionResult> GetHabits() {
        try {
            HabitFactory factory = new();

            IEnumerable<HabitRecord> habits =
                factory
                .Reader()
                .Read()
                .ToList();

            return Ok(habits);
        }
        catch (Exception ex) {
           return StatusCode(500, ex.Message);
        }
    }

}