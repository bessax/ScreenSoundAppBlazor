using ScreenSound.Shared.Modelos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ScreenSound.BlazorApp.Servicos;
public class ArtistasAPI
{
    private readonly HttpClient _httpClient;
    public ArtistasAPI(HttpClient httpClient)
    {
        _httpClient = httpClient;    
    }
    public async Task<List<Artista>?> GetArtistasAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Artista>>("artistas");
    }
    public async Task<Artista?> GetArtistaAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Artista>($"artistas/{id}");
    }
    public async Task AddArtistaAsync(Artista artista)
    {
        using var content = new MultipartFormDataContent();

        byte[] data = Convert.FromBase64String(artista.FotoPerfil!);
        
        var fileContent = new ByteArrayContent(data);
        
        //fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        
        content.Add(fileContent, "fotoPerfil", "fotoPerfil");
        content.Add(new StringContent(artista.Nome), "nome");
        content.Add(new StringContent(artista.Bio), "bio");

        await _httpClient.PostAsJsonAsync("artistas", content);         
    }
    public async Task UpdateArtistaAsync(Artista artista)
    {
        await _httpClient.PutAsJsonAsync($"artistas/{artista.Id}", artista);
    }
    public async Task DeleteArtistaAsync(int id)
    {
        await _httpClient.DeleteAsync($"artistas/{id}");
    }
}
