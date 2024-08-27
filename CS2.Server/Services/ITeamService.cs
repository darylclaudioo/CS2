using CS2.Server.Models;

namespace CS2.Server.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetTeamsList();
    }
}
