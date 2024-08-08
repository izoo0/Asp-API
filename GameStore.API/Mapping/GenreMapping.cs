using System;
using GameStore.API.Contracts;

namespace GameStore.API.Mapping;

public static class GenreMapping
{
  public static GenreContract ToContract(this Genre genre)
  {
       return new GenreContract
       (
       genre.Id, 
       genre.Name
       );
  }
}
