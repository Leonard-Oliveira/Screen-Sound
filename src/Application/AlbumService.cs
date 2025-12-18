namespace ScreenSound.Application;

using ScreenSound.Domain;

public class AlbumService
{
    public static List<Album> _listaDeTodosOsAlbuns = new List<Album>();

    private readonly ArtistaService _artistaService = new ArtistaService();

    public void CriaERegistraAlbum(string nomeDoAlbum, string artistaDoAlbum, int anoDeLancamento)
    {
        // Busca na lisaDeTodosOsArtistas o nome do artista usado como parametro para criacao do album
        Artista? artistaEncontrado = _artistaService.BuscarArtistaPorNome(artistaDoAlbum);  

        // Se não existir, cria o artista novo
        Artista artistaFinal = artistaEncontrado ?? new Artista(artistaDoAlbum);

        // Instancia o Album
        Album novoAlbum = new Album(nomeDoAlbum, artistaFinal, anoDeLancamento);
        _listaDeTodosOsAlbuns.Add(novoAlbum);
    }
}