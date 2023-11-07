using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.DTO;
public record ArtistaRequestEdit([Required] int Id, [Required] string Nome, [Required] string Bio, IFormFile FotoPerfil) 
    : ArtistaRequest(Nome, Bio, FotoPerfil);

