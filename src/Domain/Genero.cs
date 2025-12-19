using ScreenSound.Domain;
public class Genero
{
    // ATRIBUTOS
    public string NomeDoGenero { get; private set; }
    public List<Musica> ListaDeMusicasDoGenero { get; private set; }

    // CONSTRUTOR
    public Genero(string nomeDoGenero)
    {
        this.NomeDoGenero = nomeDoGenero;
        this.ListaDeMusicasDoGenero = new List<Musica>();
    }

    // MÉTODOS
    public void AdicionaMusicaAoGenero(Musica musica)
    {
        ListaDeMusicasDoGenero.Add(musica);
    }

    public void ExibirMusicasDoGenero()
    {
        Console.WriteLine($"Músicas do gênero {NomeDoGenero}:");
        foreach (var musica in ListaDeMusicasDoGenero)
        {
            Console.WriteLine($"- {musica.NomeDaMusica} de {musica.BandaDaMusica.NomeDaBanda}");
        }
    }

    public int ObterQuantidadeDeMusicas()
    {
        return ListaDeMusicasDoGenero.Count;
    }
}