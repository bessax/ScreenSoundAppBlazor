using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelos;
using ScreenSound.Shared.Context;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorGenero : Menu
{
    public override void Executar(EntityDAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Mostrar musicas por gênero");
        Console.Write("Digite o gênero para consultar músicas:");
        string genero = Console.ReadLine()!;
        var musicaDal = new EntityDAL<Musica>(new ScreenSoundContext());
        var listaGenero = musicaDal.ListarPor(a => a.Genero == genero);
        if (listaGenero.Any())
        {
            Console.WriteLine($"\nMusicas do Genero {genero}:");
            foreach( var musica in listaGenero )
            {
                musica.ExibirFichaTecnica();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO gênero {genero} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
