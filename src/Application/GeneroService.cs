namespace ScreenSound.Application;
class GeneroService
{
    private readonly SystemContext _context;
    public GeneroService(SystemContext context)
    {
        _context = context;
    }
    //funcao que retorna um objeto confirmando ou nao se o nomeDoGeneroProcurado corresponde a um Genero
    public Genero? BuscarGeneroPorNome(string nomeDoGeneroProcurado)
    {
        return _context.ListaDeTodosOsGeneros.FirstOrDefault(g => g.NomeDoGenero.Equals(nomeDoGeneroProcurado, StringComparison.OrdinalIgnoreCase));
    }

    public void CriarGenero(string nomeDoGenero)
    {
        if (string.IsNullOrWhiteSpace(nomeDoGenero)) throw new ArgumentNullException("Gênero nao pode ser null");

        if (BuscarGeneroPorNome(nomeDoGenero) != null) throw new InvalidOperationException($"O gênero '{nomeDoGenero}' já está cadastrado.");

        _context.ListaDeTodosOsGeneros.Add(new Genero(nomeDoGenero));
    }

    public Genero ObterOuCriarGenero(string nomeDoGeneroParaVincular)
    {
        var genero = BuscarGeneroPorNome(nomeDoGeneroParaVincular);

        if (genero == null)
        {
            genero = new Genero(nomeDoGeneroParaVincular);
            _context.ListaDeTodosOsGeneros.Add(genero);
        }

        return genero;
    }

    public IEnumerable<Genero> ListarTodosOsGeneros()
    {
        return _context.ListaDeTodosOsGeneros;
    }
}