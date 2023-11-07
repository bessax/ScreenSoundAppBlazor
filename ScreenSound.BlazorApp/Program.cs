using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ScreenSound.BlazorApp;
using ScreenSound.BlazorApp.Servicos;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<ArtistasAPI>(client => { 
     client.BaseAddress = new Uri("https://localhost:7016");
     client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient<MusicasAPI>(client => {
    client.BaseAddress = new Uri("https://localhost:7016");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

await builder.Build().RunAsync();
