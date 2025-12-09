using System;

namespace Domain.Entities;

public class Reservation
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public int WorkspaceId { get; set; }
    public Workspace? Workspace { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public Payment? Payment { get; set; }
}
