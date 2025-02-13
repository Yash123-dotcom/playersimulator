using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlayerController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/player
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
    {
        return await _context.Players.ToListAsync();
    }

    // GET: api/player/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> GetPlayer(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null)
        {
            return NotFound();
        }
        return player;
    }

    // POST: api/player
    [HttpPost]
    public async Task<ActionResult<Player>> CreatePlayer(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
    }

    // PUT: api/player/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlayer(int id, Player player)
    {
        if (id != player.Id)
        {
            return BadRequest();
        }
        _context.Entry(player).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/player/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null)
        {
            return NotFound();
        }
        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
