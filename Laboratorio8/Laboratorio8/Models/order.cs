using System;
using System.Collections.Generic;

namespace Laboratorio8.Models;

public partial class order
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual client Client { get; set; } = null!;

    public virtual ICollection<orderdetail> orderdetails { get; set; } = new List<orderdetail>();
}
