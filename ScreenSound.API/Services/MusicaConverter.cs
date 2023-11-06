using ScreenSound.API.DTO;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.API.Services;

public class MusicaConverter
{
    public Musica RequestToEntity(MusicaRequest musicaRequest)
    {
        return new Musica(musicaRequest.Nome) { Genero = musicaRequest.Genero};
    }

    public Musica RequestToEntityEdit(MusicaRequestEdit musicaRequestEdit)
    {        
        return new Musica(musicaRequestEdit.Nome)
        { Id = musicaRequestEdit.Id,Genero = musicaRequestEdit.Genero };
    }

    public MusicaResponse EntityToResponse(Musica musica)
    {       
       return new MusicaResponse(musica.Id,musica.Nome!,musica.Genero!,musica.Artista.Id,musica.Artista.Nome);
    }

    public ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicas)
    {
        return musicas.Select(a => EntityToResponse(a)).ToList();
    }
}
