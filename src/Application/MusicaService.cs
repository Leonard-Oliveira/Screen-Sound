namespace ScreenSound.Application;
using ScreenSound.Domain;


public class MusicaService
{
    private readonly ArtistaService _artistaService = new ArtistaService();

    // Esta função centraliza a regra: "Para criar uma música, primeiro resolva o artista solicitando ao ArtistaService a validacao"
    public void RegistrarNovaMusica(string nomeMusica, string nomeArtista, int duracao)
    {
        // Validações básicas da música (Regra de Negócio Própria)
        if (string.IsNullOrWhiteSpace(nomeMusica)) throw new ArgumentException("Nome da música inválido.");
        if (duracao <= 0) throw new ArgumentException("A duração deve ser positiva.");

        // Utiliza o ArtistaService para buscar/criar o artista (validacao)
        Artista artista = _artistaService.ObterArtistaParaVinculo(nomeArtista);

        // Verifica se essa música já existe para ESSE artista específico
        // (Evita que o mesmo artista tenha duas músicas com o mesmo nome)
        if (Musica.listaDeTodasAsMusicas.Any(m => m.NomeDaMusica.Equals(nomeMusica, StringComparison.OrdinalIgnoreCase) 
            && m.ArtistaDaMusica == artista))
        {
            throw new InvalidOperationException($"A música '{nomeMusica}' já está cadastrada para o artista {artista.Nome}.");
        }

         // Criação final
        Musica novaMusica = new Musica(nomeMusica, artista, duracao);
        Musica.listaDeTodasAsMusicas.Add(novaMusica);
    }
}