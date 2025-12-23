using ScreenSound.UI.Menus;
using ScreenSound.Application;
using ScreenSound.Utils;
using ScreenSound.UI;

var contexto = new SystemContext();

contexto.SemeiaDados();

var bandaService = new BandaService(contexto);
var albumService = new AlbumService(contexto);

bool executando = true;

void ExibirLogo() // apresenta o titulo de boas vindas e a logo
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
        Console.WriteLine("\nDigite 1 para registrar uma banda");
        Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
        Console.WriteLine("Digite 3 para mostrar todas as bandas");
        Console.WriteLine("Digite 4 para avaliar uma banda");
        Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
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
                //ExibirDetalhes();
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



// void ExibirTituloDaOpcao(string titulo)
// {
//     int quantidadeDeLetras = titulo.Length;
//     string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
//     Console.WriteLine(asteriscos);
//     Console.WriteLine(titulo);
//     Console.WriteLine(asteriscos + "\n");
// }



// // void ExibirDetalhes()
// {
//     Console.Clear();
//     ExibirTituloDaOpcao("Exibir detalhes da banda");
//     Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
//     string nomeDaBanda = Console.ReadLine()!;
//     if (bandasRegistradas.ContainsKey(nomeDaBanda))
//     {
//         List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
//         Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
//         /**
//         * ESPAÇO RESERVADO PARA COMPLETAR A FUNÇÃO
//         */
//         Console.WriteLine("Digite uma tecla para votar ao menu principal");
//         Console.ReadKey();
//         Console.Clear();
//         ExibirOpcoesDoMenu();

//     }
//     else
//     {
//         Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
//         Console.WriteLine("Digite uma tecla para voltar ao menu principal");
//         Console.ReadKey();
//         Console.Clear();
//         ExibirOpcoesDoMenu();
//     }
// }
Console.WriteLine($"DEBUG: Total de bandas no contexto: {contexto.ListaDeTodasAsBandas.Count}");
ExibirOpcoesDoMenu();