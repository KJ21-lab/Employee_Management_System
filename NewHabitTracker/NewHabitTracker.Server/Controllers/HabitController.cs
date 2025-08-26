//using DataAccess.Implementations;
//using DataAccess.Interfaces;

//using Factory;

//using HabitClass;

//using Microsoft.AspNetCore.Mvc;

//using NewHabitTracker.Server.Models.Interfaces;

//[ApiController]
//public class habitController : ControllerBase {

//    [HttpGet]
//    [Route("api/Habit/GetHabits")]
//    public async Task<IActionResult> GetHabits() {
//        try {

//            IEnumerable<IHabitRecord> habits =
//                factory
//                .ReadHabits()
//                .Result
//                .ToList();

//            return Ok(habits);
//        } catch (Exception ex) {
//            return StatusCode(500, ex.Message);
//        }
//    }

//}