using ScreenSound.Application;
using ScreenSound.Utils;
namespace ScreenSound.UI;

internal class MenuBandasRegistradas : MenuComContexto<BandaService>
{
    public MenuBandasRegistradas(SystemContext context, BandaService service) : base(context, service) {}
    
    protected override async Task ExibirConteudo()
    {
        int index = 1;
        ConsoleUtils.LimparTela();
        ExibirTituloDoMenu("Exibindo todas as bandas registradas na nossa aplicação");
        foreach (var banda in Context.ListaDeTodasAsBandas)
        {
            Console.WriteLine($"{index}. {banda.NomeDaBanda}");
            index++;
        }
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal");
        Console.ReadKey();
        LoadingTransicao();

        await Task.CompletedTask;
    }
}