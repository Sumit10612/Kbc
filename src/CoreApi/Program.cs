using Common.Data;
using Common.Data.Mongo;
using Common.Security;
using Common.Security.AzureAd;
using CoreApi;
using CoreApi.Data.Entities;
using CoreApi.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAzureAdAuthentication();

builder.Services.AddMongoDatabase()
    .AddMongoRepository<Game>();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())
    );

var app = builder.Build();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", async (IRepository<Game> repo, AuthenticatedUser user) =>
    Results.Ok((await repo.GetAllAsync(d => d.OwnerId == user.Id)).ToGameInfo())
);

app.MapGet("/{id}", async (Guid id, IRepository<Game> repo, AuthenticatedUser user) =>
    Results.Ok((await repo.GetAsync(d => d.Id == id && d.OwnerId == user.Id)).AsDto())
);

app.MapPost("/", async (CreateGameDto dto, IRepository<Game> repo, AuthenticatedUser user) =>
{
    var gameToInsert = dto.AsEntity();
    gameToInsert.OwnerId = user.Id;

    await repo.CreateAsync(gameToInsert);

    return Results.Created("", gameToInsert.Id);
});

app.MapPut("/", async (Guid id, UpdateGameDto dto, IRepository<Game> repo, AuthenticatedUser user) =>
{
    var gameToUpdate = await repo.GetAsync(d => d.Id == id);
    if (gameToUpdate == null)
        return Results.NotFound();
    if (gameToUpdate.OwnerId != user.Id)
        return Results.Forbid();

    gameToUpdate.Questions = dto.Questions.AsEntity();
    gameToUpdate.IsPrivate = dto.IsPrivate;
    gameToUpdate.Description = dto.Description;
    gameToUpdate.Name = dto.Name;

    await repo.UpdateAsync(id, gameToUpdate);

    return Results.Ok(gameToUpdate.ToGameInfo());
});

app.MapDelete("/{id}", async (Guid id, IRepository<Game> repo, AuthenticatedUser user) =>
{
    var gameToDelete = await repo.GetAsync(d => d.Id == id);
    if (gameToDelete == null)
        return Results.NotFound();
    else if (gameToDelete.OwnerId != user.Id)
        return Results.Forbid();

    await repo.RemoveAsync(id);

    return Results.Ok(gameToDelete);
});

app.Run();
