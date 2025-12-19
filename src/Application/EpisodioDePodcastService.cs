namespace ScreenSound.Application;
class EpisodioDePodcastService
{
    // ATRIBUTOS
    // injeção de dependencia do SystemContext. Permite acessar as listas "banco de dados"
    private readonly SystemContext _context;
    
    // CONSTRUTOR
    // _context recebe um objeto do tipo SystemContext. 
    // Este objeto possui as listas que funcionam como banco de dados na aplicação
    // isto, pois as listas já estao declaradas no SystemContext.cs
    public EpisodioDePodcastService(SystemContext context)
    {
        _context = context;
    }
    //episódios de podcast nao possui uam lista estática, pois eles são vinculados a um podcast específico
    // Nao precisa de uma lista de todos os episodios de podcast, pois pra busca basta 
    // acessar o podcast e buscar na lista de episodios vinculados a ele
    // E se eu quiser buscar quantos episodios falam sobre determinado assunto? 
    // ai eu teria que percorrer todos os podcasts e suas listas de episodios
    // o mais prático seria um foreach que percorre a lista de podcasts e dentro dela um
    //  foreach que percorre a lista de episodios

    // REGRAS DE NEGOCIO
    // 1. Todo episodio deve ser vinculado a um podcast existente.
    // 2. Todo episodio deve ter um numero, titulo, duracao e resumo vinculados.

    // Deve validar se a duracao é maior que 0
    public void RegistraEpisodioDePodcast(string tituloDoEpisodio, int duracao, string resumoDoEpisodio, string nomeDoPodcastVinculado, List<string> listaDeConvidados)
    {
        // validações básicas dos parametros
        ArgumentException.ThrowIfNullOrWhiteSpace(tituloDoEpisodio, "Titulo do episodio inválido");
        ArgumentException.ThrowIfNullOrWhiteSpace(resumoDoEpisodio, "Resumo do episodio inválido");
        ArgumentException.ThrowIfNullOrWhiteSpace(nomeDoPodcastVinculado, "Nome do podcast vinculado inválido");
        if (duracao <= 0) throw new ArgumentException("A duração deve ser positiva.");

        // Deve validar se o podcast existe
        var podcastEncontrado = _context.ListaDeTodosOsPodcasts.FirstOrDefault(p => p.NomeDoPodcast.Equals(
        nomeDoPodcastVinculado, StringComparison.OrdinalIgnoreCase));
        // Deve validar se o titulo do episodio ja nao existe no podcast
        // O Numero do Episodio deve ser incrementado automaticamente de acordo com um contador
    }
}