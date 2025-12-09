namespace Application.DTOs;

public class CreateReservationRequest
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int WorkspaceId { get; set; }
    public int CustomerId { get; set; }
}

public class UpdateReservationRequest
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int WorkspaceId { get; set; }
    public int CustomerId { get; set; }
}

public class ReservationResponse
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int WorkspaceId { get; set; }
    public int CustomerId { get; set; }
}
