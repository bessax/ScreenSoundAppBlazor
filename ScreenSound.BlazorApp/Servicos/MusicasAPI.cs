using ScreenSound.Shared.Modelos;
using System.Net.Http.Json;

namespace ScreenSound.BlazorApp.Servicos;
public class MusicasAPI
{
    private readonly HttpClient _httpClient;
    public MusicasAPI(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<Musica>?> GetMusicasAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Musica>>("musicas");
    }
    public async Task<Musica?> GetMusicaAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Musica>($"musicas/{id}");
    }
    public async Task AddMusicaAsync(Musica musica)
    {
        await _httpClient.PostAsJsonAsync("musicas",musica);    
    }
    public async Task UpdateMusicaAsync(Musica musica)
    {
        await _httpClient.PutAsJsonAsync($"artistas/{musica.Id}",musica);
    }
    public async Task DeleteMusicaAsync(int id)
    {
        await _httpClient.DeleteAsync($"musicas/{id}");
    }
}

