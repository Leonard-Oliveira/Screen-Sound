namespace ScreenSound.Application;

using ScreenSound.Domain;

internal class AlbumService
{
    private SystemContext _context;

    public AlbumService(SystemContext context)
    {
        _context = context;
    }

    public void RegistraAlbum(string nomeDoAlbum, Banda bandaDoAlbum, int anoDeLancamento)
    {
        if (bandaDoAlbum == null) throw new ArgumentNullException(nameof(bandaDoAlbum));

        // verifica se já existe aquele album para aquela banda
        bool albumExistente = _context.ListaDeTodosOsAlbuns
            .Any(a => a.NomeDoAlbum.Equals(nomeDoAlbum, StringComparison.OrdinalIgnoreCase) &&
                a.BandaDoAlbum.NomeDaBanda.Equals(bandaDoAlbum.NomeDaBanda, StringComparison.OrdinalIgnoreCase));
        
        if (albumExistente)
        {
            throw new InvalidOperationException($"O álbum '{nomeDoAlbum}' da banda '{bandaDoAlbum.NomeDaBanda}' já está registrado.");
        }

        // cria o album e registra na lista de albuns do sistema
        _context.ListaDeTodosOsAlbuns.Add(
            new Album(nomeDoAlbum, bandaDoAlbum, anoDeLancamento)
        );
    }
}