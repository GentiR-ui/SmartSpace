namespace Application.DTOs;

public class CreateFacilityRequest
{
    public string Name { get; set; } = string.Empty;
    public int WorkspaceId { get; set; }
}

public class UpdateFacilityRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int WorkspaceId { get; set; }
}

public class FacilityResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int WorkspaceId { get; set; }
}
