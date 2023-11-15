using MyShop.Domain.Common;
using MyShop.Domain.Entities;

namespace MyShop.Domain.Events;
public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
