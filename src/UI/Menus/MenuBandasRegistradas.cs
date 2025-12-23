using ScreenSound.Application;
using ScreenSound.Utils;
namespace ScreenSound.UI;

internal class MenuBandasRegistradas : Menu<BandaService>
{
    private readonly SystemContext _systemContext;

    public MenuBandasRegistradas(SystemContext contexto)
    {
        _systemContext = contexto;
    }
    protected override void ExibirConteudo(BandaService bandaService)
    {
        Console.Clear();
        ExibirTituloDoMenu("Exibindo todas as bandas registradas na nossa aplicação");
        foreach (var banda in _systemContext.ListaDeTodasAsBandas)
        {
            Console.WriteLine(banda.NomeDaBanda);
        }

        LoadingTransicao();
    }
}