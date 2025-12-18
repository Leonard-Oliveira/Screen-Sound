using ScreenSound.Domain;
namespace ScreenSound.Application;
class ArtistaService
{   
    // CONSULTA SIMPLES (Para uso no AlbumService)
    // Útil para apenas checar se algo existe sem causar exceptions.
    public Artista? BuscarArtistaPorNome(string nomeDoArtistaProcurado)
    {
        return Artista.listaDeTodosOsArtistas
            .FirstOrDefault(a => a.Nome.Equals(nomeDoArtistaProcurado, StringComparison.OrdinalIgnoreCase));
    }

    // (Para o Program.cs)
    // Se o usuário tentar cadastrar algo que já existe, throw Exception.
    public void RegistrarNovoArtista(string nomeDoArtistaASerRegistrado)
    {
        if (string.IsNullOrWhiteSpace(nomeDoArtistaASerRegistrado)) throw new ArgumentException("Nome vazio.");
        
        if (BuscarArtistaPorNome(nomeDoArtistaASerRegistrado) != null)
            throw new InvalidOperationException($"O artista '{nomeDoArtistaASerRegistrado}' já está no sistema.");

        Artista.listaDeTodosOsArtistas.Add(new Artista(nomeDoArtistaASerRegistrado));
    }

    // (Para o MusicaService)
    // O sistema obtem o Artista, sem exceptions. Se não existir, cria um novo.
    public Artista ObterArtistaParaVinculo(string nomeDoArtistaParaVincular)
    {
        var artista = BuscarArtistaPorNome(nomeDoArtistaParaVincular);
        
        if (artista == null)
        {
            artista = new Artista(nomeDoArtistaParaVincular);
            Artista.listaDeTodosOsArtistas.Add(artista);
        }
        
        return artista;
    }
}