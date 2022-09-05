using Common.Models;

namespace CoreApi.Data.Entities;

public class Game : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Question> Questions { get; set; }
    public bool IsPrivate { get; set; }
    public string OwnerId { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}
