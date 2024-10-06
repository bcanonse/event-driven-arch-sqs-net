using System.ComponentModel.DataAnnotations;

namespace EventOne.DTO;

public sealed class CreateDriverDto
{
    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required]
    public required string LicenseNumber { get; set; }
}