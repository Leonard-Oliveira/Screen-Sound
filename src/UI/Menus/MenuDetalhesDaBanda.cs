namespace ScreenSound.UI;
using ScreenSound.Application;
using ScreenSound.Utils;

internal class MenuDetalhesDaBanda : Menu<BandaService> 
{
    private readonly SystemContext _systemContext;

    public MenuDetalhesDaBanda(SystemContext context) 
    {
        _systemContext = context;
    }

    protected override void ExibirConteudo(BandaService bandaService) {
        ExibirTituloDoMenu("Buscar Informaçoes da Banda");

        //string busca = ConsoleUtils.SolicitaTexto("Informe a banda que está procurando: ");
        var banda = bandaService.BuscarBandaPorNome(ConsoleUtils.SolicitaTexto("Informe a banda que está procurando: "));
        if (banda != null)
        {
            Console.WriteLine(banda.NomeDaBanda);
            Console.WriteLine(banda.AvaliacaoMedia);
            banda.ExibirDiscografia();
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();
            LoadingTransicao();
        } else
        {
            Console.WriteLine("Banda não registrada");
        }
    }
}