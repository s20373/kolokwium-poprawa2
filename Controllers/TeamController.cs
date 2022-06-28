using kolokwium_poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_poprawa.Controllers
{
    public class TeamController : ControllerBase
    {
        private readonly IDbService _dbService;

        public TeamController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeam(int teamId)
        {
            try
            {
                if (teamId < 0) return BadRequest("Id cannot be less than 0");
                if (await _dbService.TeamExists(teamId) == false) return NotFound("No such team");

                return Ok(await _dbService.GetTeam(teamId));
            }
            catch (System.Exception)
            {
                return Conflict();
            }
        }
    }
}
