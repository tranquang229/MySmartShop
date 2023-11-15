using MyShop.Domain.Common;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Events;
public class TodoItemDeletedEvent : BaseEvent
{
    public TodoItemDeletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
