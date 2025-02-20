﻿namespace GameStore.API.Contracts;

public record class GameSummaryContract
(
     int Id, 
     string Name, 
     string Genre, 
     decimal Price,
     DateOnly ReleaseDate
);
