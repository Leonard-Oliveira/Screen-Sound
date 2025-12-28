namespace ScreenSound.UI;

using ScreenSound.Application;
using ScreenSound.Utils;

internal class MenuDetalhesDaBanda : MenuComContexto<BandaService>
{
    public MenuDetalhesDaBanda(SystemContext context, BandaService service) : base(context, service) { }

    protected override async Task ExibirConteudo()
    {
        ExibirTituloDoMenu("Buscar Informaçoes da Banda");

        //string busca = ConsoleUtils.SolicitaTexto("Informe a banda que está procurando: ");
        var banda = Service.BuscarBandaPorNome(ConsoleUtils.SolicitaTexto("Informe a banda que está procurando: "));
        if (banda != null)
        {
            Console.WriteLine(banda.NomeDaBanda);
            Console.WriteLine(banda.AvaliacaoMedia);
            banda.ExibirDiscografia();
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();
            LoadingTransicao();
        }
        else
        {
            Console.WriteLine("\n⚠️ Banda não registrada no sistema.");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
            LoadingTransicao();
        }

        await Task.CompletedTask;
    }
}