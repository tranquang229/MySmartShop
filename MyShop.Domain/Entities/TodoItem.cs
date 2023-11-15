using MyShop.Domain.Common;
using MyShop.Domain.Enums;

namespace MyShop.Domain.Entities;
public class TodoItem : BaseAuditableEntity
{
    public Guid ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    public bool Done { get; set; }

}