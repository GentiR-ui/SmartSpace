using System;

namespace Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int WorkspaceId { get; set; }
    public Workspace? Workspace { get; set; }    
}
