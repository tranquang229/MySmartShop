using MediatR;
using MyShop.API.Infrastructure;
using MyShop.Application.Common.Security;
using MyShop.Application.TodoLists.Commands.CreateTodoList;
using MyShop.Application.TodoLists.Commands.DeleteTodoList;
using MyShop.Application.TodoLists.Commands.UpdateTodoLists;
using MyShop.Application.TodoLists.Queries.GetTodos;

namespace MyShop.API.Endpoints;

public class TodoLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetTodoLists)
            //.MapPost(CreateTodoList)
            .MapPut(UpdateTodoList, "{id}")
            .MapDelete(DeleteTodoList, "{id}");

        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateTodoList)
            .MapGet(GetTodoListById, "{id}");
    }

    public async Task<TodosVm> GetTodoLists(ISender sender)
    {
        return await sender.Send(new GetTodosQuery());
    }

    public async Task<TodoListDto> GetTodoListById(ISender sender, Guid id)
    {
        return await sender.Send(new GetTodoByIdQuery(id));
    }

   
    public async Task<Guid> CreateTodoList(ISender sender, CreateTodoListCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateTodoList(ISender sender, Guid id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTodoList(ISender sender, Guid id)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return Results.NoContent();
    }
}
