using Common.Data;
using Common.Data.Mongo;
using Common.Security;
using Common.Security.AzureAd;
using CoreApi;
using CoreApi.Data.Entities;
using CoreApi.Dtos;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddAzureAdAuthentication();

builder.Services.AddMongoDatabase()
    .AddMongoRepository<Game>();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())
    );

var app = builder.Build();

app.UseCors();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapGet("/", async (IRepository<Game> repo) =>
    Results.Ok((await repo.GetAllAsync(d => d.OwnerId == "3540bae1-079d-43a3-b0d8-13ffff9dc782")).ToGameInfo())
);

app.MapGet("/{id}", async (Guid id, IRepository<Game> repo) =>
    Results.Ok((await repo.GetAsync(d => d.Id == id && d.OwnerId == "3540bae1-079d-43a3-b0d8-13ffff9dc782")).AsDto())
);

app.MapPost("/", async (CreateGameDto dto, IRepository<Game> repo) =>
{
    var gameToInsert = dto.AsEntity();
    gameToInsert.OwnerId = "3540bae1-079d-43a3-b0d8-13ffff9dc782";

    await repo.CreateAsync(gameToInsert);

    return Results.Created("", gameToInsert.Id);
});

app.MapPut("/", async (Guid id, UpdateGameDto dto, IRepository<Game> repo) =>
{
    var gameToUpdate = await repo.GetAsync(d => d.Id == id);
    if (gameToUpdate == null)
        return Results.NotFound();
    if (gameToUpdate.OwnerId != "3540bae1-079d-43a3-b0d8-13ffff9dc782")
        return Results.Forbid();

    gameToUpdate.Questions = dto.Questions.AsEntity();
    gameToUpdate.IsPrivate = dto.IsPrivate;
    gameToUpdate.Description = dto.Description;
    gameToUpdate.Name = dto.Name;

    await repo.UpdateAsync(id, gameToUpdate);

    return Results.Ok(gameToUpdate.ToGameInfo());
});

app.MapDelete("/{id}", async (Guid id, IRepository<Game> repo) =>
{
    var gameToDelete = await repo.GetAsync(d => d.Id == id);
    if (gameToDelete == null)
        return Results.NotFound();
    else if (gameToDelete.OwnerId != "3540bae1-079d-43a3-b0d8-13ffff9dc782")
        return Results.Forbid();

    await repo.RemoveAsync(id);

    return Results.Ok(gameToDelete);
});

app.Run();
