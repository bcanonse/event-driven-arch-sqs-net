namespace EventOne.Models;

public sealed class Drivers
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string LicenseNumber { get; set; }

}