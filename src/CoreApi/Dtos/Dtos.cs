using System.ComponentModel.DataAnnotations;

namespace CoreApi.Dtos;

public record OptionDto([Required] string Text, [Required] bool IsCorrect);

public record QuestionDto([Required] string Text, [Required] IEnumerable<OptionDto> Options,
    string Info, int Order, bool IsPrivate);

public record GameDto(Guid Id, string Name, string Description, IEnumerable<QuestionDto> Questions,
    DateTimeOffset DateCreated, bool IsPrivate);

public record CreateGameDto([Required] string Name, string Description, [Required] IEnumerable<QuestionDto> Questions,
    bool IsPrivate);

public record UpdateGameDto(string Name, string Description, IEnumerable<QuestionDto> Questions, bool IsPrivate);

public record GameInfoDto(Guid Id, string Name, string Description, DateTimeOffset DateCreated);