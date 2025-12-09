namespace Application.DTOs;

public class CreateWorkspaceTypeRequest
{
    public string TypeName { get; set; } = string.Empty;
}

public class UpdateWorkspaceTypeRequest
{
    public int Id { get; set; }
    public string TypeName { get; set; } = string.Empty;
}

public class WorkspaceTypeResponse
{
    public int Id { get; set; }
    public string TypeName { get; set; } = string.Empty;
}
