using MediatR;

public class AddTpaMasterCommand : IRequest<bool>
{
    public string Name { get; set; } = null!;

    public string? ContactNumber { get; set; }

    public string? FaxNumber { get; set; }

    public string? Ceo { get; set; }

    public string? LicenseNumber { get; set; }

    public DateTime? LicenseValidTill { get; set; }

    public string Address { get; set; } = null!;

    public string? Email { get; set; }

    public string? WebSite { get; set; }

    public bool? IsActive { get; set; }
}
