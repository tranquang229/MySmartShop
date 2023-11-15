using MyShop.Domain.Common;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Events;
public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
