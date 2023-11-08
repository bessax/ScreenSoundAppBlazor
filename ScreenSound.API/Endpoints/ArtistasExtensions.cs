using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ScreenSound.API.DTO;
using ScreenSound.API.Services;
using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelos;
using System.Buffers.Text;
using System.Text;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    
    public static void MapEndPointArtistas(this WebApplication app)
    {

        app.MapPost("/Artistas", async([FromServices]IHostEnvironment env, [FromServices] ArtistaConverter converter, [FromServices] EntityDAL<Artista> entityDAL, [FromBody] ArtistaRequest artistaReq) =>
        {
            await Console.Out.WriteLineAsync("Cheguei no Endpoint!!!!!!!!");
            var nome = artistaReq.Nome.Trim();
            var path = Path.Combine(env.ContentRootPath,
                "FotoPerfil", DateTime.Now.ToString("ddMMyyyyhhss")+"."+ nome + ".jpg");

            using MemoryStream ms = new MemoryStream(Convert.FromBase64String(artistaReq.FotoPerfil));
            using FileStream fs = new(path, FileMode.Create);
            await ms.CopyToAsync(fs);
            var artista = converter.RequestToEntity(artistaReq);
            artista.FotoPerfil = path;
            entityDAL.Adicionar(artista);
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
