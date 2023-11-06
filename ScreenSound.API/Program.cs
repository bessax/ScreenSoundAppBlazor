using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ScreenSound.API.Endpoints;
using ScreenSound.API.Services;
using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Context;
using ScreenSound.Shared.Modelos;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.ConfigureAppConfiguration(config =>
//{
//    var settings = config.Build();
//    config.AddAzureAppConfiguration("Endpoint=https://appconfiguration-screensoundapi.azconfig.io;Id=q/aB;Secret=g9RBOquM4M/V0JpNL5qVCHcyCasmx7V5XB1xOz0//pk=");
//});


// Add services to the container.

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ScreenSoundContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {       

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true, 
            ValidIssuer = builder.Configuration["JWTTokenConfiguration:Issuer"],
            ValidAudience = builder.Configuration["JWTTokenConfiguration:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration["JWTTokenConfiguration:SigningKey"]!))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddDbContext<ScreenSoundContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]).UseLazyLoadingProxies();
    });
builder.Services.AddTransient(typeof(EntityDAL<Artista>));
builder.Services.AddTransient(typeof(EntityDAL<Musica>));
builder.Services.AddTransient(typeof(ArtistaConverter));
builder.Services.AddTransient(typeof(MusicaConverter));
builder.Services.AddTransient(typeof(TokenService));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

});
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapEndPointAuthorizer();

app.MapEndPointArtistas();

app.MapEndPointMusicas();

app.Run();


