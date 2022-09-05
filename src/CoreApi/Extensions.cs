using CoreApi.Data.Entities;
using CoreApi.Dtos;

namespace CoreApi;

public static class Extensions
{
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(game.Id,
            game.Name,
            game.Description,
            game.Questions.Select(question => new QuestionDto(question.Text,
                question.Options.Select(option => new OptionDto(option.Text, option.IsCorrect)),
                question.Information,
                question.Order,
                question.IsPrivate)),
            game.DateCreated,
            game.IsPrivate);
    }

    public static IEnumerable<GameInfoDto> ToGameInfo(this IEnumerable<Game> games) => games.Select(game => game.ToGameInfo());

    public static GameInfoDto ToGameInfo(this Game game) =>
        new GameInfoDto(game.Id, game.Name, game.Description, game.DateCreated);

    public static Game AsEntity(this CreateGameDto dto) => new Game
    {
        Id = Guid.NewGuid(),
        Name = dto.Name,
        Questions = dto.Questions.AsEntity(),
        Description = dto.Description,
        DateCreated = DateTimeOffset.UtcNow,
        IsPrivate = dto.IsPrivate,
    };

    public static IEnumerable<Question> AsEntity(this IEnumerable<QuestionDto> dtos) => dtos.Select(dto => dto.AsEntity());

    public static Question AsEntity(this QuestionDto dto) => new Question
    {
        Information = dto.Info,
        Text = dto.Text,
        IsPrivate = dto.IsPrivate,
        Order = dto.Order,
        Options = dto.Options.AsEntity()
    };

    public static IEnumerable<Option> AsEntity(this IEnumerable<OptionDto> dtos) => dtos.Select(dto => dto.AsEntity());

    public static Option AsEntity(this OptionDto dto) => new Option { Text = dto.Text, IsCorrect = dto.IsCorrect };
}
