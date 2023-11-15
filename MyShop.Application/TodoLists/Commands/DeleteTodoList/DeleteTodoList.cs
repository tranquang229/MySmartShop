﻿using MediatR;
using MyShop.Application.Common.Interfaces;

namespace MyShop.Application.TodoLists.Commands.DeleteTodoList;
public record DeleteTodoListCommand(Guid Id) : IRequest;

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        //Guard.Against.NotFound(request.Id, entity);

        _context.TodoLists.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}