﻿using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Contracts;

public record class UpdateGameContract
(
     [Required][StringLength(50)] string Name, 
     int GenreId,
     [Range(1,100)]decimal Price,
     DateOnly ReleaseDate
);
