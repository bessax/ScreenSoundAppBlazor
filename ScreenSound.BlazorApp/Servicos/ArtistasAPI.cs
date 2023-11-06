using ScreenSound.Shared.Modelos;
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
       await _httpClient.PostAsJsonAsync("artistas", artista);         
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
