namespace ScreenSound.Application;

using ScreenSound.Domain;

internal class AlbumService
{
    #region Propriedades Privadas (Backing Fields)
    private SystemContext _context;
    #endregion

    #region Construtor
    public AlbumService(SystemContext context)
    {
        _context = context;
    }
    #endregion

    #region Métodos
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

    public Album? BuscarAlbumPorNome(string nomeDoAlbum)
    {
        return _context.ListaDeTodosOsAlbuns.FirstOrDefault(
            a => a.NomeDoAlbum.Equals(nomeDoAlbum, StringComparison.OrdinalIgnoreCase));
    }
    #endregion
}