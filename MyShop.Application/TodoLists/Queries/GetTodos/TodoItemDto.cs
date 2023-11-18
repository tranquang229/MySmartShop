using MyShop.Domain.Entities;

namespace MyShop.Application.TodoLists.Queries.GetTodos;
public class TodoItemDto
{
    public Guid Id { get; set; }

    public Guid TodoListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }

    public int Priority { get; set; }

    public string? Note { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoItem, TodoItemDto>()
                .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
        }
    }
}
