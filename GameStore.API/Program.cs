using GameStore.API.Data;
using GameStore.API.Endpoints;


var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);


var app = builder.Build();

app.MapGameEndpoints();
app.MapGenresEndpoint(); 

await app.MigrateDbAsync();

app.Run();
