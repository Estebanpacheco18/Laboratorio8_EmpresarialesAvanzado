using System;
using System.Collections.Generic;

namespace Laboratorio8.Models;

public partial class client
{
    public int ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<order> orders { get; set; } = new List<order>();
}
