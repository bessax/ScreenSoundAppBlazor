namespace ScreenSound.Shared.Modelos;
public class Musica
{
    public Musica(string nome)
    {
        Nome = nome;
       
    }

    public string Nome { get; set; }
    public int Id { get; set; } = 0;
    public string Genero { get; set; }
    public virtual Artista? Artista { get; set; }
    public void ExibirFichaTecnica()
    {
        Console.WriteLine($@"Nome: {Nome} - Gênero: {Genero}");

    }
}