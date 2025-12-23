namespace ScreenSound.Application;
using ScreenSound.Domain;
internal class BandaService
{   
    private readonly SystemContext _context;
    public BandaService(SystemContext context) {_context = context;}
    
    /// <summary>
    /// Realiza uma busca segura que retorna null caso a banda não seja encontrada.
    /// </summary>
    public Banda? BuscarBandaPorNome(string nomeDaBanda) => 
        _context.ListaDeTodasAsBandas.FirstOrDefault(a => a.NomeDaBanda
            .Equals(nomeDaBanda, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Registra uma nova banda garantindo que não haja duplicidade no sistema.
    /// </summary>
    /// <exception cref="InvalidOperationException">Lançada se a banda já existir.</exception>
    public void RegistraNovaBanda(string nomeDaBanda)
    {
        ArgumentException.ThrowIfNullOrEmpty(nomeDaBanda);
        _context.ListaDeTodasAsBandas.Add(new Banda(nomeDaBanda));
    }

    /// <summary>
    /// Atribui uma nota a uma banda existente após validar os critérios de pontuação.
    /// </summary>
    public void AvaliaBanda(Banda banda, int nota)
    {
        ArgumentNullException.ThrowIfNull(banda);
        if (nota < 1 || nota > 10) throw new ArgumentOutOfRangeException(
            nameof(nota), nota, "Valor de nota atribuído é inválido. Valor deve ser 1-10");
    
        banda.AdicionarAvaliacao(new Avaliacao(nota));
    }
}