namespace ScreenSound.Application;
using ScreenSound.Domain;

internal class AlbumService
{
    private readonly SystemContext _systemContext;
    private readonly BandaService _bandaService;

    public AlbumService(SystemContext context, BandaService bandaService)
    {
        _systemContext = context;
        _bandaService = bandaService;
    }

    // public void CriaERegistraAlbum(string nomeDoAlbum, string bandaDoAlbum, int anoDeLancamento)
    // {
    //     // Em vez de fazer o '?? new Banda', use o especialista:
    //     // Este método já busca, cria se não existir E ADICIONA no contexto.
    //     Banda bandaFinal = _bandaService.ObterBandaParaVinculo(bandaDoAlbum);

    //     Album novoAlbum = new Album(nomeDoAlbum, bandaFinal, anoDeLancamento);
    //     _systemContext._listaDeTodosOsAlbuns.Add(novoAlbum);
    // }
    public void CriaERegistraAlbum(string nomeDoAlbum, string bandaDoAlbum, int anoDeLancamento)
    {
        // Se não existir, cria o artista novo
        Banda bandaFinal = _bandaService.ObterOuCriarBanda(bandaDoAlbum);

        _systemContext.ListaDeTodosOsAlbuns.Add(
            new Album(nomeDoAlbum, bandaFinal, anoDeLancamento)
        );
    }
}