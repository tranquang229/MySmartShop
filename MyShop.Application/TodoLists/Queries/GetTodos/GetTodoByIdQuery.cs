using MediatR;
using MyShop.Application.Common.Interfaces;
using MyShop.Application.Common.Models;
using MyShop.Domain.Enums;

namespace MyShop.Application.TodoLists.Queries.GetTodos;

public record class GetTodoByIdQuery(Guid Id) : IRequest<TodoListDto>;

public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoListDto>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TodoListDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todoList = await _context
            .TodoLists.Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
       
        return _mapper.Map<TodoListDto>(todoList);
    }
}