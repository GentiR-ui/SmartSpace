namespace Application.DTOs;

public class CreateWorkspaceRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int LocationId { get; set; }
    public int WorkspaceTypeId { get; set; }
}

public class UpdateWorkspaceRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int LocationId { get; set; }
    public int WorkspaceTypeId { get; set; }
}

public class WorkspaceResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int LocationId { get; set; }
    public int WorkspaceTypeId { get; set; }
}
