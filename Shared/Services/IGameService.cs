using Blazor.Shared.Entities;

namespace Blazor.Shared.Services;

public interface IGameService
{
    Task<List<Game>> GetAllGames();
    Task<Game> GetGameById(int Id);
    Task<Game> AddGame(Game game);
    Task<Game> EditGame(int Id, Game game);
    Task<bool> DeleteGame(int Id);
}