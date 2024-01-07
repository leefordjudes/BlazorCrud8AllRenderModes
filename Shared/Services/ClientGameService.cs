using System.Net.Http.Json;
using Blazor.Shared.Entities;

namespace Blazor.Shared.Services;

public class ClientGameService : IGameService
{
    private readonly HttpClient _httpClient;

    public ClientGameService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Game> GetGameById(int Id)
    {
        var result = await _httpClient.GetFromJsonAsync<Game>("/api/game/{id}");
        return result;
    }

    public async Task<Game> AddGame(Game game)
    {
        var result = await _httpClient.PostAsJsonAsync<Game>("/api/game", game);
        return await result.Content.ReadFromJsonAsync<Game>();

    }

    public async Task<Game> EditGame(int Id, Game game)
    {
        var result = await _httpClient.PutAsJsonAsync<Game>("/api/game/{Id}", game);
        return await result.Content.ReadFromJsonAsync<Game>();
    }

    public async Task<bool> DeleteGame(int Id)
    {
        var result = await _httpClient.DeleteAsync($"/api/game/{Id}");
        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public Task<List<Game>> GetAllGames()
    {
        throw new NotImplementedException();
    }


}