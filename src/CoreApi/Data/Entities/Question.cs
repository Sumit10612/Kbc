using Common.Models;

namespace CoreApi.Data.Entities;

public class Question
{
    public string Text { get; set; }
    public IEnumerable<Option> Options { get; set; }
    public string Information { get; set; }
    public int Order { get; set; }
    public bool IsPrivate { get; set; }
}
