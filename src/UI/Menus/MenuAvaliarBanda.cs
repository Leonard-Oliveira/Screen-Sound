using ScreenSound.Application;
using ScreenSound.Utils;

internal class MenuAvaliarBanda : Menu<BandaService> {
    protected override void ExibirConteudo(BandaService bandaService)
    {
        ExibirTituloDoMenu("Avaliar Banda");

        string bandaAvaliada = ConsoleUtils.SolicitaTexto("Qual o nome da banda que você quer avaliar? ");
        
        if (bandaService.BuscarBandaPorNome(bandaAvaliada) == null)
        {
            Console.WriteLine($"\n⚠️ Banda {bandaAvaliada} nao Registrada no Sistema");
            string confirmacao = ConsoleUtils.SolicitaTexto("Deseja registra-la agora para avaliacao? (S/N)").ToUpper();
            
            if (confirmacao == "S") {
                bandaService.RegistraNovaBanda(bandaAvaliada);
                Console.WriteLine("✅ Banda registrada com sucesso!");
            } 
            else
            {
                Console.WriteLine("Encerrando operacao e retornando ao menu principal");
                LoadingTransicao();
                return;
            }
        }

        int nota = ConsoleUtils.SolicitaInteiro($"Qual a nota da banda: {bandaAvaliada} (1-10)? ");
        
        bandaService.AvaliaBanda(bandaAvaliada, nota);
        Console.WriteLine($"\n⭐ Sucesso! Você deu nota {nota} para a banda {bandaAvaliada}.");
    }
}