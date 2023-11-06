using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(EntityDAL<Artista> artistaDAL)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
