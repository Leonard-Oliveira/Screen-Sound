using ScreenSound.Domain;
namespace ScreenSound.Application;
class BandaService
{
     public static List<Banda> _listaDeTodasAsBandas = new List<Banda>();

    // CONSULTA SIMPLES (Para uso no AlbumService)
    // Útil para apenas checar se algo existe sem causar exceptions.
    public Banda? BuscarBandaPorNome(string nomeDoArtistaProcurado)
    {
        return _listaDeTodasAsBandas
            .FirstOrDefault(a => a.NomeDaBanda.Equals(nomeDoArtistaProcurado, StringComparison.OrdinalIgnoreCase));
    }

    // (Para o Program.cs)
    // Se o usuário tentar cadastrar algo que já existe, throw Exception.
    public void RegistraNovaBanda(string nomeDoaBandaASerRegistrada)
    {
        if (string.IsNullOrWhiteSpace(nomeDoaBandaASerRegistrada)) throw new ArgumentException("Nome vazio.");
        
        if (BuscarBandaPorNome(nomeDoaBandaASerRegistrada) != null)
            throw new InvalidOperationException($"A Banda'{nomeDoaBandaASerRegistrada}' já está no sistema.");

        _listaDeTodasAsBandas.Add(new Banda(nomeDoaBandaASerRegistrada));
    }

    // (Para o MusicaService)
    // O sistema obtem o Artista, sem exceptions. Se não existir, cria um novo.
    public Banda ObterBandaParaVinculo(string nomeDaBandaParaVincular)
    {
        var banda = BuscarBandaPorNome(nomeDaBandaParaVincular);
        
        if (banda == null)
        {
            banda = new Banda(nomeDaBandaParaVincular);
            _listaDeTodasAsBandas.Add(banda);
        }
        
        return banda;
    }
}