namespace Application.DTOs;

public class CreateLocationRequest
{
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}

public class UpdateLocationRequest
{
    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}

public class LocationResponse
{
    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}
