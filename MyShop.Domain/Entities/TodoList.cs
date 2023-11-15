using MyShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.ValueObjects;

namespace MyShop.Domain.Entities;
public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }
    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
