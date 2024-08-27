using CS2.Server.Models;
using CS2.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController(ITeamService _teamService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Team>> Get()
        {
            return await _teamService.GetTeamsList();
        }
    }
}
