using CS2.Server.Models;
using CS2.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController(IPlayerService _playerService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Player>> Get()
        {
            return await _playerService.GetPlayerList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var player = await _playerService.GetPlayerById(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> Post(Player player)
        {
            await _playerService.CreatePlayer(player);
            return CreatedAtAction("Post", new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest("Not a valid player Id");
            }

            await _playerService.UpdatePlayer(player);

            return Ok(player);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid player Id");
            }

            var player = await _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }

            await _playerService.DeletePlayer(player);
            return NoContent();
        }
    }
}
