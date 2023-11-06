using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.Menus;
internal class MenuRegistrarArtista : Menu
{
    public override void Executar(EntityDAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro dos Artistas");
        Console.Write("Digite o nome do artista que deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        Console.Write("Digite a bio do artista que deseja registrar: ");
        string bioDoArtista = Console.ReadLine()!;
        artistaDAL.Adicionar(new Artista(nomeDoArtista, bioDoArtista));
        Console.WriteLine($"O artista {nomeDoArtista} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}
