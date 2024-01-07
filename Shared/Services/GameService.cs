using Blazor.Shared.Data;
using Blazor.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Shared.Services;

public class GameService : IGameService
{
    private readonly DataContext _context;

    public GameService(DataContext context)
    {
        _context = context;
    }

    public async Task<Game> GetGameById(int Id)
    {
        return await _context.Games.FindAsync(Id);
    }

    public async Task<Game> AddGame(Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<Game> EditGame(int Id, Game game)
    {
        var dbGame = await _context.Games.FindAsync(Id);
        if (dbGame != null)
        {
            dbGame.Name = game.Name;
            await _context.SaveChangesAsync();
            return dbGame;
        }

        throw new Exception("Game not found");
    }

    public async  Task<bool> DeleteGame(int Id)
    {
        var dbGame = await _context.Games.FindAsync(Id);
        if (dbGame != null)
        {
            _context.Remove(dbGame);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<List<Game>> GetAllGames()
    {
        await Task.Delay(500);
        var games = await _context.Games.ToListAsync();
        Console.WriteLine(@$"Service: Game count {games.Count}");
        return games;
    }


}