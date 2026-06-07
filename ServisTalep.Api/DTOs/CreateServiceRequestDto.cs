using System.ComponentModel.DataAnnotations;

namespace ServisTalep.Api.DTOs;

public class CreateServiceRequestDto
{
    [Required]
    [MinLength(2)]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    [MinLength(2)]
    public string DeviceName { get; set; } = string.Empty;

    [Required]
    [MinLength(5)]
    public string Description { get; set; } = string.Empty;
}