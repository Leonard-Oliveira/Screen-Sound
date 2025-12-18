// Artista? artistaEncontrado = Artista.listaDeTodosOsArtistas
// .FirstOrDefault(a => a.Nome.Equals(artista, StringComparison.OrdinalIgnoreCase));
// this.Artista = artistaEncontrado ?? new Artista(artista);

using ScreenSound.Domain;

public class AlbumService
{
    public void CriaERegistraAlbum(string nomeDoAlbum, string artistaDoAlbum, int anoDeLancamento)
    {
        // Busca na lisaDeTodosOsArtistas o nome do artista usado como parametro para criacao do album
        Artista? artistaEncontrado = Artista.listaDeTodosOsArtistas.FirstOrDefault(a => a.Nome.Equals(artistaDoAlbum, StringComparison.OrdinalIgnoreCase));

        // Se não existir, cria o artista novo
        Artista artistaFinal = artistaEncontrado ?? new Artista(artistaDoAlbum);

        // Instancia o Album
        Album novoAlbum = new Album(nomeDoAlbum, artistaFinal, anoDeLancamento);
        
        Console.WriteLine($"✅ Sucesso: '{novoAlbum.NomeDoAlbum}' foi vinculado a '{artistaFinal.Nome}'.");
    }

    
}