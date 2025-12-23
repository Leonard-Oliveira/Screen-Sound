namespace ScreenSound.UI.Menus;
using ScreenSound.Application;
using ScreenSound.Domain;
using ScreenSound.Utils;

internal class MenuRegistrarBanda : Menu<BandaService>
{
    protected override void ExibirConteudo(BandaService bandaService)
    {
        ConsoleUtils.LimparTela();
        ExibirTituloDoMenu("Registrar Banda");

        Console.Write("Informe o nome da banda que voce quer registrar: ");
        string nomeDaBanda = Console.ReadLine() ?? string.Empty;

        bandaService.RegistraNovaBanda(nomeDaBanda);

        Console.WriteLine($"\nBanda '{nomeDaBanda}' registrada com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}