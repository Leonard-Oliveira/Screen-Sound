namespace ScreenSound.Application;
using ScreenSound.Domain;
class MusicaService
{
    // Acessa o "bancod de dados"
    private readonly SystemContext _context;

    // Permite oa cesso aos metodos do BandaService
    private readonly BandaService _bandaService;

    // Permite o acesso aos metodos do GeneroService
    private readonly GeneroService _generoService;

    public MusicaService(SystemContext context, BandaService bandaService, GeneroService generoService)
    {
        _context = context;
        _bandaService = bandaService;
        _generoService = generoService;
    }
    
    // Esta função centraliza a regra: "Para criar uma música, primeiro resolva o artista solicitando ao ArtistaService a validacao"
    public void RegistrarNovaMusica(string nomeMusica, string nomeDaBanda, int duracao, string nomeGenero)
    {
        // VALIDACAO nomeDaMusica
        if (string.IsNullOrWhiteSpace(nomeMusica)) throw new ArgumentException("Nome da música inválido.");
        if (duracao <= 0) throw new ArgumentException("A duração deve ser positiva.");

        // VALDACAO nomeDaBanda
        Banda banda = _bandaService.ObterOuCriarBanda(nomeDaBanda);

        // VALIDACAO nomeGenero
        Genero genero = _generoService.ObterOuCriarGenero(nomeGenero);

        // Verifica se essa música já existe para ESSE artista específico
        // (Evita que o mesmo artista tenha duas músicas com o mesmo nome)
        if (_context.ListaDeTodasAsMusicas.Any(m => m.NomeDaMusica.Equals(nomeMusica, StringComparison.OrdinalIgnoreCase)
            && m.BandaDaMusica == banda))
        {
            throw new InvalidOperationException($"A música '{nomeMusica}' já está cadastrada para o artista {banda.NomeDaBanda}.");
        }

        // Criação final
        Musica novaMusica = new Musica(nomeMusica, banda, duracao, genero);
        _context.ListaDeTodasAsMusicas.Add(novaMusica);
    }
}