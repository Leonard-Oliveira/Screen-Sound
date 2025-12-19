class EpisodioDePodcast
{   
    // REGRAS DE NEGOCIO
    // Sempre que um episodio for criado ele deve ter um numero, titulo, duracao e resumo vinculados
    // Todo episodio dever vinculado a um podcast (fazer na classe Podcast)
    
    // ATRIBUTOS
    public int NumeroDoEpisodio;
    public string TituloDoEpisodio;
    public int Duracao;
    public string ResumoDoEpisodio;
    public Podcast PodcastVinculado;

    // CONSTRUTOR
   public EpisodioDePodcast(int numeroDoEpisodio, string tituloDoEpisodio, int duracao, string resumoDoEpisodio, Podcast podcastVinculado) 
    {
        this.NumeroDoEpisodio = numeroDoEpisodio;
        this.TituloDoEpisodio = tituloDoEpisodio;
        this.Duracao = duracao;
        this.ResumoDoEpisodio = resumoDoEpisodio;
        this.PodcastVinculado =  podcastVinculado;
    }

    // MÉTODOS
    public void AdicionarConvidaos(string nomeDoConvidado)
    {
        Console.WriteLine($"Convidado {nomeDoConvidado} adicionado ao episódio {TituloDoEpisodio}.");
    }
}