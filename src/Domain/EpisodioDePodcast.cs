class EpisodioDePodcast
{   
    // REGRAS DE NEGOCIO
    // Sempre que um episodio for criado ele deve ter um numero, titulo, duracao e resumo vinculados
    // Todo episodio dever vinculado a um podcast (fazer na classe Podcast)
    
    // ATRIBUTOS
    public int NumeroDoEpisodio { get; private set; }
    public string TituloDoEpisodio { get; private set; }
    public int Duracao { get; private set; }
    public string ResumoDoEpisodio { get; private set; }
    public List<string> ListaDeConvidados { get; private set; }
    public Podcast PodcastVinculado { get; private set; }

    // CONSTRUTOR
   public EpisodioDePodcast(string tituloDoEpisodio, int duracao, string resumoDoEpisodio, Podcast podcastVinculado) 
    {
        //NumeroDoEpisodio = é atribuido automaticamente ao adicionar o episodio ao podcast
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