namespace ScreenSound.Domain;
internal class EpisodioDePodcast
{   
    // ATRIBUTOS
    public int NumeroDoEpisodio { get; private set; }
    public string TituloDoEpisodio { get; private set; }
    public int Duracao { get; private set; }
    public string ResumoDoEpisodio { get; private set; }
    public List<string> ListaDeConvidados { get; private set; }
    public Podcast PodcastVinculado { get; private set; }

    // CONSTRUTOR
    public EpisodioDePodcast(int numeroDoEpisodio, string tituloDoEpisodio, int duracao, string resumoDoEpisodio, Podcast podcastVinculado) 
    {
        this.NumeroDoEpisodio = numeroDoEpisodio;
        this.TituloDoEpisodio = tituloDoEpisodio;
        this.Duracao = duracao;
        this.ResumoDoEpisodio = resumoDoEpisodio;
        this.PodcastVinculado =  podcastVinculado;
        this.ListaDeConvidados = new List<string>();
    }

    // MÉTODOS
    public void AdicionarConvidaos(string nomeDoConvidado)
    {   
        ListaDeConvidados.Add(nomeDoConvidado);
        Console.WriteLine($"Convidado {nomeDoConvidado} adicionado ao episódio {TituloDoEpisodio}.");
    }
}