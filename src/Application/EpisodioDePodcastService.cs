namespace ScreenSound.Application;
using ScreenSound.Domain;
internal class EpisodioDePodcastService
{
    #region Propriedades Privadas (Backing Fields)
    private SystemContext _context;
    #endregion

    #region Construtor
    public EpisodioDePodcastService(SystemContext context)
    {
        _context = context;
    }
    #endregion
 
    #region Métodos
    public void RegistraEpisodioDePodcast(string tituloDoEpisodio, int duracao, string resumoDoEpisodio, string nomeDoPodcastVinculado, List<string> listaDeConvidados)
    {
        // validações de entrada
        ValidaEntrada(tituloDoEpisodio, duracao, resumoDoEpisodio, nomeDoPodcastVinculado);

        // obtem se existe o podcast vinculado e armazena o objeto Podcast na variavel
        var podcastEncontrado = _context.ListaDeTodosOsPodcasts.FirstOrDefault(
            p => p.NomeDoPodcast.Equals(nomeDoPodcastVinculado, StringComparison.
                OrdinalIgnoreCase)) ?? throw new InvalidOperationException(
                    $"Podcast com nome '{nomeDoPodcastVinculado}' não encontrado.");
    
        // valida se o Podcast já tem um ep com aquele título
        if (podcastEncontrado.ListaDeEpisodiosDoPodcast.Any(e => e.TituloDoEpisodio.Equals(tituloDoEpisodio, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Episódio com título '{tituloDoEpisodio}' já existe no podcast '{nomeDoPodcastVinculado}'.");
        }

        // nao tendo um ep com aquele titulo, calcula o indice e instancia
        int indice = podcastEncontrado.ListaDeEpisodiosDoPodcast.Count + 1;
        EpisodioDePodcast novoEpisodio = new EpisodioDePodcast(indice, tituloDoEpisodio, duracao, resumoDoEpisodio, podcastEncontrado);
        
        listaDeConvidados?.ForEach(c => novoEpisodio.AdicionarConvidados(c));
        podcastEncontrado.AdicionaEpisodio(novoEpisodio);
    }

    // valida os parametros do construtor
    private void ValidaEntrada(string titulo, int duracao, string resumo, string podcast)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(titulo, nameof(titulo));
        ArgumentException.ThrowIfNullOrWhiteSpace(resumo, nameof(resumo));
        ArgumentException.ThrowIfNullOrWhiteSpace(podcast, nameof(podcast));
        if (duracao <= 0) throw new ArgumentException("A duração deve ser positiva.");
    }
    #endregion
}