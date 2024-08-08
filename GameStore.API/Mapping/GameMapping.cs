using System;
using GameStore.API.Contracts;

namespace GameStore.API.Mapping;

public static class GameMapping
{
  public static Game ToEntity(this CreateGameContract game) {
     return new Game(){ 
          Name = game.Name,
          GenreId = game.GenreId,
          Price = game.Price,
          ReleaseDate = game.ReleaseDate,
     };
     }

  public static GameSummaryContract ToGameSummaryContract(this Game game) {
      return new(
          game.Id,
          game.Name,
          game.Genre!.Name,
          game.Price,
          game.ReleaseDate
     );
     }

     
  public static GameDetailContract ToGameDetailContract(this Game game) {
      return new(
          game.Id,
          game.Name,
          game.GenreId,
          game.Price,
          game.ReleaseDate
     );
     }

      public static Game ToEntity(this UpdateGameContract game, int id) {

     return new Game(){ 
          Id = id,
          Name = game.Name,
          GenreId = game.GenreId,
          Price = game.Price,
          ReleaseDate = game.ReleaseDate,
     };
     }
}
