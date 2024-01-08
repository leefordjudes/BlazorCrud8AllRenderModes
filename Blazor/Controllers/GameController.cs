using Blazor.Shared.Entities;
using Blazor.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(IGameService gameService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Game>> GetGameById(int Id)
        {
            var game = await gameService.GetGameById(Id);
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            var addedGame = await gameService.AddGame(game);
            return Ok(addedGame);
        }
        
        [HttpPut("{Id:int}")]
        public async Task<ActionResult<Game>> EditGame(int Id, Game game)
        {
            var updatedGame = await gameService.EditGame(Id,game);
            return Ok(updatedGame);
        }
        
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<Game>> DeleteGame(int Id)
        {
            var result = await gameService.DeleteGame(Id);
            return Ok(result);
        }
    }
}
