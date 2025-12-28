using ScreenSound.UI.Menus;
using ScreenSound.Application;
using ScreenSound.Utils;

var context = new SystemContext();
var menuFactory = new MenuFactory(context);

context.SemeiaDados();

bool executando = true;

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    while (executando)
    {
        ConsoleUtils.LimparTela();
        ExibirLogo();
        Console.WriteLine("\n1. Registrar banda");
        Console.WriteLine("2. Registrar Album");
        Console.WriteLine("3. Lista de Bandas");
        Console.WriteLine("4. Avaliar uma banda");
        Console.WriteLine("5. Buscar detalhes de uma banda");
        Console.WriteLine("6. Avaliar Album");
        Console.WriteLine("Digite -1 para sair");

        int opcaoEscolhida = ConsoleUtils.SolicitaInteiro("Digite a opcao escolhida: ");

        switch (opcaoEscolhida)
        {
            case 1:
                menuFactory.CriarMenuRegistrarBanda().Executar();
                break;
            case 2:
                menuFactory.CriarMenuRegistrarAlbum().Executar();
                break;
            case 3:
                menuFactory.CriarMenuBandasRegistradas().Executar();
                break;
            case 4:
                menuFactory.CriarMenuAvaliarBanda().Executar();
                break;
            case 5:
                menuFactory.CriarMenuDetalhesDaBanda().Executar();
                break;
            case 6: 
                menuFactory.CriarMenuAvaliarAlbum().Executar();
                break;
            case -1:
                Console.WriteLine("Tchau tchau :)");
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
}
    
Console.WriteLine($"DEBUG: Total de bandas no contexto: {context.ListaDeTodasAsBandas.Count}");
ExibirOpcoesDoMenu();