namespace ScreenSound.Application;

using ScreenSound.Domain;
internal class MusicaService
{
    private SystemContext _context;
    public MusicaService(SystemContext context)
    {
        _context = context;
    }

    public void RegistrarNovaMusica(string nomeMusica, Banda banda, int duracao, Genero genero)
    {
        if (string.IsNullOrWhiteSpace(nomeMusica)) throw new ArgumentException("Nome da música inválido.");
        if (duracao <= 0) throw new ArgumentException("A duração deve ser positiva.");
        if (banda == null) throw new KeyNotFoundException("Banda não registrada no Sistema.");
        if (genero == null) throw new ArgumentNullException(nameof(genero), "Gênero não pode ser nulo.");

        bool musicaDuplicada = _context.ListaDeTodasAsMusicas.Any(m =>
            m.NomeDaMusica.Equals(nomeMusica, StringComparison.OrdinalIgnoreCase)
            && m.BandaDaMusica == banda);

        if (musicaDuplicada)
        {
            throw new InvalidOperationException(
                $"A música '{nomeMusica}' já está cadastrada paraa banda {banda.NomeDaBanda}.");
        }

        Musica novaMusica = new Musica(nomeMusica, banda, duracao, genero);
        _context.ListaDeTodasAsMusicas.Add(novaMusica);
    }
}