using ScreenSound.UI.Menus;
using ScreenSound.Application;
using ScreenSound.Utils;
using ScreenSound.UI;

var contexto = new SystemContext();

contexto.SemeiaDados();

var bandaService = new BandaService(contexto);
var albumService = new AlbumService(contexto);

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
        Console.WriteLine("Digite -1 para sair");

        int opcaoEscolhida = ConsoleUtils.SolicitaInteiro("Digite a opcao escolhida: ");

        switch (opcaoEscolhida)
        {
            case 1:
                new MenuRegistrarBanda().Executar(bandaService);
                break;
            case 2:
                new MenuRegistrarAlbum(contexto).Executar(albumService);
                break;
            case 3:
                new MenuBandasRegistradas(contexto).Executar(bandaService);
                break;
            case 4:
                new MenuAvaliarBanda().Executar(bandaService);
                break;
            case 5:
                new MenuDetalhesDaBanda(contexto).Executar(bandaService);
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

Console.WriteLine($"DEBUG: Total de bandas no contexto: {contexto.ListaDeTodasAsBandas.Count}");
ExibirOpcoesDoMenu();