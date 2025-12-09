namespace Application.DTOs;

public class CreateAdminRequest
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string RoleLevel { get; set; } = "Standard";
}

public class UpdateAdminRequest
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string RoleLevel { get; set; } = string.Empty;
}

public class AdminResponse
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string RoleLevel { get; set; } = string.Empty;
}
