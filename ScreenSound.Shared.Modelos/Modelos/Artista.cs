namespace ScreenSound.Shared.Modelos;

public class Artista
{
    public string  Nome { get; set; }
    public string Bio { get; set; }
    public int Id { get; set; } = 0;
    public string? FotoPerfil { get; set; } = "https://img.freepik.com/vetores-gratis/silhueta-feminina_23-2147524227.jpg";

    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();

    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
    }

    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {Nome}");
        foreach (var musica in Musicas)
        {
            musica.ExibirFichaTecnica();
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}