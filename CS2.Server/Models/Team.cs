using System;
using System.Collections.Generic;

namespace CS2.Server.Models;

public partial class Team
{
    public int Id { get; set; }

    public string? TeamName { get; set; }

    public int? TournamentWins { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
