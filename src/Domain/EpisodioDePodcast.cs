namespace ScreenSound.Domain;

internal class EpisodioDePodcast
{
    #region Campos Privados (Backing Fields)
    private readonly List<string> _convidados = new();
    #endregion

    #region Atributos e Propriedades
    public int NumeroDoEpisodio { get; private set; }
    public string TituloDoEpisodio { get; private set; }
    public int Duracao { get; private set; }
    public string ResumoDoEpisodio { get; private set; }
    public Podcast PodcastVinculado { get; private set; }
    public IReadOnlyCollection<string> ListaDeConvidados => _convidados;
    #endregion

    #region Construtor
    public EpisodioDePodcast(int numeroDoEpisodio, string tituloDoEpisodio, int duracao, string resumoDoEpisodio, Podcast podcastVinculado)
    {
        NumeroDoEpisodio = numeroDoEpisodio;
        TituloDoEpisodio = tituloDoEpisodio;
        Duracao = duracao;
        ResumoDoEpisodio = resumoDoEpisodio;
        PodcastVinculado = podcastVinculado;
    }
    #endregion

    #region Métodos
    public void AdicionarConvidaos(string nomeDoConvidado)
    {
        if (nomeDoConvidado != null)
        {
            _convidados.Add(nomeDoConvidado);
            Console.WriteLine($"Convidado {nomeDoConvidado} adicionado ao episódio {TituloDoEpisodio}.");
        }
    }
    #endregion
}