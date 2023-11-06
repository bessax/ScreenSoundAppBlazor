namespace ScreenSound.API.DTO;

public record UserTokenResponse
{    
    public string Token { get; set; } = string.Empty;
}
