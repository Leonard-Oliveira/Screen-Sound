namespace ScreenSound.Application;
using ScreenSound.Domain;
internal class BandaService
{
    private readonly SystemContext _context; 

    public BandaService(SystemContext context)
    {
        _context = context;
    }
    

    // CONSULTA SIMPLES (Para uso no AlbumService)
    // Útil para apenas checar se algo existe sem causar exceptions.
    public Banda? BuscarBandaPorNome(string nomeDoArtistaProcurado)
    {
        return _context.ListaDeTodasAsBandas
            .FirstOrDefault(a => a.NomeDaBanda.Equals(nomeDoArtistaProcurado, StringComparison.OrdinalIgnoreCase));
    }

    // (Para o Program.cs)
    // Se o usuário tentar cadastrar algo que já existe, throw Exception.
    public void RegistraNovaBanda(string nomeDoaBandaASerRegistrada)
    {
        if (string.IsNullOrWhiteSpace(nomeDoaBandaASerRegistrada)) throw new ArgumentException("Nome vazio.");
        
        if (BuscarBandaPorNome(nomeDoaBandaASerRegistrada) != null)
            throw new InvalidOperationException($"A Banda'{nomeDoaBandaASerRegistrada}' já está no sistema.");

        _context.ListaDeTodasAsBandas.Add(new Banda(nomeDoaBandaASerRegistrada));
    }

    // Para demais services.
    // O sistema obtem o Artista, sem exceptions. Se não existir, cria um novo.
    public Banda ObterOuCriarBanda(string nomeDaBandaParaVincular)
    {
        var banda = BuscarBandaPorNome(nomeDaBandaParaVincular);
        
        if (banda == null)
        {
            banda = new Banda(nomeDaBandaParaVincular);
            _context.ListaDeTodasAsBandas.Add(banda);
        }
        
        return banda;
    }

    public void AvaliaBanda(int nota, string nomeDaBanda)
    {
        if (nota < 1 || nota > 10) throw new ArgumentException("Valor de nota atribuído é inválido. Valor deve ser 1-10");

        var banda = _context.ListaDeTodasAsBandas.FirstOrDefault(b => b.NomeDaBanda.Equals(nomeDaBanda, StringComparison.OrdinalIgnoreCase));
        if (banda == null) throw new ArgumentException("Banda Nao encontrada");

        banda.AdicionarAvaliacao(new Avaliacao(nota));
    }
}