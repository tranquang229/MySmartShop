using MediatR;
using MyShop.Application.Common.Interfaces;
using MyShop.Application.Common.Models;
using MyShop.Application.Common.Security;
using MyShop.Domain.Enums;

namespace MyShop.Application.TodoLists.Queries.GetTodos;

[Authorize]
public record class GetTodosQuery : IRequest<TodosVm>;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodosVm>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return new TodosVm()
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new LookupDto() { Id = (int)p, Title = p.ToString() })
                .ToList(),
            Lists = await _context.TodoLists
                .AsNoTracking()
                .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}