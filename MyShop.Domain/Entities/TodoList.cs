using MyShop.Domain.Common;
using MyShop.Domain.ValueObjects;

namespace MyShop.Domain.Entities;
public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }
    public Colour Colour { get; set; } = Colour.White;

    public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();
}
