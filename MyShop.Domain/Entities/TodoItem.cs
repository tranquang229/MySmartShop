using MyShop.Domain.Common;
using MyShop.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Domain.Entities;
public class TodoItem : BaseAuditableEntity
{
    public Guid TodoListId { get; set; }

    [ForeignKey("TodoListId")]
    public virtual TodoList TodoList { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    public bool Done { get; set; }

}