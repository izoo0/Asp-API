using System;
using GameStore.API.Data;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GenresEndpoint
{
  public static RouteGroupBuilder MapGenresEndpoint(this WebApplication app)
  {
     var group = app.MapGroup("genres");

     group.MapGet("/", async (GameStoreContext dbContext) =>
        await dbContext.Genres
        .Select(genre=>genre.ToContract())
        .AsNoTracking()
        .ToListAsync()
     );
     return group;
  }
}
