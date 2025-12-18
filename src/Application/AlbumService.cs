namespace ScreenSound.Application;

using ScreenSound.Domain;

public class AlbumService
{
    public static List<Album> _listaDeTodosOsAlbuns = new List<Album>();

    private readonly BandaService _bandaService = new BandaService();

    public void CriaERegistraAlbum(string nomeDoAlbum, string bandaDoAlbum, int anoDeLancamento)
    {
        // Busca na lisaDeTodosOsArtistas o nome do artista usado como parametro para criacao do album
        Banda? bandaEncontrada = _bandaService.BuscarBandaPorNome(bandaDoAlbum);  

        // Se não existir, cria o artista novo
        Banda bandaFinal = bandaEncontrada ?? new Banda(bandaDoAlbum);

        // Instancia o Album
        Album novoAlbum = new Album(nomeDoAlbum, bandaFinal, anoDeLancamento);
        _listaDeTodosOsAlbuns.Add(novoAlbum);
    }
}