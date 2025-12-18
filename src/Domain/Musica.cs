using System.Diagnostics;
namespace ScreenSound.Domain;

public class Musica
{
    public static List<Musica> listaDeTodasAsMusicas = new List<Musica>();
    //ATRIBUTOS
    public string NomeDaMusica { get; private set; } 
    public Artista ArtistaDaMusica { get; private set; }
    public int Duracao { get; private set; }
    public bool Disponivel { get; private set; }
    
    //propriedade de leitura
    public string DescricaoResumida => $"A música {NomeDaMusica} pertence ao artista {ArtistaDaMusica.Nome}";

    //CONSTRUTOR
    public Musica(string nomeDaMusica, Artista artistaDaMusica, int duracao)
    {
        this.NomeDaMusica = nomeDaMusica;
        this.ArtistaDaMusica = artistaDaMusica;
        this.Duracao = duracao;
        this.Disponivel = true;

        listaDeTodasAsMusicas.Add(this);
    }
    
    //MÉTODOS
    public void ExibirFichaTecnica()
    {
        Console.WriteLine("Nome da Música: {0}", NomeDaMusica);
        Console.WriteLine("Artista: {0}", ArtistaDaMusica.Nome);
        Console.WriteLine("Duração: {0}", Duracao);
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        }
        else
        {
            Console.WriteLine("Adquira o plano plus+.");
        }
    }

    public void ExibeArtista()
    {
        Console.WriteLine($"Música / Artista: {NomeDaMusica} - {ArtistaDaMusica.Nome}");
    }
}