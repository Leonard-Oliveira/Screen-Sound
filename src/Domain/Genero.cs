using ScreenSound.Domain;
public class Genero
{
    // ATRIBUTOS
    public string NomeDoGenero { get; private set; }
    private List<Musica> _listaDeMusicasDoGenero = new();
    public IReadOnlyList<Musica> ListaDeMusicasDoGenero => _listaDeMusicasDoGenero.AsReadOnly();

    // CONSTRUTOR
    public Genero(string nomeDoGenero) { NomeDoGenero = nomeDoGenero; }

    // MÉTODOS
    public void AdicionaMusicaAoGenero(Musica musica)
    {
        _listaDeMusicasDoGenero.Add(musica);
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