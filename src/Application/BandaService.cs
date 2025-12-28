namespace ScreenSound.Application;
using ScreenSound.Domain;
internal class BandaService
{   
    #region Propriedades Privadas
    private readonly SystemContext _context;
    #endregion

    #region Construtor
    public BandaService(SystemContext context) {_context = context;}
    #endregion
    
    #region Métodos
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
    #endregion
}