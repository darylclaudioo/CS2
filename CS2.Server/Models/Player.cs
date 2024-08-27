using System;
using System.Collections.Generic;

namespace CS2.Server.Models;

public partial class Player
{
    public int Id { get; set; }

    public string? PlayerName { get; set; }

    public string? IngameName { get; set; }

    public int? Salary { get; set; }

    public int? IsActive { get; set; }

    public string? Nationality { get; set; }

    public int? TeamId { get; set; }

    public virtual Team? Team { get; set; }
}
