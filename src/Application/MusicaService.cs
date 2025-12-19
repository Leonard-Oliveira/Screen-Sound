namespace ScreenSound.Application;
using ScreenSound.Domain;
public class MusicaService
{
    public static List<Musica> _listaDeTodasAsMusicas = new List<Musica>();
    private readonly BandaService _bandaService = new BandaService();

    // Esta função centraliza a regra: "Para criar uma música, primeiro resolva o artista solicitando ao ArtistaService a validacao"
    public void RegistrarNovaMusica(string nomeMusica, string nomeDaBanda, int duracao, string nomeGenero)
    {
        // Validações básicas da música (Regra de Negócio Própria)
        if (string.IsNullOrWhiteSpace(nomeMusica)) throw new ArgumentException("Nome da música inválido.");
        if (duracao <= 0) throw new ArgumentException("A duração deve ser positiva.");

        // Utiliza o ArtistaService para buscar/criar o artista (validacao)
        Banda banda = _bandaService.ObterBandaParaVinculo(nomeDaBanda);

        // Utiliza o GeneroService para buscar/criar o gênero (validação)
        var generoService = new GeneroService();
        Genero? generoEncontrado = generoService.BuscarGeneroPorNome(nomeGenero);

        // Se o gênero não existir, criamos um novo na hora
        if (generoEncontrado == null)
        {
            generoService.CriarGenero(nomeGenero);
            generoEncontrado = generoService.BuscarGeneroPorNome(nomeGenero);
        }

        // Verifica se essa música já existe para ESSE artista específico
        // (Evita que o mesmo artista tenha duas músicas com o mesmo nome)
        if (_listaDeTodasAsMusicas.Any(m => m.NomeDaMusica.Equals(nomeMusica, StringComparison.OrdinalIgnoreCase)
            && m.BandaDaMusica == banda))
        {
            throw new InvalidOperationException($"A música '{nomeMusica}' já está cadastrada para o artista {banda.NomeDaBanda}.");
        }

        // Criação final
        Musica novaMusica = new Musica(nomeMusica, banda, duracao, generoEncontrado!);
        _listaDeTodasAsMusicas.Add(novaMusica);
    }
}