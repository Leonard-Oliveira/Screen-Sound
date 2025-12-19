namespace ScreenSound.Application;

class PodcastService
{
    public static List<Podcast> _listaDeTodosOsPodcasts = new List<Podcast>();

    //caso for usar o service de outra classe, deve instanciar ele aqui

    // REGRAS DE NEGOCIO
    // 1. Todo podcast é criado sem episodios. 
    // 2. Eles sao adicionados posteriormente.

    //Valida as entradas do construtor de Podcast
    public void CriarPodcast(string nomeDoPodcast, string host)
    {
        if (string.IsNullOrWhiteSpace(nomeDoPodcast)) throw new ArgumentException("nomeDoPodcast nao pode ser null.");
        if (string.IsNullOrWhiteSpace(host)) throw new ArgumentException("Nome do Host não pode ser null.");

        // Podcast é criado. TotalDeEpisodios e ListaDeEpisodiosDoPodcast iniciam com valor padrao.
        Podcast novoPodcast = new Podcast(nomeDoPodcast, host);
    }

    public void ValidaAdicionarEpisodioNoPodcast(EpisodioDePodcast episodioDePodcast, string podcastASerIncrementado)
    {
        // Nao deve ser possivel adicionar um episodio a um podcast que nao existe
        var podcastEncontrado = _listaDeTodosOsPodcasts.FirstOrDefault(p => p.NomeDoPodcast.Equals(
        podcastASerIncrementado, StringComparison.OrdinalIgnoreCase));
        
        if (podcastEncontrado == null)
        {
            throw new InvalidOperationException($"Podcast '{podcastASerIncrementado}' não existe no sistema.");
        }

        // Deve validar se o episodio ja nao está vinculado ao podcast
        if (podcastEncontrado.ListaDeEpisodiosDoPodcast.Any(e => e.TituloDoEpisodio.Equals(episodioDePodcast.TituloDoEpisodio, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"O episodio '{episodioDePodcast.TituloDoEpisodio}' já está vinculado a esta Podcast");
        }

        // Deve adicionar o episodio na lista de episodios do podcast
        podcastEncontrado.AdicionaEpisodio(episodioDePodcast);
        // A funcao AdicionaEpisodio já incrementa o totalDeEpisodios
        // Deve ser chamado no programa apos criar o podcast
    }
}