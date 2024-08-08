using GameStore.API.Contracts;
using GameStore.API.Data;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GamesEndpoints
{
const  string GetGameEndpointName = "GetGame";

public static RouteGroupBuilder MapGameEndpoints(this WebApplication  app){

var group = app.MapGroup("games")
                          .WithParameterValidation();

     //Get Games(ALL)
     group.MapGet("/", async (GameStoreContext dbContext)=>
                await dbContext.Games
               .Include(game => game.Genre)
               .Select(game => game.ToGameSummaryContract())
               .AsNoTracking()
               .ToListAsync()
     );

//Get game by ID ()
group.MapGet("/{id}", async(int id, GameStoreContext dbContext)=> {

    Game? game = await dbContext.Games.FindAsync(id);
    return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailContract());

}).WithName(GetGameEndpointName);

//New game (POST)
group.MapPost("/", async(CreateGameContract newGame, GameStoreContext dbContext) => {

     Game game = newGame.ToEntity();
     dbContext.Games.Add(game);
     await dbContext.SaveChangesAsync(); 


 return Results.CreatedAtRoute(GetGameEndpointName, new {id=game.Id}, game.ToGameDetailContract());
});

// Update Game()

group.MapPut("/{id}",async(int id, UpdateGameContract updateGame, GameStoreContext dbContext) => {
     
   var existingGame = await dbContext.Games.FindAsync(id);     

     if(existingGame is null){
          return Results.NotFound();
     }

   dbContext.Entry(existingGame)
   .CurrentValues
   .SetValues(updateGame.ToEntity(id));

  await dbContext.SaveChangesAsync();   

     return Results.NoContent();
});

// Delete Game()

group.MapDelete("/{id}", async(int id, GameStoreContext dbContext)=>{
  await dbContext.Games.Where(game=>game.Id == id). ExecuteDeleteAsync(); 

     return Results.NoContent();
});

return group;
}

}
