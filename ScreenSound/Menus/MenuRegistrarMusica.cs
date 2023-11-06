using ScreenSound.Shared.Banco;
using ScreenSound.Shared.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(EntityDAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite o artista cuja música deseja registrar: ");
        string nomeDoArtista = Console.ReadLine()!;
        var artista = artistaDAL.RecuperarPor(a => a.Nome == nomeDoArtista); 
        if (artista != null)
        {
            Console.Write("Agora digite o título da música: ");
            string tituloMusica = Console.ReadLine()!;
            Console.Write("Agora digite o gênero da música: ");
            string generoMusica = Console.ReadLine()!;
            var musicaRegistrada = new Musica(tituloMusica) { Genero = generoMusica };
            artista.AdicionarMusica(musicaRegistrada);


            Console.WriteLine($"A música {tituloMusica} de {nomeDoArtista} foi registrado com sucesso!");
            artistaDAL.Atualizar(artista);
            Thread.Sleep(4000);
            Console.Clear();
            
        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDoArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
