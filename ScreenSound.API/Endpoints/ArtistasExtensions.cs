using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.DTO;
using ScreenSound.API.Services;
using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    
    public static void MapEndPointArtistas(this WebApplication app)
    {

        app.MapPost("/Artistas",([FromServices] ArtistaConverter converter, [FromServices] EntityDAL<Artista> entityDAL, [FromBody] ArtistaRequest artistaReq) =>
        {
            entityDAL.Adicionar(converter.RequestToEntity(artistaReq));
        });

        app.MapGet("/Artistas", ([FromServices] ArtistaConverter converter, [FromServices] EntityDAL<Artista> entityDAL) =>
        {
            return converter.EntityListToResponseList(entityDAL.Listar());
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] EntityDAL<Artista> entityDAL,string nome) =>
        {
            return entityDAL.RecuperarPor(a => a.Nome == nome);
        });

        app.MapDelete("/Artistas/{id}", ([FromServices] EntityDAL<Artista> entityDAL,int id) =>
        {
            var artista = entityDAL.RecuperarPor(a => a.Id == id);
            if (artista is null)
            {
                return Results.NotFound("Artista para exclusão não encontrado.");
            }
            entityDAL.Deletar(artista);
            return Results.NoContent();
        });

        app.MapPut("/Artistas", ([FromServices] ArtistaConverter converter,[FromServices] EntityDAL<Artista> entityDAL, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
        {
            entityDAL.Atualizar(converter.RequestToEntityEdit(artistaRequestEdit));
        });
    }
}
