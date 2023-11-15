using MyShop.Domain.Entities;

namespace MyShop.Application.Common.Models;
public  class LookupDto
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, LookupDto>();
            CreateMap<TodoItem, LookupDto>();
        }
    }
}
