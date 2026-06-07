using System.ComponentModel.DataAnnotations;

namespace ServisTalep.Api.DTOs;

public class UpdateStatusDto
{
    [Required]
    [RegularExpression("^(New|InProgress|Completed|Cancelled)$")]
    public string Status { get; set; } = string.Empty;
}