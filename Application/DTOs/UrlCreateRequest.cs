using System.ComponentModel.DataAnnotations;

namespace Shortly.Application.DTOs;

public sealed class UrlCreateRequest
{
    [Required]
    [Url]
    public string Url { get; set; } = string.Empty;
}