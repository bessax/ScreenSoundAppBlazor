using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.DTO;
public record ArtistaRequest([Required]string Nome, [Required] string Bio, string FotoPerfil);