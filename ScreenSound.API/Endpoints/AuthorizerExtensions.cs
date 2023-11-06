using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.DTO;
using ScreenSound.API.Services;
using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.API.Endpoints;

public static class AuthorizerExtensions
{
    public static void MapEndPointAuthorizer(this WebApplication app)
    {

        app.MapPost("/Registrar",[AllowAnonymous] async ([FromBody] UserDTO user,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) =>
         {
             var identityUser = new IdentityUser
             {
                 UserName = user.Email,
                 Email = user.Email,
                 EmailConfirmed = true

             };
             var result = await userManager.CreateAsync(identityUser, user.Senha);
             if (!result.Succeeded)
             {
                 return Results.BadRequest($"Falha ao criar usuário. Contacte o administrador ===>{result.Errors}");
             }
             return Results.Ok() ;
         });

        app.MapPost("/Login", async ([FromServices] TokenService tokenService,[FromBody]UserDTO user,SignInManager<IdentityUser> signInManager) =>
        {
            if (user is null)
            {
                return Results.BadRequest("Login inválido.");
            }
            var result = await signInManager.PasswordSignInAsync(user.Email!,
                user.Senha!, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Results.BadRequest("Login inválido.");
            }
            
            user.Senha = string.Empty;
            return Results.Ok(tokenService.GenerateJWToken(user));
        });
    }
}
