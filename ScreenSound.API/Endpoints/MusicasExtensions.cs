using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.DTO;
using ScreenSound.API.Services;
using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void MapEndPointMusicas(this WebApplication app)
    {
    
            app.MapPost("/Musicas", ([FromServices] MusicaConverter converter,[FromServices]EntityDAL<Musica> entityDAL,[FromBody] MusicaRequest musicaReq) =>
            {
                entityDAL.Adicionar(converter.RequestToEntity(musicaReq));
            });
    
            app.MapGet("/Musicas", ([FromServices] MusicaConverter converter,[FromServices] EntityDAL<Musica> entityDAL) =>
            {
                return converter.EntityListToResponseList(entityDAL.Listar());
            });
    
            app.MapGet("/Musicas/{nome}", ([FromServices] MusicaConverter converter, [FromServices]EntityDAL<Musica> entityDAL,string nome) =>
            {
                return converter.EntityToResponse(entityDAL.RecuperarPor(a => a.Nome == nome)!);
            });
    
            app.MapDelete("/Musicas/{id}", ([FromServices]EntityDAL<Musica> entityDAL,int id) =>
            {
                var musica = entityDAL.RecuperarPor(a => a.Id == id);
                if (musica is null)
                {
                    return Results.NotFound("Música para exclusão não encontrada.");
                }
                entityDAL.Deletar(musica);
                return Results.NoContent();
            });
    
            app.MapPut("/Musicas", ([FromServices] MusicaConverter converter,[FromServices]EntityDAL<Musica> entityDAL,[FromBody] MusicaRequestEdit musicaRequestEdit) =>
            {
                entityDAL.Atualizar(converter.RequestToEntityEdit(musicaRequestEdit));
            });
        }   
}
