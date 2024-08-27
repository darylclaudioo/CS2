using CS2.Server.Data;
using CS2.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace CS2.Server.Services
{
    public class TeamService(CS2Context context) : ITeamService
    {
        private readonly CS2Context _context = context;

        public async Task<IEnumerable<Team>> GetTeamsList()
        {
            return await _context.Teams
                .OrderBy(t => t.Id)
                .Include(t => t.Players)
                .ToListAsync();
        }
    }
}
