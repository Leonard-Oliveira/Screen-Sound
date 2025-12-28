using ScreenSound.Application;
namespace ScreenSound.Menus;

internal class MenuExibirDetalhesComIA : MenuComContexto<ChatService>
{
    public MenuExibirDetalhesComIA(SystemContext context, ChatService chatService) 
        : base(context, chatService) { }

    protected override async Task ExibirConteudo()
    {
        ExibirTituloDoMenu("Resumo da Banda com IA");
        Console.Write("Digite o nome da banda que deseja conhecer: ");
        string nomeDaBanda = Console.ReadLine()!;

        Console.WriteLine("\n✨ Consultando o Gemini, aguarde...");

        string prompt = $"Escreva um resumo biográfico curto e profissional da banda {nomeDaBanda}.";
        
        string resumo = await Service.ConsultarIA(prompt);

        Console.WriteLine($"\n🤖 Bio da Banda:\n{resumo}");
        
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
    }
}