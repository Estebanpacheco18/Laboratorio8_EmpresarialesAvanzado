using System;
using System.Collections.Generic;

namespace Laboratorio8.Models;

public partial class orderdetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual order Order { get; set; } = null!;

    public virtual product Product { get; set; } = null!;
}
