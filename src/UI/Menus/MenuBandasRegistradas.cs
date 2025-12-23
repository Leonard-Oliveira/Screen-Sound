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
        int index = 1;
        ConsoleUtils.LimparTela();
        ExibirTituloDoMenu("Exibindo todas as bandas registradas na nossa aplicação");
        foreach (var banda in _systemContext.ListaDeTodasAsBandas)
        {
            Console.WriteLine($"{index}. {banda.NomeDaBanda}");
            index++;
        }
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal");
        Console.ReadKey();
        LoadingTransicao();
    }
}