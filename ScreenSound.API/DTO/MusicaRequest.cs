using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.DTO;
public record MusicaRequest([Required] string Nome, [Required] string Genero, [Required] int ArtistaId);


