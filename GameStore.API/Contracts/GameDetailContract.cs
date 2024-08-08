namespace GameStore.API.Contracts;

public record class GameDetailContract
(
     int Id, 
     string Name, 
     int GenreId,
     decimal Price,
     DateOnly ReleaseDate
);
