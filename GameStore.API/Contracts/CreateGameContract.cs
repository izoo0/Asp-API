using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Contracts;

public record class CreateGameContract
(
     [Required][StringLength(50)] string Name, 
     int GenreId, 
     [Range(1,100)]decimal Price,
     DateOnly ReleaseDate
);
