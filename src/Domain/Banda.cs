namespace ScreenSound.Domain;
internal class Banda
{
    private readonly List<Avaliacao> _avaliacoes = new();
    
    //ATRIBUTOS
    public string NomeDaBanda { get; private set; }
    public List<Musica> ListaDeMusicasDaBanda { get; private set; }
    public List<Album> ListaDeAlbunsDaBanda { get; private set; }
    public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.AsReadOnly();
    public double AvaliacaoMedia => _avaliacoes.Any() ? _avaliacoes.Average(a => a.Nota) : 0.0;

    //CONSTRUTOR
    public Banda(string nome)
    {
        NomeDaBanda = nome;
        ListaDeMusicasDaBanda = new List<Musica>();
        ListaDeAlbunsDaBanda = new List<Album>();
    }

    //MÉTODOS
    public void AtribuiMusicaAoArtista(Musica musica)
    {
        ListaDeMusicasDaBanda.Add(musica);
    }

    public void AtribuiAlbumAoArtista(Album album)
    {
        ListaDeAlbunsDaBanda.Add(album);
    }

    public void AdicionarAvaliacao(Avaliacao avaliacao)
    {
        _avaliacoes.Add(avaliacao);
    }

    public void ExibirDiscografia()
    {
       //IMPLEMENTAR
    }
}