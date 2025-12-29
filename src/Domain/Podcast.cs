namespace ScreenSound.Domain;
internal class Podcast
{
    #region Propriedades Privadas (Backing Fiels)
    private List<EpisodioDePodcast> _episodios = new List<EpisodioDePodcast>();
    #endregion

    #region Atributos
    public string NomeDoPodcast { get; private set; }
    public string Host { get; private set; }
    public int TotalDeEpisodios => _episodios.Count;
    public IReadOnlyCollection<EpisodioDePodcast> ListaDeEpisodiosDoPodcast => _episodios.AsReadOnly();
    #endregion

    #region Construtor
    public Podcast(string nomeDoPodcast, string host)
    {
        if (string.IsNullOrWhiteSpace(nomeDoPodcast)) throw new ArgumentException("O nome do podcast é obrigatório.");
        if (string.IsNullOrWhiteSpace(host)) throw new ArgumentException("O host é obrigatório.");
        
        NomeDoPodcast = nomeDoPodcast;
        Host = host;
    }
    #endregion


    #region Métodos
    public void AdicionaEpisodio(EpisodioDePodcast episodio)
    {
        if (episodio == null) throw new ArgumentNullException(nameof(episodio), "Não é possível adicionar um episódio nulo.");
        _episodios.Add(episodio);
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Podcast: {NomeDoPodcast}, Host: {Host}, Total de Episódios: {TotalDeEpisodios}");
    }
    #endregion
}