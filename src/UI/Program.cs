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
    var menus = new Dictionary<int, Action>
    {
        { 1, () => menuFactory.CriarMenuRegistrarBanda().Executar() },
        { 2, () => menuFactory.CriarMenuRegistrarAlbum().Executar() },
        { 3, () => menuFactory.CriarMenuBandasRegistradas().Executar() },
        { 4, () => menuFactory.CriarMenuAvaliarBanda().Executar() },
        { 5, () => menuFactory.CriarMenuDetalhesDaBanda().Executar() },
        { 6, () => menuFactory.CriarMenuAvaliarAlbum().Executar() }
    };
    
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

        if (opcaoEscolhida == -1) 
        {
            Console.WriteLine("Tchau tchau :)");
            executando = false;
        }
        else if (menus.ContainsKey(opcaoEscolhida)) 
        {
            menus[opcaoEscolhida].Invoke();
        }
        else 
        {
            Console.WriteLine("Opção inválida");
        }
    }

}

Console.WriteLine($"DEBUG: Total de bandas no contexto: {context.ListaDeTodasAsBandas.Count}");
ExibirOpcoesDoMenu();