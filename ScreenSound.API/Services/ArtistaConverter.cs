using ScreenSound.API.DTO;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.API.Services;

public class ArtistaConverter
{
    public Artista RequestToEntity(ArtistaRequest artistaRequest)
    {
        return new Artista(artistaRequest.Nome, artistaRequest.Bio);
    }

    public Artista RequestToEntityEdit(ArtistaRequestEdit artistaRequestEdit)
    {
        return new Artista(artistaRequestEdit.Nome, artistaRequestEdit.Bio) 
        { Id = artistaRequestEdit.Id , FotoPerfil = null};
    }

    public ArtistaResponse EntityToResponse(Artista artista)
    {
        return new ArtistaResponse(artista.Id,artista.Nome, artista.Bio, artista.FotoPerfil);
    }

    public ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> artistas)
    {
        return artistas.Select(a => EntityToResponse(a)).ToList();
    }
}
