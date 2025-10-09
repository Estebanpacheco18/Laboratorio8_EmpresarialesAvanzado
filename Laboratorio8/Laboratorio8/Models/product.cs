using System;
using System.Collections.Generic;

namespace Laboratorio8.Models;

public partial class product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<orderdetail> orderdetails { get; set; } = new List<orderdetail>();
}
