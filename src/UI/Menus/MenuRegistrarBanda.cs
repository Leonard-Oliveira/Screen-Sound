namespace ScreenSound.UI.Menus;
using ScreenSound.Application;
using ScreenSound.Utils;

internal class MenuRegistrarBanda : MenuComContexto<BandaService>
{
    public MenuRegistrarBanda(SystemContext context, BandaService bandaService) 
        : base(context, bandaService) {}

    protected override void ExibirConteudo()
    {
        ExibirTituloDoMenu("Registrar Banda");

        string nomeDaBanda = ConsoleUtils.SolicitaTexto("Informe o nome da banda que você quer registrar: ");

        Service.RegistraNovaBanda(nomeDaBanda);

        Console.WriteLine($"\n✅ Banda '{nomeDaBanda}' registrada com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
        LoadingTransicao();
    }
}