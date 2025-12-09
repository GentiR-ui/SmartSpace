namespace Application.DTOs;

public class CreateReviewRequest
{
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public int WorkspaceId { get; set; }
}

public class UpdateReviewRequest
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public int WorkspaceId { get; set; }
}

public class ReviewResponse
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public int WorkspaceId { get; set; }
}
