namespace ScreenSound.Application;
using ScreenSound.Domain;

internal class AlbumService
{
    private SystemContext _context;
    private readonly BandaService _bandaService;

    public AlbumService(SystemContext context, BandaService bandaService)
    {
        _context = context;
        _bandaService = bandaService;
    }

    public void CriaERegistraAlbum(string nomeDoAlbum, string bandaDoAlbum, int anoDeLancamento)
    {
        // verifica se já existe aquele album para aquela banda
        var albumExistente = _context.ListaDeTodosOsAlbuns
            .FirstOrDefault(a => a.NomeDoAlbum.Equals(nomeDoAlbum, StringComparison.OrdinalIgnoreCase) &&
                                 a.BandaDoAlbum.NomeDaBanda.Equals(bandaDoAlbum, StringComparison.OrdinalIgnoreCase));
        if (albumExistente != null)
        {
            throw new InvalidOperationException($"O álbum '{nomeDoAlbum}' da banda '{bandaDoAlbum}' já está registrado.");
        }
        
        // verifica se a banda ja existe, se nao existir cria uma nova
        Banda bandaFinal = _bandaService.ObterOuCriarBanda(bandaDoAlbum);

        // cria o album e registra na lista de albuns do sistema
        _context.ListaDeTodosOsAlbuns.Add(
            new Album(nomeDoAlbum, bandaFinal, anoDeLancamento)
        );
    }
}