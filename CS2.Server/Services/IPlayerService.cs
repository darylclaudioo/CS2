using CS2.Server.Models;

namespace CS2.Server.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetPlayerList();
        Task<Player> GetPlayerById(int id);
        Task<Player> CreatePlayer(Player player);
        Task UpdatePlayer(Player player);
        Task DeletePlayer(Player player);
    }
}
