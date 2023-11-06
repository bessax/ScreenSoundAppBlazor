using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.DTO;
public record UserDTO
{
    [Required]
    public string Email { get; set; }=string.Empty;
    [Required]
    public string Senha { get; set; }=string.Empty;
}

