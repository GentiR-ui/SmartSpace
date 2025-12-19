using System;

namespace Domain.Entities;

public class WorkspaceType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PricePerHour { get; set; }

    public ICollection<Workspace>? Workspaces { get; set; }
}
