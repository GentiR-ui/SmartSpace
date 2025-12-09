using System;

namespace Domain.Entities;

public class Facility
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int WorkspaceId { get; set; }
    public Workspace? Workspace { get; set; }
}
