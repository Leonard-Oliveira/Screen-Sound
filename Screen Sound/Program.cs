// Screen Sound 

//variaveis globais
using System.Numerics;

string mensagemDeBoasVindas = "Boas-Vindas ao Screen Sound!";
Dictionary<string, List<int>> listaDebandas = new Dictionary<string, List<int>>(StringComparer.OrdinalIgnoreCase)
{
    {"Angra", new List<int>() {10, 1, 2} },
    {"Hibria", new List<int>() {10, 9, 10}},
    {"Nightwish", new List<int>() {9, 8, 9}}
};

bool rodando = true;

// MAIN
TelaInicial();

// FUNCOES DE LAYOUT
void TelaInicial()
{
    while (rodando)
    {
        Console.Clear();
        ApresentaTituloDoMenu();
        ApresentaMenuDeOpcoes();
        ProcessaSelecao();
    }
}
void ApresentaTituloDoMenu() // apresenta o titulo de boas vindas e a logo
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine($"\n {mensagemDeBoasVindas}");
}
void ApresentaMenuDeOpcoes() //configura a ordem das opcoes do menu
{
    Console.WriteLine("\n1. Registrar uma Banda");
    Console.WriteLine("2. Mostrar todas as bandas");
    Console.WriteLine("3. Avaliar uma banda");
    Console.WriteLine("4. Exibir a media de uma banda");
    Console.WriteLine("5. Buscar banda na lista");
    Console.WriteLine("-1. Sair");
}
void ApresentaTituloDaFuncao(string tituloDaFuncao)
/*configura o layout do titulo da funcao entre asteriscos
//exemplo:

//****************                              
//TITULO DA FUNCAO                              
/*****************

 */
{
    int tamanhoDoTitulo = tituloDaFuncao.Length;
    string asteriscos = string.Empty;
    Console.WriteLine(asteriscos.PadLeft(tamanhoDoTitulo, '*'));
    Console.WriteLine(tituloDaFuncao);
    Console.WriteLine(asteriscos.PadLeft(tamanhoDoTitulo, '*') + "\n");
}

void TransicaoDeTelas(string mensagem = "Carregando")
{
    Console.Write("\n" + mensagem);
    for (int i = 0; i < 3; i++)
    {
        Thread.Sleep(300);
        Console.Write(".");
    }
    Thread.Sleep(150);
    Console.Clear();
}

// FUNCOES
void ProcessaSelecao()
{ //Processa a opcao selecionada pelo usuario no menu de opcoes
    Console.Write("\nDigite o numero da sua opcao: ");

    string opcaoEscolhida = Console.ReadLine();
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida!);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: //Registrar banda
            Console.WriteLine("Voce escolheu a opcao " + opcaoEscolhidaNumerica);
            RegistraBanda();
            break;

        case 2: //mostrar todas as bandas
            Console.WriteLine("Voce escolheu a opcao " + opcaoEscolhidaNumerica);
            MostraListaDeBandas();
            break;

        case 3: //avaliar uma banda
            Console.WriteLine("Voce escolheu a opcao " + opcaoEscolhidaNumerica);
            AvaliaNotaBanda();
            break;

        case 4: //exibir media da banda
            Console.WriteLine("Voce escolheu a opcao " + opcaoEscolhidaNumerica);
            ObtemMediaDaBanda();
            break;

        case 5: //buscar banda na lista
            Console.WriteLine("Voce escolheu a opcao " + opcaoEscolhidaNumerica);
            BuscaBandaNaLista();
            break;

        case -1:
            Console.WriteLine("tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opcao invalida");
            break;
    }
}
void RegistraBanda()
{
    Console.Clear();
    ApresentaTituloDaFuncao("Registrar banda");
    Console.Write("Informe o nome da banda que voce quer registrar: ");
    string nomeDaBandaAdicionada = Console.ReadLine()!;
    listaDebandas.Add(nomeDaBandaAdicionada, new List<int>());
    Console.WriteLine($"\nVoce registrou a banda {nomeDaBandaAdicionada}");
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();
    TransicaoDeTelas("Voltando ao menu");
}
void MostraListaDeBandas()
{
    int index = 0;

    Console.Clear();
    ApresentaTituloDaFuncao("Bandas Cadastradas no Sistema");
    for (int i = 0; i < listaDebandas.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {listaDebandas.ElementAt(i).Key}");
    }
    Console.WriteLine("\nDigite qualquer Tecla para voltar ao Menu.");
    Console.ReadKey();
    TransicaoDeTelas("Voltando ao menu");
}
void ObtemMediaDaBanda()
{
    Console.WriteLine("Informe o nome da banda que esta procurando a nota");
    string bandaProcurada = Console.ReadLine()!;

    if (listaDebandas.TryGetValue(bandaProcurada, out var notas))
    {
        Console.WriteLine($"A media da banda {bandaProcurada} e' {notas.Average():F2}");
    }
    else
    {
        Console.WriteLine("banda nao cadastrada");
    }

    Console.WriteLine("Presssione uma tecla para sair");
    Console.ReadKey();
    TransicaoDeTelas("Voltando ao menu");
}
void AvaliaNotaBanda()
{
    Console.Clear();
    Console.Write("\nInforme a nota que voce da para a banda: ");
    string notaMediaInformada = Console.ReadLine();
    int notaMediaConvertida = int.Parse(notaMediaInformada!);

    if (notaMediaConvertida >= 5)
    {
        Console.WriteLine("\nNota suficiente para aprovacao!");
    }
    else
    {
        Console.WriteLine("Nota insuficiente para aprovacao");
    }
}
void BuscaBandaNaLista()
{
    Console.Clear();
    Console.Write("Informe o nome da banda que voce esta procurando: ");
    string bandaProcurada = Console.ReadLine();
    if (listaDebandas.TryGetValue(bandaProcurada, out var notas))
    {
        Console.WriteLine($"\nA banda {bandaProcurada} esta cadastrada!");
    }
    else
    {
        Console.WriteLine("\nA banda procurada nao esta cadastrada");
    }
    Console.WriteLine("\nInsira uma tecla para votar ao menu principal");
    Console.ReadKey();
    TransicaoDeTelas();
}