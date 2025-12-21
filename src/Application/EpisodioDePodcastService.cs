namespace ScreenSound.Application;
using ScreenSound.Domain;
internal class EpisodioDePodcastService
{
    private readonly SystemContext _context;
    
    public EpisodioDePodcastService(SystemContext context)
    {
        _context = context;
    }
 
    public void RegistraEpisodioDePodcast(string tituloDoEpisodio, int duracao, string resumoDoEpisodio, string nomeDoPodcastVinculado, List<string> listaDeConvidados)
    {
        // validações de entrada
        ArgumentException.ThrowIfNullOrWhiteSpace(tituloDoEpisodio, "Titulo do episodio inválido");
        ArgumentException.ThrowIfNullOrWhiteSpace(resumoDoEpisodio, "Resumo do episodio inválido");
        ArgumentException.ThrowIfNullOrWhiteSpace(nomeDoPodcastVinculado, "Nome do podcast vinculado inválido");
        if (duracao <= 0) throw new ArgumentException("A duração deve ser positiva.");

        // obtem a existe do podcast vinculado e armazena o objeto Podcast na variavel
        var podcastEncontrado = _context.ListaDeTodosOsPodcasts.FirstOrDefault(p => p.NomeDoPodcast.Equals(
        nomeDoPodcastVinculado, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException($"Podcast com nome '{nomeDoPodcastVinculado}' não encontrado.");
    
        // valida se o Podcast já tem um ep com aquele título
        if (podcastEncontrado.ListaDeEpisodiosDoPodcast.Any(e => e.TituloDoEpisodio.Equals(tituloDoEpisodio, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"Episódio com título '{tituloDoEpisodio}' já existe no podcast '{nomeDoPodcastVinculado}'.");
        }

        // nao tendo um ep com aquele titulo, calcula o indice e instancia
        int indice = podcastEncontrado.ListaDeEpisodiosDoPodcast.Count + 1;
        
        EpisodioDePodcast novoEpisodio = new EpisodioDePodcast(indice, tituloDoEpisodio, duracao, resumoDoEpisodio, podcastEncontrado);
        podcastEncontrado.AdicionaEpisodio(novoEpisodio);
    }
}