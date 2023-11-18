using MediatR;

namespace MyShop.Application.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommand : IRequest<Guid>
{
    public Guid ListId { get; init; }

    public string? Title { get; init; }
}